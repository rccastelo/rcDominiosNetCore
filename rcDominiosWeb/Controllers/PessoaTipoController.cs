using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosEntities;
using rcDominiosWeb.Models;

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
        public IActionResult Form(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoForm;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoForm = pessoaTipoModel.ConsultarPorId(id);
            } catch {
                pessoaTipoForm = new PessoaTipoDataTransfer();
                
                pessoaTipoForm.Validacao = false;
                pessoaTipoForm.Erro = true;
                pessoaTipoForm.ErroMensagens.Add("Erro em PessoaTipoController Form");
            } finally {
                pessoaTipoModel = null;
            }

            return View(pessoaTipoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Listar();
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoDataTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Lista [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            return View(pessoaTipoLista);
        }

        [HttpPost]
        public IActionResult Consulta(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoDataTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Consulta [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return View("Filtro", pessoaTipoLista);
            } else {
                return View("Lista", pessoaTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Incluir(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Inclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return View("Form", pessoaTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Alterar(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Alteracao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return View("Form", pessoaTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Exclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return View("Form", pessoaTipoRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
