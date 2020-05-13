using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class TelefoneTipoController : Controller
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
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoForm;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                if (id > 0) {
                    telefoneTipoForm = telefoneTipoModel.ConsultarPorId(id);
                } else {
                    telefoneTipoForm = null;
                }
            } catch {
                telefoneTipoForm = new TelefoneTipoDataTransfer();
                
                telefoneTipoForm.Validacao = false;
                telefoneTipoForm.Erro = true;
                telefoneTipoForm.ErroMensagens.Add("Erro em TelefoneTipoController Form");
            } finally {
                telefoneTipoModel = null;
            }

            return View(telefoneTipoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = telefoneTipoModel.Listar();
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoDataTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.ErroMensagens.Add("Erro em TelefoneTipoController Lista [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            return View(telefoneTipoLista);
        }

        [HttpPost]
        public IActionResult Consulta(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoLista;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoLista = telefoneTipoModel.Consultar(telefoneTipoDataTransfer);
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoDataTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.ErroMensagens.Add("Erro em TelefoneTipoController Consulta [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoLista.Erro || !telefoneTipoLista.Validacao) {
                return View("Filtro", telefoneTipoLista);
            } else {
                return View("Lista", telefoneTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Incluir(telefoneTipoDataTransfer);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Inclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return View("Form", telefoneTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Alterar(telefoneTipoDataTransfer);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Alteracao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return View("Form", telefoneTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            TelefoneTipoModel telefoneTipoModel;
            TelefoneTipoDataTransfer telefoneTipoRetorno;

            try {
                telefoneTipoModel = new TelefoneTipoModel();

                telefoneTipoRetorno = telefoneTipoModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoRetorno.Validacao = false;
                telefoneTipoRetorno.Erro = true;
                telefoneTipoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Exclusao [" + ex.Message + "]");
            } finally {
                telefoneTipoModel = null;
            }

            if (telefoneTipoRetorno.Erro || !telefoneTipoRetorno.Validacao) {
                return View("Form", telefoneTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
