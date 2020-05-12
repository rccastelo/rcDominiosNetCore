using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class EstadoCivilController : Controller
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
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoForm;

            try {
                profissaoModel = new EstadoCivilModel();

                if (id > 0) {
                    profissaoForm = profissaoModel.ConsultarPorId(id);
                } else {
                    profissaoForm = null;
                }
            } catch {
                profissaoForm = new EstadoCivilDataTransfer();
                
                profissaoForm.Validacao = false;
                profissaoForm.Erro = true;
                profissaoForm.ErroMensagens.Add("Erro em EstadoCivilController Form");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoLista;

            try {
                profissaoModel = new EstadoCivilModel();

                profissaoLista = profissaoModel.Listar();
            } catch (Exception ex) {
                profissaoLista = new EstadoCivilDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em EstadoCivilController Lista [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            return View(profissaoLista);
        }

        [HttpPost]
        public IActionResult Consulta(EstadoCivilDataTransfer profissaoDataTransfer)
        {
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoLista;

            try {
                profissaoModel = new EstadoCivilModel();

                profissaoLista = profissaoModel.Consultar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoLista = new EstadoCivilDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em EstadoCivilController Consulta [" + ex.Message + "]");
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
        public IActionResult Inclusao(EstadoCivilDataTransfer profissaoDataTransfer)
        {
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoRetorno;

            try {
                profissaoModel = new EstadoCivilModel();

                profissaoRetorno = profissaoModel.Incluir(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new EstadoCivilDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em EstadoCivilController Inclusao [" + ex.Message + "]");
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
        public IActionResult Alteracao(EstadoCivilDataTransfer profissaoDataTransfer)
        {
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoRetorno;

            try {
                profissaoModel = new EstadoCivilModel();

                profissaoRetorno = profissaoModel.Alterar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new EstadoCivilDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em EstadoCivilController Alteracao [" + ex.Message + "]");
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
            EstadoCivilModel profissaoModel;
            EstadoCivilDataTransfer profissaoRetorno;

            try {
                profissaoModel = new EstadoCivilModel();

                profissaoRetorno = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissaoRetorno = new EstadoCivilDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em EstadoCivilController Exclusao [" + ex.Message + "]");
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
