using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class ContaBancariaController : Controller
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
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaForm;

            try {
                contaBancariaModel = new ContaBancariaModel();

                if (id > 0) {
                    contaBancariaForm = contaBancariaModel.ConsultarPorId(id);
                } else {
                    contaBancariaForm = null;
                }
            } catch {
                contaBancariaForm = new ContaBancariaDataTransfer();
                
                contaBancariaForm.Validacao = false;
                contaBancariaForm.Erro = true;
                contaBancariaForm.IncluirErroMensagem("Erro em ContaBancariaController Form");
            } finally {
                contaBancariaModel = null;
            }

            return View(contaBancariaForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = contaBancariaModel.Listar();
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaDataTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaController Lista [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            return View(contaBancariaLista);
        }

        [HttpPost]
        public IActionResult Consulta(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = contaBancariaModel.Consultar(contaBancariaDataTransfer);
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaDataTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaController Consulta [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaLista.Erro || !contaBancariaLista.Validacao) {
                return View("Filtro", contaBancariaLista);
            } else {
                return View("Lista", contaBancariaLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Incluir(contaBancariaDataTransfer);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Inclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return View("Form", contaBancariaRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Alterar(contaBancariaDataTransfer);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Alteracao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return View("Form", contaBancariaRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Excluir(id);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Exclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return View("Form", contaBancariaRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
