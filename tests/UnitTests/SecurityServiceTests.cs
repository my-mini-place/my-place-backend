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

namespace UnitTests
{
    public class UnitTest1
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
    }
}