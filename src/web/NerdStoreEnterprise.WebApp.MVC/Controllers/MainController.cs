using Microsoft.AspNetCore.Mvc;
using NerdStoreEnterprise.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResultError resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                return true;
            }

            return false;
        }
    }
}
