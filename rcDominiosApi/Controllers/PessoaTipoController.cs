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
    public class PessoaTipoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
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
                pessoaTipoForm.ErroMensagens.Add("Erro em PessoaTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoForm.Erro || !pessoaTipoForm.Validacao) {
                return BadRequest(pessoaTipoForm);
            } else {
                return Ok(pessoaTipoForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
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
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return BadRequest(pessoaTipoLista);
            } else {
                return Ok(pessoaTipoLista);
            }
        }

        [HttpPost("filtro")]
        public IActionResult Consultar(PessoaTipoDataTransfer pessoaTipo)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoDataTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(pessoaTipo);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoDataTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.ErroMensagens.Add("Erro em PessoaTipoController Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return BadRequest(pessoaTipoLista);
            } else {
                return Ok(pessoaTipoLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(PessoaTipoDataTransfer pessoaTipoDataTransfer)
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
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return BadRequest(pessoaTipoRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = pessoaTipoRetorno.PessoaTipo.Id });

                return Created(uri, pessoaTipoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(PessoaTipoDataTransfer pessoaTipoDataTransfer)
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
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Alterar [" + ex.Message + "]");
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
        public IActionResult Excluir(int id)
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
                pessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoController Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoRetorno.Erro || !pessoaTipoRetorno.Validacao) {
                return BadRequest(pessoaTipoRetorno);
            } else {
                return Ok(pessoaTipoRetorno);
            }
        }
    }
}
