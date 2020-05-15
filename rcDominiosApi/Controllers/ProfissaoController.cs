using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfissaoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
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
                profissaoForm.ErroMensagens.Add("Erro em ProfissaoController Form [" + ex.Message + "]");
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
        public IActionResult Lista()
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
                profissaoLista.ErroMensagens.Add("Erro em ProfissaoController Lista [" + ex.Message + "]");
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
        public IActionResult Inclusao(ProfissaoDataTransfer profissaoDataTransfer)
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
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Inclusao [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoRetorno.Erro || !profissaoRetorno.Validacao) {
                return BadRequest(profissaoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = profissaoRetorno.Profissao.Id });

                return Created(uri, profissaoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(ProfissaoDataTransfer profissaoDataTransfer)
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
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Alteracao [" + ex.Message + "]");
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
        public IActionResult Exclusao(int id)
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
                profissaoRetorno.ErroMensagens.Add("Erro em ProfissaoController Exclusao [" + ex.Message + "]");
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
