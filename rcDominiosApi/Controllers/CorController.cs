using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorController : ControllerBase
    {
        [HttpGet("{id}")]
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
            } catch (Exception ex) {
                corForm = new CorDataTransfer();
                
                corForm.Validacao = false;
                corForm.Erro = true;
                corForm.ErroMensagens.Add("Erro em CorController Form [" + ex.Message + "]");
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

            if (corLista.Erro || !corLista.Validacao) {
                return BadRequest(corLista);
            } else {
                return Ok(corLista);
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
                return BadRequest(corRetorno);
            } else {
                string uri = Url.Action("Form", new { id = corRetorno.Cor.Id });

                return Created(uri, corRetorno);
            }
        }

        [HttpPut]
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
                return BadRequest(corRetorno);
            } else {
                return Ok(corRetorno);
            }
        }

        [HttpDelete("{id}")]
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
                return BadRequest(corRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
