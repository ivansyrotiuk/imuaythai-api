using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Data.OData.Atom;

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
        [Route("save")]
        public async Task<IActionResult> Save([FromBody] List<DocumentDto> documents)
        {
            var cloudinary = GetDefaultCloudinaryObject();
           

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
            }




            return Ok();
        }


        private Cloudinary GetDefaultCloudinaryObject()
        {
            Account account = new Account
            {
                ApiKey = "",
                ApiSecret = "",
                Cloud = ""
            };

            return new Cloudinary();
        }
    }

    public class DocumentDto
    {
        public string Name { get; set; }
        public string ByteArray { get; set; }
    }
}