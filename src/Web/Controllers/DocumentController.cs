using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using My_Place_Backend.DTO.AccountManagment;
//using Domain.Calendar;
using static Domain.Models.Document.DocumentModels;
using Web.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;
using static Domain.Calendar;
using Api.Interfaces;
using Web.Extensions;
using Domain.IRepositories;
using Infrastructure.Repositories;
using Azure;
using Api.Services;

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
        [HttpGet("getDocuments")]
        public async Task<object> GetDocuments()
        {
            var response = await _documentService.GetDocuments();

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }

            return Ok(response.Value);
        }

        // Pobierz dokument o wybranym id 
        [HttpGet("/getDocumentById{id}")]
        public async Task<object> GetById(int id)
        {
            Result<Document> response = await _documentService.GetDocumentById(id);

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }

            return Ok(response.Value); 
        }

        [HttpGet("getDocumentsSortedByDate{descending}")]
        public async Task<object> getDocumentsSortedByDate(bool descending)
        {
            var response = await _documentService.GetDocuments();

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }

            List<Document> response_sorted;

            if (descending)
            {
                response_sorted = response.Value.OrderByDescending(obj => obj.creation_date).ToList();
            }
            else
            {
                response_sorted = response.Value.OrderBy(obj => obj.creation_date).ToList();
            }

            return Ok(response_sorted);
        }


        [HttpPost]
        [Route("/signDocument")]
        public IActionResult SignDocument([FromBody] SignDocumentRequest request)
        {
            // Tutaj możesz umieścić logikę do podpisywania dokumentu
            if (request.Signed)
            {
                return Ok("Dokument został pomyślnie podpisany.");
            }
            else
            {
                return BadRequest("Nie udało się podpisać dokumentu.");
            }
        }

        [HttpPost]
        [Route("sign/document/bitmap/{document_id}")]
        public IActionResult SignDocumentBitmap(int document_id, [FromBody] BitmapDataRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.BitmapData))
            {
                return BadRequest("Nieprawidłowe żądanie");
            }

            // Tutaj możesz umieścić logikę przetwarzania danych bitmapy
            try
            {
                // Przykładowa logika przetwarzania danych bitmapy
                var signingDocument = new SigningDocument();
                request = signingDocument.SignDocument(request);

                return Ok("Pomyślnie podpisano dokument,  Treść dokumentu: " + request.BitmapData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd podczas przetwarzania danych bitmapy: {ex.Message}");
            }
        }

        public class SigningDocument
        {
            public BitmapDataRequest SignDocument(BitmapDataRequest request)
            {
                request.BitmapData += "    -   Dodaje podpis od dokumentu";

                return request;
            }

        }

        public class SignDocumentRequest
        {
            public bool Signed { get; set; }
        }

        public class BitmapDataRequest
        {
            public string BitmapData { get; set; }
        }
    }
}
