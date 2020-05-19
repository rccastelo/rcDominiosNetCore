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
    public class ProfissaoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoForm;

            try {
                profissaoModel = new ProfissaoModel();

                if (id > 0) {
                    profissaoForm = profissaoModel.ConsultarPorId(id);
                } else {
                    profissaoForm = null;
                }
            } catch (Exception ex) {
                profissaoForm = new ProfissaoDataTransfer();
                
                profissaoForm.Validacao = false;
                profissaoForm.Erro = true;
                profissaoForm.ErroMensagens.Add("Erro em ProfissaoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoForm.Erro || !profissaoForm.Validacao) {
                return BadRequest(profissaoForm);
            } else {
                return Ok(profissaoForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Listar();
            } catch (Exception ex) {
                profissaoLista = new ProfissaoDataTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.ErroMensagens.Add("Erro em ProfissaoController Listar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return BadRequest(profissaoLista);
            } else {
                return Ok(profissaoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Incluir(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Incluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return BadRequest(profissaoRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = profissaoRetorno.Profissao.Id });

                return Created(uri, profissaoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Alterar(profissaoDataTransfer);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Alterar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return BadRequest(profissaoRetorno);
            } else {
                return Ok(profissaoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoDataTransfer profissaoRetorno;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoRetorno = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissaoRetorno = new ProfissaoDataTransfer();

                profissaoRetorno.Validacao = false;
                profissaoRetorno.Erro = true;
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Excluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return BadRequest(profissaoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
