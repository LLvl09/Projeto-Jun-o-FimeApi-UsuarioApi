using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Services;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [Route("/solicita-reset")]
        [HttpPost]
        public IActionResult SolicitaReset(SolicitaResetRequest request)
        {
            Result resultado = _loginService.SolicitaReset(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }

        [Route("/efetua-reset")]
        [HttpPost]
        public IActionResult EfetuaReset(EfetuaResetRequest request)
        {
            Result resultado = _loginService.EfetuaReset(request);
            if (resultado.IsFailed) return Unauthorized(resultado.Errors);
            return Ok(resultado.Successes);
        }
    }
}
