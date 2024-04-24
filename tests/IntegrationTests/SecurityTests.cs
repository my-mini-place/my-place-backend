using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using Infrastructure.Data;
using IntegrationTests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using My_Place_Backend.DTO.Auth;
using System.Reflection;

namespace Application.IntegrationTests;

public class ProductTests : BaseIntegrationTest
{
    private readonly Mock<IIdentityRepository> _identityRepoMock = new();

    private readonly Mock<IUserRepository> _userRepositoryMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly ISecurityService _securityService;

    public ProductTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
        _securityService = new SecurityService(
            _identityRepoMock.Object,
            It.IsAny<IEmailSender>(),
            _userRepositoryMock.Object,
            _mapperMock.Object);
    }

    //[Fact]
    //public async Task Create_Account_Success()
    //{
    //    // Arrange
    //    //var userDto = new RegisterDTO { Email = "test@example.com", Name = "Test User", Password = "password123" };
    //    //var newUserId = new ApplicationUser { Id = "newUserId" };

    // //// Act //var result = await _securityService.CreateAccount(userDto);

    //    //// Assert
    //    //Assert.True(result.IsSuccess);
    //    //Assert.Equal(newUserId.Id, result.Value.ToString());
    //}
}