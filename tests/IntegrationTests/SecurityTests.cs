﻿using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Domain;
using Domain.ExternalInterfaces;
using Domain.IRepositories;
using FluentAssertions;
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
    public ProductTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_Account_Success()
    {
        //Arrange generated by chat gtp
        var userDto = new RegisterDTO
        {
            Email = "jane.doe@example.com", // zmieniony adres email
            Password = "SecurePass!2024", // zmienione hasło
            Name = "Jane", // zmienione imię
            Surname = "Doe", // zmienione nazwisko
            PostalCode = "00-001", // przykładowy kod pocztowy
            Street = "Main Street", // przykładowa ulica
            BuildingNumber = "24", // przykładowy numer budynku
            ApartmentNumber = "5", // przykładowy numer mieszkania
            Floor = 3, // przykładowe piętro
            Nickname = "jdoe", // przykładowy pseudonim
            PhoneNumber = "123-456-789" // przykładowy numer telefonu
        };

        // Act
        var result = await _securityService.CreateAccount(userDto);

        // Assert Assert.True(result.IsSuccess); Assert.Equal(newUserId.Id, result.Value.ToString());

        var data = DbContext.UsersInfo.Where(u => u.Email == "jane.doe@example.com").Should().HaveCount(1);

        result.IsFailure.Should().Be(false);
    }

    [Fact]
    public async Task Login_Account_Success()
    {
        //Arrange generated by chat gtp

        var loginDTO = new LoginDTO
        {
            Email = "Admin123@gmail.com",
            Password = "Admin111@"
        };

        // Act
        var result = await _securityService.LoginAccount(loginDTO);

        // Assert

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBe(null);
    }

    [Fact]
    public async Task ForgotReset_Password_Success()
    {
        ForgotPasswordDTO forgotDTO = new() { Email = "Admin123@gmail.com" };

        var result = await _securityService.forgotPassword(forgotDTO);

        ResetPasswordDTO resetDTO = new() { Email = "Admin123@gmail.com", NewPassword = "Admin111@", ResetCode = result.Value };

        var resetresult = await _securityService.resetPassword(resetDTO);

        resetresult.IsSuccess.Should().BeTrue();

        var loginDTO = new LoginDTO
        {
            Email = "Admin123@gmail.com",
            Password = "Admin111@"
        };

        // Act
        var loginResult = await _securityService.LoginAccount(loginDTO);

        // Assert

        loginResult.IsSuccess.Should().BeTrue();
        // loginResult.Value.Should().NotBe(null);
    }
}