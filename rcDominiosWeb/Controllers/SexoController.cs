using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class SexoController : Controller
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
            SexoModel sexoModel;
            SexoDataTransfer sexoForm;

            try {
                sexoModel = new SexoModel();

                if (id > 0) {
                    sexoForm = sexoModel.ConsultarPorId(id);
                } else {
                    sexoForm = null;
                }
            } catch {
                sexoForm = new SexoDataTransfer();
                
                sexoForm.Validacao = false;
                sexoForm.Erro = true;
                sexoForm.ErroMensagens.Add("Erro em SexoController Form");
            } finally {
                sexoModel = null;
            }

            return View(sexoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Listar();
            } catch (Exception ex) {
                sexoLista = new SexoDataTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.ErroMensagens.Add("Erro em SexoController Lista [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            return View(sexoLista);
        }

        [HttpPost]
        public IActionResult Consulta(SexoDataTransfer sexoDataTransfer)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Consultar(sexoDataTransfer);
            } catch (Exception ex) {
                sexoLista = new SexoDataTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.ErroMensagens.Add("Erro em SexoController Consulta [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return View("Filtro", sexoLista);
            } else {
                return View("Lista", sexoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(SexoDataTransfer sexoDataTransfer)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Incluir(sexoDataTransfer);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Inclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return View("Form", sexoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(SexoDataTransfer sexoDataTransfer)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Alterar(sexoDataTransfer);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Alteracao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return View("Form", sexoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Excluir(id);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Exclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return View("Form", sexoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
