using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

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
        public async Task<IActionResult> Form(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                if (id > 0) {
                    contaBancaria = await contaBancariaModel.ConsultarPorId(id);
                } else {
                    contaBancaria = null;
                }
            } catch {
                contaBancaria = new ContaBancariaTransfer();
                
                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaController Form");
            } finally {
                contaBancariaModel = null;
            }

            return View(contaBancaria);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = await contaBancariaModel.Consultar(new ContaBancariaTransfer());
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaController Lista [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            return View(contaBancariaLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = await contaBancariaModel.Consultar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

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
        public async Task<IActionResult> Inclusao(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = await contaBancariaModel.Incluir(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaController Inclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = await contaBancariaModel.Alterar(contaBancariaTransfer);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaController Alteracao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancaria = await contaBancariaModel.Excluir(id);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirErroMensagem("Erro em ContaBancariaController Exclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancaria.Erro || !contaBancaria.Validacao) {
                return View("Form", contaBancaria);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
