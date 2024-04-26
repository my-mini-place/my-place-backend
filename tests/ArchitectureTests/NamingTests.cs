using Domain.Models.Identity;
using FluentAssertions;
using My_Place_Backend.DTO.AccountManagment;
using NetArchTest.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArchitectureTest
{
    public class NamingTests
    {
        public static readonly Assembly ApiAssembly = typeof(UserDTO).Assembly;

        [Fact]
        public void Naming_Rules_Test()
        {
        }
    }
}