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
            PessoaTipoService pessoaTipoService = null;
            PessoaTipoDataTransfer pessoaTipo = null;

            try {
                if (id > 0) {
                    pessoaTipoService = new PessoaTipoService();
                    pessoaTipo = await pessoaTipoService.ConsultarPorId(id);
                } else {
                    pessoaTipo = null;
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();
                
                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoController Form [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return View(pessoaTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoDataTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Listar();
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoController Lista [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            return View(pessoaTipo);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoDataTransfer pessoaTipoLista;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoLista = await pessoaTipoService.Consultar(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoDataTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Consulta [" + ex.Message + "]");
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
        public async Task<IActionResult> Inclusao(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoDataTransfer pessoaTipoInclusao;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoInclusao = await pessoaTipoService.Incluir(pessoaTipoForm);
            } catch (Exception ex) {
                pessoaTipoInclusao = new PessoaTipoDataTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.ErroMensagens.Add("Erro em PessoaTipoController Inclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipoInclusao.Erro || !pessoaTipoInclusao.Validacao) {
                return View("Form", pessoaTipoInclusao);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(PessoaTipoDataTransfer pessoaTipoForm)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoDataTransfer pessoaTipoInclusao;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipoInclusao = await pessoaTipoService.Alterar(pessoaTipoForm);
            } catch (Exception ex) {
                pessoaTipoInclusao = new PessoaTipoDataTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.ErroMensagens.Add("Erro em PessoaTipoController Alteracao [" + ex.Message + "]");
            } finally {
                pessoaTipoService = null;
            }

            if (pessoaTipoInclusao.Erro || !pessoaTipoInclusao.Validacao) {
                return View("Form", pessoaTipoInclusao);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            PessoaTipoService pessoaTipoService;
            PessoaTipoDataTransfer pessoaTipo;

            try {
                pessoaTipoService = new PessoaTipoService();

                pessoaTipo = await pessoaTipoService.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoDataTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.ErroMensagens.Add("Erro em PessoaTipoController Exclusao [" + ex.Message + "]");
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
