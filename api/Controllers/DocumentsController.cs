using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MuaythaiSportManagementSystemApi.Data;
using MuaythaiSportManagementSystemApi.Extensions;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentsRepository _documentsRepository;

        public DocumentsController(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }
        
        public async Task<IActionResult> Index()
        {
           
            var documents = await _documentsRepository.GetAll();
            return Ok(documents);
        }
        
        [Route("user/{id}")]
        public async Task<IActionResult> GetUserDocuments(string id)
        {
            var documents =  await _documentsRepository.GetAllForUser(id);
            return Ok(documents);
        }
        
        [Route("contest/{id}")]
        public async Task<IActionResult> GetContestDocuments(int id)
        {
            var documents =  await _documentsRepository.GetAllForContest(id);
            return Ok(documents);
        }
        
        [Route("institution/{id}")]
        public async Task<IActionResult> GetInstitutionDocuments(int id)
        {
            var documents =  await _documentsRepository.GetAllForInstitution(id);
            return Ok(documents);
        }
        
        [Route("save")]
        public async Task<IActionResult> Save([FromBody] List<DocumentDto> documents)
        {
            var cloudinary = GetDefaultCloudinaryObject();
            var documentEntities = new List<Document>();
           

            foreach (var document in documents)
            {
                var base64 = document.ByteArray.Split(',');
                var bytes = Convert.FromBase64String(base64[1]);
                var stream = new MemoryStream(bytes);
                var upload = new RawUploadParams
                {
                    File = new FileDescription(document.Name, stream)
                };
                var uploadResult = await cloudinary.UploadAsync(upload);
                
                Document documentEntity = new Document
                {
                    Name = document.Name,
                    Url = uploadResult.Uri.AbsoluteUri,
                };

                if (document.InstitutionId != null && document.InstitutionId > 0)
                    documentEntity.InstitutionDocumentsMappings = new[] {new InstitutionDocumentsMapping
                    {
                        InstitutionId = document.InstitutionId.ToInt()
                    }};
                else if(document.ContestId != null && document.ContestId > 0)
                    documentEntity.ContestDocumentsMappings = new[]{new ContestDocumentsMapping
                    {
                        InstitutionId = document.ContestId.ToInt()
                    }};
                else if(!string.IsNullOrEmpty(document.UserId))
                    documentEntity.UserDocumentsMappings = new[]{new UserDocumentsMapping
                    {
                        UserId = document.UserId
                    }};
                
                documentEntities.Add(documentEntity);

                await _documentsRepository.Save(documentEntity);
            }


            return Created("/documents/save", documentEntities);
        }


        private Cloudinary GetDefaultCloudinaryObject()
        {
            Account account = new Account
            {
                ApiKey = "846494132354633",
                ApiSecret = "8NcTfg3hTDOq7fCHIqxyJMnq1dM",
                Cloud = "dfxixiniz"
            };

            return new Cloudinary(account);
        }
    }
}