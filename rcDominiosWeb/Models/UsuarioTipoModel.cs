using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class UsuarioTipoModel
    {
        private readonly IHttpContextAccessor httpContext;

        public UsuarioTipoModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<UsuarioTipoTransfer> Incluir(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoService usuarioTipoService;
            UsuarioTipoTransfer usuarioTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioTipoService = new UsuarioTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTipoTransfer.UsuarioTipo.Criacao = DateTime.Today;
                usuarioTipoTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipo = await usuarioTipoService.Incluir(usuarioTipoTransfer, autorizacao);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Alterar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoService usuarioTipoService;
            UsuarioTipoTransfer usuarioTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioTipoService = new UsuarioTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTipoTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipo = await usuarioTipoService.Alterar(usuarioTipoTransfer, autorizacao);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Excluir(int id)
        {
            UsuarioTipoService usuarioTipoService;
            UsuarioTipoTransfer usuarioTipo;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioTipoService = new UsuarioTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTipo = await usuarioTipoService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> ConsultarPorId(int id)
        {
            UsuarioTipoService usuarioTipoService;
            UsuarioTipoTransfer usuarioTipo;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                usuarioTipoService = new UsuarioTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTipo = await usuarioTipoService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirErroMensagem("Erro em UsuarioTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipo;
        }

        public async Task<UsuarioTipoTransfer> Consultar(UsuarioTipoTransfer usuarioTipoListaTransfer)
        {
            UsuarioTipoService usuarioTipoService;
            UsuarioTipoTransfer usuarioTipoLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                usuarioTipoService = new UsuarioTipoService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTipoLista = await usuarioTipoService.Consultar(usuarioTipoListaTransfer, autorizacao);

                if (usuarioTipoLista != null) {
                    if (usuarioTipoLista.TotalRegistros > 0) {
                        if (usuarioTipoLista.RegistrosPorPagina < 1) {
                            usuarioTipoLista.RegistrosPorPagina = 30;
                        } else if (usuarioTipoLista.RegistrosPorPagina > 200) {
                            usuarioTipoLista.RegistrosPorPagina = 30;
                        }

                        usuarioTipoLista.PaginaAtual = (usuarioTipoLista.PaginaAtual < 1 ? 1 : usuarioTipoLista.PaginaAtual);
                        usuarioTipoLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioTipoLista.TotalRegistros) 
                            / @Convert.ToDecimal(usuarioTipoLista.RegistrosPorPagina)));
                        usuarioTipoLista.TotalPaginas = (usuarioTipoLista.TotalPaginas < 1 ? 1 : usuarioTipoLista.TotalPaginas);

                        qtdExibe = (qtdExibe > usuarioTipoLista.TotalPaginas ? usuarioTipoLista.TotalPaginas : qtdExibe);

                        usuarioTipoLista.PaginaInicial = usuarioTipoLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioTipoLista.PaginaFinal = usuarioTipoLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioTipoLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (usuarioTipoLista.PaginaFinal - 1) : usuarioTipoLista.PaginaFinal);

                        if (usuarioTipoLista.PaginaInicial < 1) {
                            dif = 1 - usuarioTipoLista.PaginaInicial;
                            usuarioTipoLista.PaginaInicial += dif;
                            usuarioTipoLista.PaginaFinal += dif;
                        }

                        if (usuarioTipoLista.PaginaFinal > usuarioTipoLista.TotalPaginas) {
                            dif = usuarioTipoLista.PaginaFinal - usuarioTipoLista.TotalPaginas;
                            usuarioTipoLista.PaginaInicial -= dif;
                            usuarioTipoLista.PaginaFinal -= dif;
                        }

                        usuarioTipoLista.PaginaInicial = (usuarioTipoLista.PaginaInicial < 1 ? 1 : usuarioTipoLista.PaginaInicial);
                        usuarioTipoLista.PaginaFinal = (usuarioTipoLista.PaginaFinal > usuarioTipoLista.TotalPaginas ? 
                            usuarioTipoLista.TotalPaginas : usuarioTipoLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirErroMensagem("Erro em UsuarioTipoModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipoLista;
        }
    }
}
