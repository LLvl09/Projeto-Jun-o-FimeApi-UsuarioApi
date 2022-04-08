using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class LoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager,
            TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded)
            {
                var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario => 
                    usuario.NormalizedUserName == request.Username.ToUpper());
                Token token = _tokenService.CreateToken(identityUser, _signInManager
                    .UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());
                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("Login falhou");
        }

        public Result EfetuaReset(EfetuaResetRequest request)
        {
            CustomIdentityUser usuarioIdentity = RecupetaUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
                .UserManager
                .ResetPasswordAsync(usuarioIdentity, request.Token, request.Password).Result;

            if (resultadoIdentity.Succeeded) return Result.Ok()
                    .WithSuccess("Senha redefinida com sucesso!");
            return Result.Fail("Houve um erro na operação");
        }

        public Result SolicitaReset(SolicitaResetRequest request)
        {
            CustomIdentityUser usuarioIdentity = RecupetaUsuarioPorEmail(request.Email);
            
            if (usuarioIdentity != null)
            {
                string codigodeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(usuarioIdentity).Result;

                return Result.Ok().WithSuccess(codigodeRecuperacao);
            }return Result.Fail("Falha ao solicitar redefinição");
        }


        private CustomIdentityUser RecupetaUsuarioPorEmail(string email)
        {
            return _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}
