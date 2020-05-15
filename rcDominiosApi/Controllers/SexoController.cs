using System;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SexoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Form(int id)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoForm;

            try {
                sexoModel = new SexoModel();

                if (id > 0) {
                    sexoForm = sexoModel.ConsultarPorId(id);
                } else {
                    sexoForm = null;
                }
            } catch (Exception ex) {
                sexoForm = new SexoDataTransfer();
                
                sexoForm.Validacao = false;
                sexoForm.Erro = true;
                sexoForm.ErroMensagens.Add("Erro em SexoController Form [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoForm.Erro || !sexoForm.Validacao) {
                return BadRequest(sexoForm);
            } else {
                return Ok(sexoForm);
            }
        }

        [HttpGet]
        public IActionResult Lista()
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Listar();
            } catch (Exception ex) {
                sexoLista = new SexoDataTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.ErroMensagens.Add("Erro em SexoController Lista [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return BadRequest(sexoLista);
            } else {
                return Ok(sexoLista);
            }
        }

        [HttpPost]
        public IActionResult Inclusao(SexoDataTransfer sexoDataTransfer)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Incluir(sexoDataTransfer);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Inclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return BadRequest(sexoRetorno);
            } else {
                string uri = Url.Action("Form", new { id = sexoRetorno.Sexo.Id });

                return Created(uri, sexoRetorno);
            }
        }

        [HttpPut]
        public IActionResult Alteracao(SexoDataTransfer sexoDataTransfer)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Alterar(sexoDataTransfer);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Alteracao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return BadRequest(sexoRetorno);
            } else {
                return Ok(sexoRetorno);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Exclusao(int id)
        {
            SexoModel sexoModel;
            SexoDataTransfer sexoRetorno;

            try {
                sexoModel = new SexoModel();

                sexoRetorno = sexoModel.Excluir(id);
            } catch (Exception ex) {
                sexoRetorno = new SexoDataTransfer();

                sexoRetorno.Validacao = false;
                sexoRetorno.Erro = true;
                sexoRetorno.ErroMensagens.Add("Erro em SexoController Exclusao [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoRetorno.Erro || !sexoRetorno.Validacao) {
                return BadRequest(sexoRetorno);
            } else {
                return NoContent();
            }
        }
    }
}
