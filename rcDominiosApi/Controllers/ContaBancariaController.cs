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
    public class ContaBancariaController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaForm;

            try {
                contaBancariaModel = new ContaBancariaModel();

                if (id > 0) {
                    contaBancariaForm = contaBancariaModel.ConsultarPorId(id);
                } else {
                    contaBancariaForm = null;
                }
            } catch (Exception ex) {
                contaBancariaForm = new ContaBancariaDataTransfer();
                
                contaBancariaForm.Validacao = false;
                contaBancariaForm.Erro = true;
                contaBancariaForm.IncluirErroMensagem("Erro em ContaBancariaController ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaForm.Erro || !contaBancariaForm.Validacao) {
                return BadRequest(contaBancariaForm);
            } else {
                return Ok(contaBancariaForm);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaLista;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaLista = contaBancariaModel.Listar();
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaDataTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirErroMensagem("Erro em ContaBancariaController Listar [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaLista.Erro || !contaBancariaLista.Validacao) {
                return BadRequest(contaBancariaLista);
            } else {
                return Ok(contaBancariaLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Incluir(contaBancariaDataTransfer);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return BadRequest(contaBancariaRetorno);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = contaBancariaRetorno.ContaBancaria.Id });

                return Created(uri, contaBancariaRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alterar(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Alterar(contaBancariaDataTransfer);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return BadRequest(contaBancariaRetorno);
            } else {
                return Ok(contaBancariaRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            ContaBancariaModel contaBancariaModel;
            ContaBancariaDataTransfer contaBancariaRetorno;

            try {
                contaBancariaModel = new ContaBancariaModel();

                contaBancariaRetorno = contaBancariaModel.Excluir(id);
            } catch (Exception ex) {
                contaBancariaRetorno = new ContaBancariaDataTransfer();

                contaBancariaRetorno.Validacao = false;
                contaBancariaRetorno.Erro = true;
                contaBancariaRetorno.IncluirErroMensagem("Erro em ContaBancariaController Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return BadRequest(contaBancariaRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
