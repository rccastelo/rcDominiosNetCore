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
    public class GeneroSocialController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult ConsultarPorId(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                if (id > 0) {
                    generoSocial = generoSocialModel.ConsultarPorId(id);
                } else {
                    generoSocial = null;
                }
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();
                
                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Consultar(new GeneroSocialTransfer());
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialController Listar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return BadRequest(generoSocialLista);
            } else {
                return Ok(generoSocialLista);
            }
        }

        [HttpPost("lista")]
        public IActionResult Consultar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocialLista = generoSocialModel.Consultar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirErroMensagem("Erro em GeneroSocialController Consultar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocialLista.Erro || !generoSocialLista.Validacao) {
                return BadRequest(generoSocialLista);
            } else {
                return Ok(generoSocialLista);
            }
        }

        [HttpPost]
        public IActionResult Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Incluir(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Incluir [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                string uri = Url.Action("ConsultarPorId", new { id = generoSocial.GeneroSocial.Id });

                return Created(uri, generoSocial);
            }
        }

        [HttpPut]
        public IActionResult Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Alterar(generoSocialTransfer);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Alterar [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            GeneroSocialModel generoSocialModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialModel = new GeneroSocialModel();

                generoSocial = generoSocialModel.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirErroMensagem("Erro em GeneroSocialController Excluir [" + ex.Message + "]");
            } finally {
                generoSocialModel = null;
            }

            if (generoSocial.Erro || !generoSocial.Validacao) {
                return BadRequest(generoSocial);
            } else {
                return Ok(generoSocial);
            }
        }
    }
}
