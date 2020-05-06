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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Filtro()
        {
            return View();
        }

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

        public IActionResult Alteracao()
        {
            return RedirectToAction("Lista");
        }

        public IActionResult Exclusao()
        {
            return RedirectToAction("Lista");
        }

        public IActionResult Consulta()
        {
            return RedirectToAction("Lista");
        }
    }
}
