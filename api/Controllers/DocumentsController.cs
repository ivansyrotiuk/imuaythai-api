using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuaythaiSportManagementSystemApi.Repositories;

namespace MuaythaiSportManagementSystemApi.Controllers
{
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
    }
}