using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NerdStoreEnterprise.WebApp.MVC.Extensions
{
    public interface IUser
    {
        string Nome { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObetrUserToken();
        bool EstaAutenticado();
        bool PossuiRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();
    }
}
