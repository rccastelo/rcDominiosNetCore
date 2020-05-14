using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoForm;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                if (id > 0) {
                    pessoaTipoForm = pessoaTipoModel.ConsultarPorId(id);
                } else {
                    pessoaTipoForm = null;
                }
            } catch (Exception ex) {
                pessoaTipoForm = new PessoaTipoDataTransfer();
                
                pessoaTipoForm.Validacao = false;
                pessoaTipoForm.Erro = true;
                pessoaTipoForm.ErroMensagens.Add("Erro em PessoaTipoController Form [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            return Ok(pessoaTipoForm);
        }

        [HttpGet]
        public IActionResult Lista()
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Listar();
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoDataTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Lista [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            return Ok(pessoaTipoLista);
        }

        [HttpPost]
        public IActionResult Inclusao(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Incluir(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Inclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return BadRequest(pessoaTipoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = pessoaTipoRetorno.PessoaTipo.Id });

                return Created(uri, pessoaTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Alterar(pessoaTipoDataTransfer);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Alteracao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return BadRequest(pessoaTipoRetorno);
            } else {
                return Ok(pessoaTipoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Exclusao(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoRetorno;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoRetorno = pessoaTipoModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoRetorno.Validacao = false;
                pessoaTipoRetorno.Erro = true;
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Exclusao [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return BadRequest(pessoaTipoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
