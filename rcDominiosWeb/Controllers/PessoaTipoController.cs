using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Controllers
{
    public class PessoaTipoController : Controller
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
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                if (id > 0) {
                    pessoaTipo = await pessoaTipoService.ConsultarPorId(id);
                } else {
                    pessoaTipo = null;
                }
            } catch {
                pessoaTipo = new PessoaTipoTransfer();
                
                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Form");
            } finally {
                pessoaTipoService = null;
            }

            return View(pessoaTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoListaTransfer pessoaTipoLista;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoLista = await pessoaTipoService.Consultar(new PessoaTipoListaTransfer());
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoListaTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoController Lista [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return View(pessoaTipoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(PessoaTipoListaTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoListaTransfer pessoaTipoLista;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoLista = await pessoaTipoService.Consultar(pessoaTipoListaTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoListaTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoController Consulta [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return View("Filtro", pessoaTipoLista);
            } else {
                return View("Lista", pessoaTipoLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Incluir(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Inclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Alterar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Alteracao [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Exclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return View("Form", pessoaTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
