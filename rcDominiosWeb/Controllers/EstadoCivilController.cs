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
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilForm;

            try {
                estadoCivilModel = new EstadoCivilModel();

                if (id > 0) {
                    estadoCivilForm = estadoCivilModel.ConsultarPorId(id);
                } else {
                    estadoCivilForm = null;
                }
            } catch {
                estadoCivilForm = new EstadoCivilDataTransfer();
                
                estadoCivilForm.Validacao = false;
                estadoCivilForm.Erro = true;
                estadoCivilForm.ErroMensagens.Add("Erro em EstadoCivilController Form");
            } finally {
                estadoCivilModel = null;
            }

            return View(estadoCivilForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilLista = estadoCivilModel.Listar();
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilDataTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.ErroMensagens.Add("Erro em EstadoCivilController Lista [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            return View(estadoCivilLista);
        }

        [HttpPost]
        public IActionResult Consulta(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilLista;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilLista = estadoCivilModel.Consultar(estadoCivilDataTransfer);
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilDataTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.ErroMensagens.Add("Erro em EstadoCivilController Consulta [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilLista.Erro || !estadoCivilLista.Validacao) {
                return View("Filtro", estadoCivilLista);
            } else {
                return View("Lista", estadoCivilLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Incluir(estadoCivilDataTransfer);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Inclusao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return View("Form", estadoCivilRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Alterar(estadoCivilDataTransfer);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Alteracao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return View("Form", estadoCivilRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            EstadoCivilModel estadoCivilModel;
            EstadoCivilDataTransfer estadoCivilRetorno;

            try {
                estadoCivilModel = new EstadoCivilModel();

                estadoCivilRetorno = estadoCivilModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivilRetorno = new EstadoCivilDataTransfer();

                estadoCivilRetorno.Validacao = false;
                estadoCivilRetorno.Erro = true;
                estadoCivilRetorno.ErroMensagens.Add("Erro em EstadoCivilController Exclusao [" + ex.Message + "]");
            } finally {
                estadoCivilModel = null;
            }

            if (estadoCivilRetorno.Erro || !estadoCivilRetorno.Validacao) {
                return View("Form", estadoCivilRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
