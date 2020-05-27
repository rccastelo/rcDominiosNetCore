using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace rcDominiosWeb.Controllers
{
    [Authorize]
    public class SexoController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

        public SexoController(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Filtro()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel(httpContext);

                if (id > 0) {
                    sexo = await sexoModel.ConsultarPorId(id);
                } else {
                    sexo = null;
                }
            } catch {
                sexo = new SexoTransfer();
                
                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoController Form");
            } finally {
                sexoModel = null;
            }

            return View(sexo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel(httpContext);

                sexoLista = await sexoModel.Consultar(new SexoTransfer());
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirErroMensagem("Erro em SexoController Lista [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            return View(sexoLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel(httpContext);

                sexoLista = await sexoModel.Consultar(sexoTransfer);
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirErroMensagem("Erro em SexoController Consulta [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return View("Filtro", sexoLista);
            } else {
                return View("Lista", sexoLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel(httpContext);

                sexo = await sexoModel.Incluir(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoController Inclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return View("Form", sexo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel(httpContext);

                sexo = await sexoModel.Alterar(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoController Alteracao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return View("Form", sexo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel(httpContext);

                sexo = await sexoModel.Excluir(id);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirErroMensagem("Erro em SexoController Exclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return View("Form", sexo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
