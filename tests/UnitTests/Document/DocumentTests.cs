using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Services;
using Domain.IRepositories;
using FluentAssertions;
using Moq;
using Xunit;
using static Domain.Models.Document.DocumentModels;
using Domain;
using System.Linq.Expressions;
using System.Collections;



namespace UnitTests.DocumentTests
{
    
    public class DocumentTests
    {

        private readonly Mock<IDocumentRepository> _mockDocumentRepository;
        private readonly DocumentService _documentService;

        public DocumentTests()
        {
            _mockDocumentRepository = new Mock<IDocumentRepository>();
            _documentService = new DocumentService(_mockDocumentRepository.Object);
        }

        [Fact]
        public async Task GetDocumentsById_WrongIndex_ReturnsFailure()
        {
            Console.WriteLine("WENT TO GetDocumentsById()");

            // Arrange
            var service = new DocumentService(null);

            // Act
            var result = await service.GetDocumentById(-1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("Wrong index");
        }

        [Fact]
        public async Task GetDocuments_ReturnsDocuments()
        {
            // Arrange
            var documents = new List<Document>
        {
            new Document { DocumentId = 1 },
            new Document { DocumentId = 2 }
        };
            _mockDocumentRepository.Setup(repo => repo.GetAll(null, null)).ReturnsAsync(documents);

            // Act
            var result = await _documentService.GetDocuments();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(documents, result.Value);
        }

        [Fact]
        public async Task GetDocumentById_ReturnsDocument_WhenDocumentExists()
        {
            // Arrange
            var id = 1;
            var documents = new List<Document>
        {
            new Document { DocumentId = id , content = "" , creation_date = new DateTime(), description = "", name = "id1", signed=false},
            new Document { DocumentId = 2 , content = "" , creation_date = new DateTime(), description = "", name = "id1", signed=false}
        };

            Expression<Func<Document, bool>> expression = x => x.DocumentId == id;

            _mockDocumentRepository.Setup(repo => repo.GetAll(It.IsAny<Expression<Func<Document, bool>>>(), null))
                                   .ReturnsAsync(documents);

            // Act
            Result<Document> result = await _documentService.GetDocumentById(id);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(id, result.Value.DocumentId);
        }

        [Fact]
        public async Task GetDocumentById_ReturnsFailure_WhenDocumentDoesNotExist()
        {
            // Arrange
            var documentId = 1;
            Expression<Func<Document, bool>> expression = x => x.DocumentId == documentId;
            _mockDocumentRepository.Setup(repo => repo.GetAll(expression, null))
                                   .ReturnsAsync(new List<Document>());

            // Act
            Result<Document> result = await _documentService.GetDocumentById(documentId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.NotNull(result.Error);
            Assert.Equal("Couldn't find such document!", result.Error.Code);
        }

        [Fact]
        public async Task GetDocumentById_ReturnsFailure_WhenIdIsNegative()
        {
            // Arrange
            var documentId = -1;

            // Act
            Result<Document> result = await _documentService.GetDocumentById(documentId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Wrong index", result.Error.Code);

        }
    }
}
