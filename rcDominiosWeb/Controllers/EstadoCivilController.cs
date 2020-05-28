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
    public class EstadoCivilController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

        public EstadoCivilController(IHttpContextAccessor accessor)
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
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                if (id > 0) {
                    estadoCivil = await estadoCivilModel.ConsultarPorId(id);
                } else {
                    estadoCivil = null;
                }
            } catch {
                estadoCivil = new EstadoCivilTransfer();
                
                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Form");
            } finally {
                estadoCivilModel = null;
            }

            return View(estadoCivil);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                estadoCivilLista = await estadoCivilModel.Consultar(new EstadoCivilTransfer());
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilController Lista [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            return View(estadoCivilLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                estadoCivilLista = await estadoCivilModel.Consultar(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirMensagem("Erro em EstadoCivilController Consulta [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return View("Filtro", estadoCivilLista);
            } else {
                return View("Lista", estadoCivilLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                estadoCivil = await estadoCivilModel.Incluir(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Inclusao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return View("Form", estadoCivil);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                estadoCivil = await estadoCivilModel.Alterar(estadoCivilTransfer);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Alteracao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return View("Form", estadoCivil);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilModel = new EstadoCivilModel(httpContext);

                estadoCivil = await estadoCivilModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirMensagem("Erro em EstadoCivilController Exclusao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivil.Erro || !estadoCivil.Validacao) {
                return View("Form", estadoCivil);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
