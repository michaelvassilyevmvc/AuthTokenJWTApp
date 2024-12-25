﻿using Auth.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class AuthController(AccountService accountService): ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterUserRequest request)
    {
        accountService.Register(request.UserName, request.FirstName, request.Password);
        return NoContent();
    }

    [HttpPost("login")]
    public IActionResult Login(string userName, string password)
    {
        // implement token

        return Ok();
    }
}