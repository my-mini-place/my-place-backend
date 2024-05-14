using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;

using Api.Interfaces;

namespace My_Place_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        //Pobierz wszystkie dokumenty
        [HttpGet]
        public ActionResult<IEnumerable<Document>> Get()
        {
            var documents = _documentService.GetDocuments();

            return Ok(documents);
        }

        // Pobierz dokument o wybranym id
        [HttpGet("{id}")]
        public ActionResult<Document> GetById(int id)
        {
            var document = _documentService.GetDocumentById(id);

            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        // Endpoint POST do podpisywania dokumentu
        [HttpPost("sign")]
        public ActionResult<bool> SignDocument([FromBody] SignDocumentRequest request)
        {
            //logika

            return Ok(true);
        }

        [HttpPost("bitmap/{id}")]
        public IActionResult GetBitmap(int id)
        {
            var document = _documentService.GetDocumentById(id);

            if (document == null)
            {
                return NotFound();
            }

            //Zaimplementuje tutaj tworzenie Bitmapy.
            //var bitmap = GenerateBitmap(document);

            // Konwertuj bitmapę na ciąg znaków
            //var bitmapString = ConvertBitmapToString(bitmap);

            //return Ok(bitmapString);
            return null;
        }

        public class SignDocumentRequest
        {
            public bool Signed { get; set; }
        }
    }
}