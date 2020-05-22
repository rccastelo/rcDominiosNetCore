using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosDataTransfers;

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
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                if (id > 0) {
                    profissao = await profissaoModel.ConsultarPorId(id);
                } else {
                    profissao = null;
                }
            } catch {
                profissao = new ProfissaoTransfer();
                
                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Form");
            } finally {
                profissaoModel = null;
            }

            return View(profissao);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ProfissaoModel profissaoModel;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = await profissaoModel.Consultar(new ProfissaoListaTransfer());
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Lista [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(ProfissaoListaTransfer profissaoListaTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = await profissaoModel.Consultar(profissaoListaTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Consulta [" + ex.Message + "]");
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
        public async Task<IActionResult> Inclusao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = await profissaoModel.Incluir(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Inclusao [" + ex.Message + "]");
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
        public async Task<IActionResult> Alteracao(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = await profissaoModel.Alterar(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Alteracao [" + ex.Message + "]");
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
                profissaoModel = new ProfissaoModel();

                profissao = await profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Exclusao [" + ex.Message + "]");
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
