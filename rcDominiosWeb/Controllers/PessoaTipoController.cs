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
            PessoaTipoModel pessoaTipoMD = new PessoaTipoModel();
            PessoaTipoDataTransfer pessoaTipoDT = new PessoaTipoDataTransfer();

            pessoaTipoDT.PessoaTipoLista = new List<PessoaTipoEntity>();
            PessoaTipoEntity ent = new PessoaTipoEntity();
            ent.Id = 12;
            ent.Descricao = "Descrição Um";
            ent.Codigo = "D-U";
            ent.Ativo = false;
            ent.Criacao = new DateTime(2020, 3, 24, 22, 42, 0);
            ent.Alteracao = new DateTime(2020, 3, 26, 22, 42, 0);

            pessoaTipoDT.PessoaTipoLista.Add(ent);

            return View(pessoaTipoDT);
        }

        public IActionResult Inclusao(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoInclusao;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoInclusao = pessoaTipoModel.Incluir(pessoaTipoDataTransfer);
            } catch {
                pessoaTipoInclusao = new PessoaTipoDataTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.ErroMensagens.Add("Erro em PessoaTipoController Inclusao");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoInclusao.Erro || pessoaTipoInclusao.Validacao) {
                return View("Form", pessoaTipoInclusao);
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
