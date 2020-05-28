using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rcDominiosApi.Models;
using rcDominiosTransfers;

namespace rcDominiosApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SexoController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                if (id > 0) {
                    sexo = sexoModel.ConsultarPorId(id);
                } else {
                    sexo = null;
                }
            } catch (Exception ex) {
                sexo = new SexoTransfer();
                
                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Consultar(new SexoTransfer());
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoController Listar [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexoLista.Erro || !sexoLista.Validacao) {
                return BadRequest(sexoLista);
            } else {
                return Ok(sexoLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexoLista;

            try {
                sexoModel = new SexoModel();

                sexoLista = sexoModel.Consultar(sexoTransfer);
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoController Consultar [" + ex.Message + "]");
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
        public IActionResult Incluir(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Incluir(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Incluir [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = sexo.Sexo.Id });

                return Created(uri, sexo);
            }
        }

        [HttpPut]
        public IActionResult Alterar(SexoTransfer sexoTransfer)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Alterar(sexoTransfer);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Alterar [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            SexoModel sexoModel;
            SexoTransfer sexo;

            try {
                sexoModel = new SexoModel();

                sexo = sexoModel.Excluir(id);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoController Excluir [" + ex.Message + "]");
            } finally {
                sexoModel = null;
            }

            if (sexo.Erro || !sexo.Validacao) {
                return BadRequest(sexo);
            } else {
                return Ok(sexo);
            }
        }
    }
}
