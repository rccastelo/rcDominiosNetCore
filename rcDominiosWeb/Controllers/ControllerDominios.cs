using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public abstract class ControllerDominios : Controller
    {
        protected readonly IHttpContextAccessor httpContext;

        protected string UsuarioNome;

        protected ControllerDominios(IHttpContextAccessor accessor)
        {
            httpContext = accessor;

            UsuarioNome = "";

            ObterUsuario();
        }

        protected void ObterUsuario() {
            AutenticaModel autenticaModel;
            string usuario = "";

            try {
                autenticaModel = new AutenticaModel(httpContext);

                usuario = autenticaModel.ObterUsuario();
            } catch {
                usuario = "";
            } finally {
                autenticaModel = null;
            }

            UsuarioNome = usuario;
        }
    }
}