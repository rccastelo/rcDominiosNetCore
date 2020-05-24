using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rcDominiosWeb.Models;
using rcDominiosTransfers;

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
        public async Task<IActionResult> Form(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                if (id > 0) {
                    cor = await corModel.ConsultarPorId(id);
                } else {
                    cor = null;
                }
            } catch {
                cor = new CorTransfer();
                
                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorController Form");
            } finally {
                corModel = null;
            }

            return View(cor);
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = await corModel.Consultar(new CorTransfer());
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirErroMensagem("Erro em CorController Lista [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            return View(corLista);
        }

        [HttpPost]
        public async Task<IActionResult> Consulta(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = await corModel.Consultar(corTransfer);
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirErroMensagem("Erro em CorController Consulta [" + ex.Message + "]");
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
        public async Task<IActionResult> Inclusao(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = await corModel.Incluir(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorController Inclusao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return View("Form", cor);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Alteracao(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = await corModel.Alterar(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorController Alteracao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return View("Form", cor);
            } else {
                return RedirectToAction("Lista");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Exclusao(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = await corModel.Excluir(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorController Exclusao [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return View("Form", cor);
            } else {
                return RedirectToAction("Lista");
            }
        }
    }
}
