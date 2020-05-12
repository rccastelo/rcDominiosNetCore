using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

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
        public IActionResult Form(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoForm;

            try {
                profissaoModel = new ProfissaoModel();

                if (id > 0) {
                    profissaoForm = profissaoModel.ConsultarPorId(id);
                } else {
                    profissaoForm = null;
                }
            } catch {
                profissaoForm = new ProfissaoDataTransfer();
                
                profissaoForm.Validacao = false;
                profissaoForm.Erro = true;
                profissaoForm.ErroMensagens.Add("Erro em ProfissaoController Form");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Listar();
            } catch (Exception ex) {
                profissaoLista = new ProfissaoDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em ProfissaoController Lista [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        public IActionResult Consulta(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Consultar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em ProfissaoController Consulta [" + ex.Message + "]");
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
        public IActionResult Inclusao(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Incluir(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Inclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Alterar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Alteracao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Exclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return View("Form", profissaoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
