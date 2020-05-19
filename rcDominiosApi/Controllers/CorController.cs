using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

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
            CorDataTransfer corForm;

            try {
                corModel = new CorModel();

                if (id > 0) {
                    corForm = corModel.ConsultarPorId(id);
                } else {
                    corForm = null;
                }
            } catch (Exception ex) {
                corForm = new CorDataTransfer();
                
                corForm.Validacao = false;
                corForm.Erro = true;
                corForm.ErroMensagens.Add("Erro em CorController ConsultarPorId [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corForm.Erro || !corForm.Validacao) {
                return BadRequest(corForm);
            } else {
                return Ok(corForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
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
                corLista.ErroMensagens.Add("Erro em CorController Listar [" + ex.Message + "]");
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
        public IActionResult Incluir(CorDataTransfer corDataTransfer)
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
                corRetorno.ErroMensagens.Add("Erro em CorController Incluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return BadRequest(corRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = corRetorno.Cor.Id });

                return Created(uri, corRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(CorDataTransfer corDataTransfer)
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
                corRetorno.ErroMensagens.Add("Erro em CorController Alterar [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return BadRequest(corRetorno);
            } else {
                return Ok(corRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
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
                corRetorno.ErroMensagens.Add("Erro em CorController Excluir [" + ex.Message + "]");
            } finally {
                corModel = null;
            }

            if (corRetorno.Erro || !corRetorno.Validacao) {
                return BadRequest(corRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
