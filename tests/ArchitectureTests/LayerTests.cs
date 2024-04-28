using Domain.Models.Identity;
using FluentAssertions;
using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTests
{
    public class LayerTests
    {
        public static readonly Assembly DomainAssembly = typeof(User).Assembly;

        [Fact]
        public void Domain_Should_NotHaveDependencyOnApplication()
        {
            // Arrange
            //Assembly[] allAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            ////Assembly[] domainAssemblies = Array.FindAll(allAssemblies, assembly => //
            // assembly.FullName.Contains("Domain")); // Act

            // Assert
            var Result = Types.InAssembly(DomainAssembly).Should().NotHaveDependencyOn("App").GetResult();
            Result.IsSuccessful.Should().BeTrue();
        }
    }
}