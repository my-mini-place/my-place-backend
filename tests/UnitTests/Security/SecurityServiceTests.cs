using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using FluentAssertions;
using Infrastructure.Data;
using Moq;
using My_Place_Backend.DTO.AccountManagment;
using My_Place_Backend.DTO.Auth;

namespace UnitTests.Security
{
    public class SecurityServiceTests
    {
        [Fact]
        public async Task CreateAccount_UserDtoIsNull_ReturnsFailure()
        {
            // Arrange
            var service = new SecurityService(null, null, null, null);

            // Act
            var result = await service.CreateAccount(null);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Code.Should().Be("userDTO");
        }

        [Fact]
        public async Task ForgotPassword_UserNotFound_ReturnsFailure()
        {
            // Arrange
            var identityRepoMock = new Mock<IIdentityRepository>();

            identityRepoMock.Setup(repo => repo.FindUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            var emailServiceMock = new Mock<IEmailSender>();
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var service = new SecurityService(identityRepoMock.Object, emailServiceMock.Object, userRepoMock.Object, mapperMock.Object);

            // Act
            var result = await service.forgotPassword(new ForgotPasswordDTO { Email = "test@example.com" });

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Type.Should().Be(Domain.Errors.ErrorType.Failure);
        }

        public async Task Login_UserNotFound_ReturnFailure()
        {
            // Arrange
            var identityRepository = new Mock<IIdentityRepository>();

            identityRepository.Setup(repo => repo.FindUserByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            var service = new SecurityService(identityRepository.Object, null, null, null);
            //Act
            var result = await service.LoginAccount(new LoginDTO { Email = "test@example.com", Password = "231" });

            // Assert
            result.IsFailure.Should().BeTrue();
        }
    }
}