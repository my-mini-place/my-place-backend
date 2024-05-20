using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Api.Services;
using FluentAssertions;

namespace UnitTests.Document
{
    
    public class DocumentTests
    {
        [Fact]
        public async Task GetDocuments()
        {
            Console.WriteLine("WENT TO GetDocuments()");

            // Arrange
            var service = new DocumentService(null);

            // Act
            var result = await service.GetDocumentList();


            // Assert
            //result.IsSuccess.Should().BeFalse();
            //result.Error.Code.Should().Be("NoMonth");
        }
    }
}
