using NerdStoreEnterprise.WebApp.MVC.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NerdStoreEnterprise.WebApp.MVC.Services
{
    public abstract class Service
    {
        protected bool TratarErrosResponse(HttpResponseMessage responseMessage) 
        {
            switch((int)responseMessage.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(responseMessage.StatusCode);

                case 400:
                    return false;
            }

            // garantir que o statuscode é um codigo de sucesso (da familia 200)
            responseMessage.EnsureSuccessStatusCode();

            return true;
        }
    }
}
