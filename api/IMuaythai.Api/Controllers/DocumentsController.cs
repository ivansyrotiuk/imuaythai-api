using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.Docs;
using IMuaythai.Repositories;
using IMuaythai.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class DocumentsController : Controller
    {
        private readonly IDocumentsRepository _documentsRepository;
        private readonly IFileSaver _fileSaver;

        public DocumentsController(IDocumentsRepository documentsRepository, IFileSaver fileSaver)
        {
            _documentsRepository = documentsRepository;
            _fileSaver = fileSaver;
        }

        public async Task<IActionResult> Index()
        {

            var documents = await _documentsRepository.GetAll();
            return Ok(documents);
        }

        [Route("user/{id}")]
        public async Task<IActionResult> GetUserDocuments(string id)
        {
            var documents = await _documentsRepository.GetAllForUser(id);
            return Ok(documents);
        }

        [Route("contest/{id}")]
        public async Task<IActionResult> GetContestDocuments(int id)
        {
            var documents = await _documentsRepository.GetAllForContest(id);
            return Ok(documents);
        }

        [Route("institution/{id}")]
        public async Task<IActionResult> GetInstitutionDocuments(int id)
        {
            var documents = await _documentsRepository.GetAllForInstitution(id);
            return Ok(documents);
        }

        [Route("save")]
        public async Task<IActionResult> Save([FromBody] List<DocumentModel> documents)
        {
            var documentEntities = new List<Document>();


            foreach (var document in documents)
            {
                var base64 = document.ByteArray.Split(',');

                var documentUrl = _fileSaver.Save(document.Name, base64[1]);

                Document documentEntity = new Document
                {
                    Name = document.Name,
                    Url = documentUrl
                };

                if (document.InstitutionId != null && document.InstitutionId > 0)
                    documentEntity.InstitutionDocumentsMappings = new[] {new InstitutionDocumentsMapping
                    {
                        InstitutionId = document.InstitutionId ?? 0
                    }};
                else if (document.ContestId != null && document.ContestId > 0)
                    documentEntity.ContestDocumentsMappings = new[]{new ContestDocumentsMapping
                    {
                        InstitutionId = document.ContestId ?? 0
                    }};
                else if (!string.IsNullOrEmpty(document.UserId))
                    documentEntity.UserDocumentsMappings = new[]{new UserDocumentsMapping
                    {
                        UserId = document.UserId
                    }};

                documentEntities.Add(documentEntity);

                await _documentsRepository.Save(documentEntity);
            }


            return Created("/documents/save", documentEntities);
        }

    }
}
