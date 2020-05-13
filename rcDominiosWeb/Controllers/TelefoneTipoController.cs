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
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoForm;

            try {
                enderecoModel = new TelefoneTipoModel();

                if (id > 0) {
                    enderecoForm = enderecoModel.ConsultarPorId(id);
                } else {
                    enderecoForm = null;
                }
            } catch {
                enderecoForm = new TelefoneTipoDataTransfer();
                
                enderecoForm.Validacao = false;
                enderecoForm.Erro = true;
                enderecoForm.ErroMensagens.Add("Erro em TelefoneTipoController Form");
            } finally {
                enderecoModel = null;
            }

            return View(enderecoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoLista;

            try {
                enderecoModel = new TelefoneTipoModel();

                enderecoLista = enderecoModel.Listar();
            } catch (Exception ex) {
                enderecoLista = new TelefoneTipoDataTransfer();

                enderecoLista.Validacao = false;
                enderecoLista.Erro = true;
                enderecoLista.ErroMensagens.Add("Erro em TelefoneTipoController Lista [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            return View(enderecoLista);
        }

        [HttpPost]
        public IActionResult Consulta(TelefoneTipoDataTransfer enderecoDataTransfer)
        {
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoLista;

            try {
                enderecoModel = new TelefoneTipoModel();

                enderecoLista = enderecoModel.Consultar(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoLista = new TelefoneTipoDataTransfer();

                enderecoLista.Validacao = false;
                enderecoLista.Erro = true;
                enderecoLista.ErroMensagens.Add("Erro em TelefoneTipoController Consulta [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            if (enderecoLista.Erro || !enderecoLista.Validacao) {
                return View("Filtro", enderecoLista);
            } else {
                return View("Lista", enderecoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(TelefoneTipoDataTransfer enderecoDataTransfer)
        {
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new TelefoneTipoModel();

                enderecoRetorno = enderecoModel.Incluir(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoRetorno = new TelefoneTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Inclusao [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            if (enderecoRetorno.Erro || !enderecoRetorno.Validacao) {
                return View("Form", enderecoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(TelefoneTipoDataTransfer enderecoDataTransfer)
        {
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new TelefoneTipoModel();

                enderecoRetorno = enderecoModel.Alterar(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoRetorno = new TelefoneTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Alteracao [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            if (enderecoRetorno.Erro || !enderecoRetorno.Validacao) {
                return View("Form", enderecoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            TelefoneTipoModel enderecoModel;
            TelefoneTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new TelefoneTipoModel();

                enderecoRetorno = enderecoModel.Excluir(id);
            } catch (Exception ex) {
                enderecoRetorno = new TelefoneTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.ErroMensagens.Add("Erro em TelefoneTipoController Exclusao [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            if (enderecoRetorno.Erro || !enderecoRetorno.Validacao) {
                return View("Form", enderecoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
