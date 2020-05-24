using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

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
        public async Task<IActionResult> Form(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                if (id > 0) {
                    enderecoTipo = await enderecoTipoModel.ConsultarPorId(id);
                } else {
                    enderecoTipo = null;
                }
            } catch {
                enderecoTipo = new EnderecoTipoTransfer();
                
                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Form");
            } finally {
                enderecoTipoModel = null;
            }

            return View(enderecoTipo);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoLista = await enderecoTipoModel.Consultar(new EnderecoTipoTransfer());
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoController Lista [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            return View(enderecoTipoLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipoLista;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipoLista = await enderecoTipoModel.Consultar(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipoLista = new EnderecoTipoTransfer();

                enderecoTipoLista.Validacao = false;
                enderecoTipoLista.Erro = true;
                enderecoTipoLista.IncluirErroMensagem("Erro em EnderecoTipoController Consulta [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipoLista.Erro || !enderecoTipoLista.Validacao) {
                return View("Filtro", enderecoTipoLista);
            } else {
                return View("Lista", enderecoTipoLista);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Inclusao(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = await enderecoTipoModel.Incluir(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Inclusao [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return View("Form", enderecoTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(EnderecoTipoTransfer enderecoTipoTransfer)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = await enderecoTipoModel.Alterar(enderecoTipoTransfer);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Alteracao [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return View("Form", enderecoTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            EnderecoTipoModel enderecoTipoModel;
            EnderecoTipoTransfer enderecoTipo;

            try {
                enderecoTipoModel = new EnderecoTipoModel();

                enderecoTipo = await enderecoTipoModel.Excluir(id);
            } catch (Exception ex) {
                enderecoTipo = new EnderecoTipoTransfer();

                enderecoTipo.Validacao = false;
                enderecoTipo.Erro = true;
                enderecoTipo.IncluirErroMensagem("Erro em EnderecoTipoController Exclusao [" + ex.Message + "]");
            } finally {
                enderecoTipoModel = null;
            }

            if (enderecoTipo.Erro || !enderecoTipo.Validacao) {
                return View("Form", enderecoTipo);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
