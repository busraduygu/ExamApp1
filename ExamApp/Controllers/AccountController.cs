﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.Controllers
{
    //[Authorize]
    //[ApiController]
    //[Route("[controller]")]
    public class AccountController : ControllerBase
    {
        //private IUserService _userService;
        //private IMapper _mapper;
        //private readonly AppSettings _appSettings;

        //public AccountController(
        //    IUserService userService,
        //    IMapper mapper,
        //    IOptions<AppSettings> appSettings)
        //{
        //    _userService = userService;
        //    _mapper = mapper;
        //    _appSettings = appSettings.Value;
        //}

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate(AuthenticateRequest model)
        //{
        //    var response = _userService.Authenticate(model);
        //    return Ok(response);
        //}

        //[AllowAnonymous]
        //[HttpPost("register")]
        //public IActionResult Register(RegisterRequest model)
        //{
        //    _userService.Register(model);
        //    return Ok(new { message = "Registration successful" });
        //}

    }
}
