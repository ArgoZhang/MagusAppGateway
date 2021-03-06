﻿#define DEBUG
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MagusAppGateway.Services.IServices;
using MagusAppGateway.Models.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MagusAppGateway.ConfigWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserEditDto dto)
        {
            return Json(await _userService.CreateUser(dto));
        }

        [HttpGet]
        public async Task<IActionResult> DisableUser([FromQuery]Guid id)
        {
            return Json(await _userService.DisableUser(id));
        }

        [HttpGet]
        public async Task<IActionResult> EnableUser([FromQuery]Guid id)
        {
            return Json(await _userService.EnableUser(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            return Json(await _userService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> GetUsers([FromBody]UserQueryDto dto)
        {
            return Json(await _userService.GetUsers(dto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UserEditDto dto)
        {
            return Json(await _userService.UpdateUser(dto));
        }

        [HttpPost]
        public async Task<IActionResult> ApplyToken([FromBody]ApplyTokenDto dto)
        {
            return Json(await _userService.ApplyToken(dto));
        }
    }
}