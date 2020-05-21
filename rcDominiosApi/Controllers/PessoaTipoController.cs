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
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                if (id > 0) {
                    pessoaTipo = pessoaTipoModel.ConsultarPorId(id);
                } else {
                    pessoaTipo = null;
                }
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();
                
                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoListaTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(new PessoaTipoListaTransfer());
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoListaTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoController Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipoLista.Erro || !pessoaTipoLista.Validacao) {
                return BadRequest(pessoaTipoLista);
            } else {
                return Ok(pessoaTipoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(PessoaTipoListaTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoListaTransfer pessoaTipoLista;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipoLista = pessoaTipoModel.Consultar(pessoaTipoListaTransfer);
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoListaTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoController Consultar [" + ex.Message + "]");
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
        public IActionResult Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Incluir(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = pessoaTipo.PessoaTipo.Id });

                return Created(uri, pessoaTipo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Alterar(pessoaTipoTransfer);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            PessoaTipoModel pessoaTipoModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoModel = new PessoaTipoModel();

                pessoaTipo = pessoaTipoModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoController Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoModel = null;
            }

            if (pessoaTipo.Erro || !pessoaTipo.Validacao) {
                return BadRequest(pessoaTipo);
            } else {
                return Ok(pessoaTipo);
            }
        }
    }
}
