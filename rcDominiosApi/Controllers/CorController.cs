using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CorController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                if (id > 0) {
                    cor = corModel.ConsultarPorId(id);
                } else {
                    cor = null;
                }
            } catch (Exception ex) {
                cor = new CorTransfer();
                
                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController ConsultarPorId [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Consultar(new CorTransfer());
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorController Listar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corLista.Erro || !corLista.Validacao) {
                return BadRequest(corLista);
            } else {
                return Ok(corLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer corLista;

            try {
                corModel = new CorModel();

                corLista = corModel.Consultar(corTransfer);
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em CorController Consultar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corLista.Erro || !corLista.Validacao) {
                return BadRequest(corLista);
            } else {
                return Ok(corLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Incluir(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Incluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = cor.Cor.Id });

                return Created(uri, cor);
            }
        }

        [HttpPut]
        public IActionResult Alterar(CorTransfer corTransfer)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Alterar(corTransfer);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Alterar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            CorModel corModel;
            CorTransfer cor;

            try {
                corModel = new CorModel();

                cor = corModel.Excluir(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em CorController Excluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (cor.Erro || !cor.Validacao) {
                return BadRequest(cor);
            } else {
                return Ok(cor);
            }
        }
    }
}
