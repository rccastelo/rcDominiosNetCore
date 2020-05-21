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
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                if (id > 0) {
                    profissao = profissaoModel.ConsultarPorId(id);
                } else {
                    profissao = null;
                }
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();
                
                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            ProfissaoModel profissaoModel;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Consultar(new ProfissaoListaTransfer());
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Listar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissaoLista.Erro || !profissaoLista.Validacao) {
                return BadRequest(profissaoLista);
            } else {
                return Ok(profissaoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(ProfissaoListaTransfer profissaoListaTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoModel = new ProfissaoModel();

                profissaoLista = profissaoModel.Consultar(profissaoListaTransfer);
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoController Consultar [" + ex.Message + "]");
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
        public IActionResult Incluir(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Incluir(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Incluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = profissao.Profissao.Id });

                return Created(uri, profissao);
            }
        }

        [HttpPut]
        public IActionResult Alterar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Alterar(profissaoTransfer);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Alterar [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            ProfissaoModel profissaoModel;
            ProfissaoTransfer profissao;

            try {
                profissaoModel = new ProfissaoModel();

                profissao = profissaoModel.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoController Excluir [" + ex.Message + "]");
            } finally {
                profissaoModel = null;
            }

            if (profissao.Erro || !profissao.Validacao) {
                return BadRequest(profissao);
            } else {
                return Ok(profissao);
            }
        }
    }
}
