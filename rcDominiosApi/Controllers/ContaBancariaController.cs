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
        public IActionResult Form(int id)
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
                contaBancariaForm.ErroMensagens.Add("Erro em ContaBancariaController Form [" + ex.Message + "]");
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
        public IActionResult Lista()
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
                contaBancariaLista.ErroMensagens.Add("Erro em ContaBancariaController Lista [" + ex.Message + "]");
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
        public IActionResult Inclusao(ContaBancariaDataTransfer contaBancariaDataTransfer)
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
                contaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaController Inclusao [" + ex.Message + "]");
            } finally {
                contaBancariaModel = null;
            }

            if (contaBancariaRetorno.Erro || !contaBancariaRetorno.Validacao) {
                return BadRequest(contaBancariaRetorno);
            } else {
                string uri = Url.Action("Form", new { id = contaBancariaRetorno.ContaBancaria.Id });

                return Created(uri, contaBancariaRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(ContaBancariaDataTransfer contaBancariaDataTransfer)
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
                contaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaController Alteracao [" + ex.Message + "]");
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
        public IActionResult Exclusao(int id)
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
                contaBancariaRetorno.ErroMensagens.Add("Erro em ContaBancariaController Exclusao [" + ex.Message + "]");
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
