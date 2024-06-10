
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using My_Place_Backend.DTO.AccountManagment;
using static Domain.Models.Document.DocumentModels;
using Web.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain;
using static Domain.Calendar;
using Api.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using Api.Services;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf.IO;
using Domain.Models.Documents;
using Domain.Models.Identity;


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
    
    //Ta sekcja odpowiada za GET'y dla dokumentów dla WSZYSTKICH użytkowników.

        // Pobierz wszystkie dokumenty
        [HttpGet("getDocuments")]
        public async Task<object> GetDocuments()
        {
            var response = await _documentService.GetDocuments();

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            var documents = response.Value;

            return Ok(documents);
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

            Document document = response.Value;

            return File(document.content, "application/pdf", document.name);

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


    //Ta sekcja odpowiada za GET'y dla dokumentów dla WYBRANEGO użytkownika, wybieramy go podając id użytkownika.

        // Pobierz wszystkie dokumenty dla danego UserId
        [HttpGet("ForUser/getDocuments")]
        public async Task<object> GetDocumentsForUser(int userId)
        {
            var response = await _documentService.GetDocumentsByUserId(userId);

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }
            var documents = response.Value;

            return Ok(documents);
        }

        // Pobierz dokument o wybranym id i UserId
        [HttpGet("ForUser/getDocumentById{id}")]
        public async Task<object> GetByIdForUser(int id, int userId)
        {
            Result<IEnumerable<Document>> response = await _documentService.GetDocumentsByUserId(userId);

            if (response.IsFailure)
            {
                return response.ToProblemDetails();
            }

            var documents = response.Value.Where(doc => doc.DocumentId == id).ToList();

            if (documents == null || documents.Count == 0)
            {
                //Błąd
                return BadRequest("Document object is null!");
            }

            Document document = documents[0];

            return File(document.content, "application/pdf", document.name);
        }

        // Pobierz dokumenty posortowane według daty dla danego UserId
        [HttpGet("ForUser/getDocumentsSortedByDate{descending}")]

        public async Task<object> getDocumentsSortedByDateForUser(bool descending, int userId)
        {
            var response = await _documentService.GetDocumentsByUserId(userId);

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


        // Wbybieramy dokumnt o document_id z bazy danych. Następnie zmieniamy stan signed na true, czyli dokument został podpisany. 
        // Istnieje możliwość dodawania napisu do pliku pdf [JESZCZE NIE DZIAŁA].
        [HttpPost]
        [Route("sign/document/bitmap/{document_id}")]
        public async Task<object> SignDocumentBitmap(int document_id, [FromBody] BitmapDataRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.BitmapData))
            {
                return BadRequest("Nieprawidłowe żądanie");
            }

            // Tutaj możesz umieścić logikę przetwarzania danych bitmapy
            try
            {

                Result<Document> response = await _documentService.GetDocumentById(document_id);

                if (response.IsFailure)
                {
                    return response.ToProblemDetails();
                }

                Document document = response.Value;

                //Podpisanie bool'a
                document.signed = true;

                // Przykładowa logika przetwarzania danych bitmapy
                //var signingDocument = new SigningDocument(document);
                //signingDocument.SignDocument(request);

                _documentService.Update(document);
                
                return Ok("Pomyślnie podpisano dokument");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Wystąpił błąd podczas przetwarzania danych bitmapy: {ex.Message}");
            }
        }

        //Dodaj dokument do bazy danych.
        [HttpPost]
        [Route("/AddDocumentToDb")]
        public async Task<IActionResult> AddDocumentToDb([FromBody] DocumentDto document)
        {
            if (document == null)
            {
                return BadRequest("Document object is null");
            }

            try
            {
                // Dodanie dokumentu do kontekstu bazy danych
                await _documentService.AddDocument(document);

                // Zwrócenie odpowiedzi z sukcesem
                return Ok("Document created successfully");
            }
            catch (Exception ex)
            {
                // Jeśli wystąpił błąd podczas zapisywania dokumentu do bazy danych, zwróć błąd
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Generuje plik pdf. Przyjmuje wartości name, Date, Descpriton oraz Lines. Lines jest tutaj najważniejsza rzeczą. Jest to treść któa znajduje się w pliku. Name oznacza nazwę dokumentu która znajduje się w pliku pdf.
        [HttpPost("generate")]
        public async Task<IActionResult> GeneratePdf([FromBody] GeneratePdfRequest request)
        {
            var lines = request.Lines;

            if (lines == null || lines.Count == 0)
                return BadRequest("Lista linii tekstu nie może być pusta");

            var pdfDocument = new PdfDocument();
            var pdfPage = pdfDocument.AddPage();
            var graph = XGraphics.FromPdfPage(pdfPage);
            var font = new XFont("Verdana", 12, XFontStyle.Regular);
            var titleFont = new XFont("Verdana", 16, XFontStyle.Bold);
            var dateFont = new XFont("Verdana", 10, XFontStyle.Regular);

            double margin = 10;
            double yPos = margin; // Początkowa pozycja Y tekstu
            double availableWidth = pdfPage.Width - 2 * margin; // Dostępna szerokość na tekst

            // Dodanie daty i miejscowości w prawym górnym rogu
            string location = "Warszawa ul. Koszykowa 63";
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            XSize locationSize = graph.MeasureString(location, dateFont);
            XSize dateSize = graph.MeasureString(date, dateFont);

            graph.DrawString(location, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - locationSize.Width, yPos));
            graph.DrawString(date, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - dateSize.Width, yPos + dateSize.Height + 2));
            yPos += dateSize.Height * 2 + 20;

            // Dodanie tytułu dokumentu na środku
            string title = "Tytuł Dokumentu";
            XSize titleSize = graph.MeasureString(title, titleFont);
            graph.DrawString(title, titleFont, XBrushes.Black, new XPoint((pdfPage.Width - titleSize.Width) / 2, yPos));
            yPos += titleSize.Height + 20;

            // Dodanie treści dokumentu (lines)
            foreach (var line in lines)
            {
                var words = line.Split(' ');
                var currentLine = "";
                foreach (var word in words)
                {
                    var testLine = currentLine + (currentLine.Length > 0 ? " " : "") + word;
                    var size = graph.MeasureString(testLine, font);

                    if (size.Width > availableWidth)
                    {
                        // Sprawdzenie, czy dodanie kolejnej linii tekstu przekroczy wysokość strony
                        if (yPos + size.Height > pdfPage.Height - margin - 40) // 40 dla pola podpisu
                        {
                            // Dodanie nowej strony
                            pdfPage = pdfDocument.AddPage();
                            graph = XGraphics.FromPdfPage(pdfPage);
                            yPos = margin; // Resetowanie pozycji Y tekstu

                            // Dodanie daty i miejscowości na nowej stronie
                            graph.DrawString(location, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - locationSize.Width, yPos));
                            graph.DrawString(date, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - dateSize.Width, yPos + dateSize.Height + 2));
                            yPos += dateSize.Height * 2 + 20;
                        }

                        // Dodanie aktualnej linii do strony PDF
                        graph.DrawString(currentLine, font, XBrushes.Black, new XPoint(margin, yPos));
                        yPos += size.Height;
                        currentLine = word;
                    }
                    else
                    {
                        currentLine = testLine;
                    }
                }

                // Dodanie pozostałej części linii
                if (!string.IsNullOrEmpty(currentLine))
                {
                    var size = graph.MeasureString(currentLine, font);
                    if (yPos + size.Height > pdfPage.Height - margin - 40) // 40 dla pola podpisu
                    {
                        // Dodanie nowej strony
                        pdfPage = pdfDocument.AddPage();
                        graph = XGraphics.FromPdfPage(pdfPage);
                        yPos = margin; // Resetowanie pozycji Y tekstu

                        // Dodanie daty i miejscowości na nowej stronie
                        graph.DrawString(location, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - locationSize.Width, yPos));
                        graph.DrawString(date, dateFont, XBrushes.Black, new XPoint(pdfPage.Width - margin - dateSize.Width, yPos + dateSize.Height + 2));
                        yPos += dateSize.Height * 2 + 20;
                    }

                    graph.DrawString(currentLine, font, XBrushes.Black, new XPoint(margin, yPos));
                    yPos += size.Height;
                }
            }

            // Dodanie pola do podpisu na samym dole po prawej stronie
            string signaturePlaceholder = "_______________________\nPodpis";
            XSize signatureSize = graph.MeasureString(signaturePlaceholder, font);
            graph.DrawString(signaturePlaceholder, font, XBrushes.Black, new XPoint(pdfPage.Width - margin - signatureSize.Width, pdfPage.Height - margin - signatureSize.Height));

            using (var memoryStream = new MemoryStream())
            {
                pdfDocument.Save(memoryStream);
                var document = new Document
                {
                    name = request.name,
                    description = request.Description,
                    content = memoryStream.ToArray(),
                    signed = false,
                    creation_date = request.Date,
                    UserId = request.UserId
                };

                await _documentService.AddDocument(DocumentMapper.castDocumentToDtoDocument(document));

                return File(document.content, "application/pdf", document.name);
            }
        }

        //Wypisuje zawartość byte[]. Potrzebne do sprawdzania poprawonści formatu pdf wartości content.
        public static void PrintByteArray(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                Console.WriteLine("Array is empty or null.");
                return;
            }

            const int bytesPerLine = 16;
            for (int i = 0; i < byteArray.Length; i += bytesPerLine)
            {
                string line = string.Format("{0:X8}  ", i);
                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (i + j < byteArray.Length)
                        line += string.Format("{0:X2} ", byteArray[i + j]);
                    else
                        line += "   ";
                }

                line += " ";
                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (i + j < byteArray.Length)
                    {
                        char c = (char)byteArray[i + j];
                        if (char.IsControl(c))
                            c = '.';
                        line += c;
                    }
                }

                Console.WriteLine(line);
            }
        }

        //Ma za zadanie dodać do pliku content tekst. Coś ala podpis.
        public static async Task<byte[]> AddTextToPdf(byte[] content, string textToAdd)
        {
            try
            {
                //PrintByteArray(content);
                
                PdfDocument pdfDocument;
                using (var memoryStream = new MemoryStream(content))
                {
                    pdfDocument = PdfReader.Open(memoryStream, PdfDocumentOpenMode.Modify);
                }

                var font = new XFont("Verdana", 12, XFontStyle.Regular);


                foreach (var pdfPage in pdfDocument.Pages)
                {
                    var graph = XGraphics.FromPdfPage(pdfPage);

                    double xPos = 10;
                    double yPos = pdfPage.Height - 10;

                    graph.DrawString(textToAdd, font, XBrushes.Black, new XPoint(xPos, yPos));
                }

                using (var outputMemoryStream = new MemoryStream())
                {
                    pdfDocument.Save(outputMemoryStream);
                    return outputMemoryStream.ToArray();
                }
            }
            catch (PdfReaderException ex)
            {

                Console.WriteLine("Błąd: Nieprawidłowy plik PDF. " + ex.Message);
                return null; 
            }
            catch (Exception ex)
            {

                Console.WriteLine("Błąd: " + ex.Message);
                return null; 
            }
        }
        public class GeneratePdfRequest
        {
            public List<string> Lines { get; set; }
            public string Description { get; set; }
            public string name { get; set; }
            public DateTime Date { get; set; }
            public int UserId { get; set; }
        }

        public class SigningDocument
        {
            Document document;
            public SigningDocument(Document doc)
            {
                document = doc;
            }

            //Dodaje do pliku pdf (document.content) podpis czyli jakiś tam ciąg znaków z request.
            public async Task SignDocument(BitmapDataRequest request)
            {
                byte[] modifiedPdfContent = await AddTextToPdf(document.content, request.BitmapData);

                if (modifiedPdfContent != null)
                {
                    document.content = modifiedPdfContent;
                    // Kontynuuj przetwarzanie, np. zapisz zaktualizowany dokument do bazy danych
                }
                else
                {
                    // Obsłuż sytuację, gdy PDF nie został poprawnie zaktualizowany
                    Console.WriteLine("Nie udało się dodać podpisu do dokumentu.");
                }

            }
        }

        public class BitmapDataRequest
        {
            public string BitmapData { get; set; }
        }
    }
}

