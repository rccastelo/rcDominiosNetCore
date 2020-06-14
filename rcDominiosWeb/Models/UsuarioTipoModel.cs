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
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel Incluir [" + ex.Message + "]");
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
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel Alterar [" + ex.Message + "]");
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
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel Excluir [" + ex.Message + "]");
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
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel ConsultarPorId [" + ex.Message + "]");
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
                    if (usuarioTipoLista.Paginacao.TotalRegistros > 0) {
                        if (usuarioTipoLista.Paginacao.RegistrosPorPagina < 1) {
                            usuarioTipoLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (usuarioTipoLista.Paginacao.RegistrosPorPagina > 200) {
                            usuarioTipoLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        usuarioTipoLista.Paginacao.PaginaAtual = (usuarioTipoLista.Paginacao.PaginaAtual < 1 ? 1 : usuarioTipoLista.Paginacao.PaginaAtual);
                        usuarioTipoLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioTipoLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(usuarioTipoLista.Paginacao.RegistrosPorPagina)));
                        usuarioTipoLista.Paginacao.TotalPaginas = (usuarioTipoLista.Paginacao.TotalPaginas < 1 ? 1 : usuarioTipoLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > usuarioTipoLista.Paginacao.TotalPaginas ? usuarioTipoLista.Paginacao.TotalPaginas : qtdExibe);

                        usuarioTipoLista.Paginacao.PaginaInicial = usuarioTipoLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioTipoLista.Paginacao.PaginaFinal = usuarioTipoLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioTipoLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (usuarioTipoLista.Paginacao.PaginaFinal - 1) : usuarioTipoLista.Paginacao.PaginaFinal);

                        if (usuarioTipoLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - usuarioTipoLista.Paginacao.PaginaInicial;
                            usuarioTipoLista.Paginacao.PaginaInicial += dif;
                            usuarioTipoLista.Paginacao.PaginaFinal += dif;
                        }

                        if (usuarioTipoLista.Paginacao.PaginaFinal > usuarioTipoLista.Paginacao.TotalPaginas) {
                            dif = usuarioTipoLista.Paginacao.PaginaFinal - usuarioTipoLista.Paginacao.TotalPaginas;
                            usuarioTipoLista.Paginacao.PaginaInicial -= dif;
                            usuarioTipoLista.Paginacao.PaginaFinal -= dif;
                        }

                        usuarioTipoLista.Paginacao.PaginaInicial = (usuarioTipoLista.Paginacao.PaginaInicial < 1 ? 1 : usuarioTipoLista.Paginacao.PaginaInicial);
                        usuarioTipoLista.Paginacao.PaginaFinal = (usuarioTipoLista.Paginacao.PaginaFinal > usuarioTipoLista.Paginacao.TotalPaginas ? 
                            usuarioTipoLista.Paginacao.TotalPaginas : usuarioTipoLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirMensagem("Erro em UsuarioTipoModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoService = null;
                autenticaModel = null;
            }

            return usuarioTipoLista;
        }
    }
}
