using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosDataTransfers;
using rcDominiosWeb.Models;

namespace rcDominiosWeb.Controllers
{
    public class CorController : Controller
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
            CorModel corModel;
            CorDataTransfer corForm;

            try {
                corModel = new CorModel();

                if (id > 0) {
                    corForm = corModel.ConsultarPorId(id);
                } else {
                    corForm = null;
                }
            } catch {
                corForm = new CorDataTransfer();
                
                corForm.Validacao = false;
                corForm.Erro = true;
                corForm.ErroMensagens.Add("Erro em CorController Form");
            } finally {
                corModel = null;
            }

            return View(corForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            CorModel corModel;
            CorDataTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Listar();
            } catch (Exception ex) {
                corLista = new CorDataTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.ErroMensagens.Add("Erro em CorController Lista [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            return View(corLista);
        }

        [HttpPost]
        public IActionResult Consulta(CorDataTransfer corDataTransfer)
        {
            CorModel corModel;
            CorDataTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Consultar(corDataTransfer);
            } catch (Exception ex) {
                corLista = new CorDataTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.ErroMensagens.Add("Erro em CorController Consulta [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corLista.Erro || !corLista.Validacao) {
                return View("Filtro", corLista);
            } else {
                return View("Lista", corLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(CorDataTransfer corDataTransfer)
        {
            CorModel corModel;
            CorDataTransfer corRetorno;

            try {
                corModel = new CorModel();

                corRetorno = corModel.Incluir(corDataTransfer);
            } catch (Exception ex) {
                corRetorno = new CorDataTransfer();

                corRetorno.Validacao = false;
                corRetorno.Erro = true;
                corRetorno.ErroMensagens.Add("Erro em CorController Inclusao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return View("Form", corRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public IActionResult Alteracao(CorDataTransfer corDataTransfer)
        {
            CorModel corModel;
            CorDataTransfer corRetorno;

            try {
                corModel = new CorModel();

                corRetorno = corModel.Alterar(corDataTransfer);
            } catch (Exception ex) {
                corRetorno = new CorDataTransfer();

                corRetorno.Validacao = false;
                corRetorno.Erro = true;
                corRetorno.ErroMensagens.Add("Erro em CorController Alteracao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return View("Form", corRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public IActionResult Exclusao(int id)
        {
            CorModel corModel;
            CorDataTransfer corRetorno;

            try {
                corModel = new CorModel();

                corRetorno = corModel.Excluir(id);
            } catch (Exception ex) {
                corRetorno = new CorDataTransfer();

                corRetorno.Validacao = false;
                corRetorno.Erro = true;
                corRetorno.ErroMensagens.Add("Erro em CorController Exclusao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return View("Form", corRetorno);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
