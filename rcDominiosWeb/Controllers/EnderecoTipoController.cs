using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class EnderecoTipoController : Controller
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
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoForm;

            try {
                enderecoModel = new EnderecoTipoModel();

                if (id > 0) {
                    enderecoForm = enderecoModel.ConsultarPorId(id);
                } else {
                    enderecoForm = null;
                }
            } catch {
                enderecoForm = new EnderecoTipoDataTransfer();
                
                enderecoForm.Validacao = false;
                enderecoForm.Erro = true;
                enderecoForm.IncluirErroMensagem("Erro em EnderecoTipoController Form");
            } finally {
                enderecoModel = null;
            }

            return View(enderecoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoLista;

            try {
                enderecoModel = new EnderecoTipoModel();

                enderecoLista = enderecoModel.Listar();
            } catch (Exception ex) {
                enderecoLista = new EnderecoTipoDataTransfer();

                enderecoLista.Validacao = false;
                enderecoLista.Erro = true;
                enderecoLista.IncluirErroMensagem("Erro em EnderecoTipoController Lista [" + ex.Message + "]");
            } finally {
                enderecoModel = null;
            }

            return View(enderecoLista);
        }

        [HttpPost]
        public IActionResult Consulta(EnderecoTipoDataTransfer enderecoDataTransfer)
        {
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoLista;

            try {
                enderecoModel = new EnderecoTipoModel();

                enderecoLista = enderecoModel.Consultar(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoLista = new EnderecoTipoDataTransfer();

                enderecoLista.Validacao = false;
                enderecoLista.Erro = true;
                enderecoLista.IncluirErroMensagem("Erro em EnderecoTipoController Consulta [" + ex.Message + "]");
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
        public IActionResult Inclusao(EnderecoTipoDataTransfer enderecoDataTransfer)
        {
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new EnderecoTipoModel();

                enderecoRetorno = enderecoModel.Incluir(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoRetorno = new EnderecoTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Inclusao [" + ex.Message + "]");
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
        public IActionResult Alteracao(EnderecoTipoDataTransfer enderecoDataTransfer)
        {
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new EnderecoTipoModel();

                enderecoRetorno = enderecoModel.Alterar(enderecoDataTransfer);
            } catch (Exception ex) {
                enderecoRetorno = new EnderecoTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Alteracao [" + ex.Message + "]");
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
            EnderecoTipoModel enderecoModel;
            EnderecoTipoDataTransfer enderecoRetorno;

            try {
                enderecoModel = new EnderecoTipoModel();

                enderecoRetorno = enderecoModel.Excluir(id);
            } catch (Exception ex) {
                enderecoRetorno = new EnderecoTipoDataTransfer();

                enderecoRetorno.Validacao = false;
                enderecoRetorno.Erro = true;
                enderecoRetorno.IncluirErroMensagem("Erro em EnderecoTipoController Exclusao [" + ex.Message + "]");
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
