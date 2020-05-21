using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Controllers
{
  public class ProfissaoController : Controller
    {
        [HttpGet, HttpPost]
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
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;

            try {
                profissaoService = new ProfissaoService();

                if (id > 0) {
                    profissao = await profissaoService.ConsultarPorId(id);
                } else {
                    profissao = null;
                }
            } catch {
                profissao = new ProfissaoTransfer();
                
                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Form");
            } finally {
                profissaoService = null;
            }

            return View(profissao);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ProfissaoService profissaoService;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoService = new ProfissaoService();

                profissaoLista = await profissaoService.Consultar(new ProfissaoListaTransfer());
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Lista [" + ex.Message + "]");
            } finally {
                profissaoService = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(ProfissaoListaTransfer profissaoListaTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoService = new ProfissaoService();

                profissaoLista = await profissaoService.Consultar(profissaoListaTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Consulta [" + ex.Message + "]");
            } finally {
                profissaoService = null;
            }

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return View("Filtro", profissaoLista);
            } else {
                return View("Lista", profissaoLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;

            try {
                profissaoService = new ProfissaoService();

                profissao = await profissaoService.Incluir(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Inclusao [" + ex.Message + "]");
            } finally {
                profissaoService = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return View("Form", profissao);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;

            try {
                profissaoService = new ProfissaoService();

                profissao = await profissaoService.Alterar(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Alteracao [" + ex.Message + "]");
            } finally {
                profissaoService = null;
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
            ProfissaoService profissaoService;
            ProfissaoTransfer profissao;

            try {
                profissaoService = new ProfissaoService();

                profissao = await profissaoService.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Exclusao [" + ex.Message + "]");
            } finally {
                profissaoService = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return View("Form", profissao);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
