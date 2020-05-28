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
    public class ProfissaoController : Controller
    {
        private readonly IHttpContextAccessor httpContext;

        public ProfissaoController(IHttpContextAccessor accessor)
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
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                if (id > 0) {
                    profissao = await profissaoModel.ConsultarPorId(id);
                } else {
                    profissao = null;
                }
            } catch {
                profissao = new ProfissaoTransfer();
                
                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Form");
            } finally {
                profissaoModel = null;
            }

            return View(profissao);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                profissaoLista = await profissaoModel.Consultar(new ProfissaoTransfer());
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoController Lista [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Consulta(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                profissaoLista = await profissaoModel.Consultar(profissaoTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoController Consulta [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return View("Filtro", profissaoLista);
            } else {
                return View("Lista", profissaoLista);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inclusao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                profissao = await profissaoModel.Incluir(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Inclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return View("Form", profissao);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alteracao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                profissao = await profissaoModel.Alterar(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Alteracao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return View("Form", profissao);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel(httpContext);

                profissao = await profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirMensagem("Erro em ProfissaoController Exclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return View("Form", profissao);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
