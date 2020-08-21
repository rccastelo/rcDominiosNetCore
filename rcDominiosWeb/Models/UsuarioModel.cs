using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class UsuarioModel
    {
        private readonly IHttpContextAccessor httpContext;

        public UsuarioModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<UsuarioTransfer> Incluir(UsuarioTransfer usuarioTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTransfer.Usuario.Criacao = DateTime.Today;
                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuario = await usuarioService.Incluir(usuarioTransfer, autorizacao);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Alterar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuario = await usuarioService.Alterar(usuarioTransfer, autorizacao);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> AlterarSenha(UsuarioTransfer usuarioTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuario = await usuarioService.AlterarSenha(usuarioTransfer, autorizacao);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel AlterarSenha [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Excluir(int id)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuario = await usuarioService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> ConsultarPorId(int id)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuario = await usuarioService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Consultar(UsuarioTransfer usuarioListaTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuarioLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                usuarioService = new UsuarioService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                usuarioLista = await usuarioService.Consultar(usuarioListaTransfer, autorizacao);

                if (usuarioLista != null) {
                    if (usuarioLista.Paginacao.TotalRegistros > 0) {
                        if (usuarioLista.Paginacao.RegistrosPorPagina < 1) {
                            usuarioLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (usuarioLista.Paginacao.RegistrosPorPagina > 200) {
                            usuarioLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        usuarioLista.Paginacao.PaginaAtual = (usuarioLista.Paginacao.PaginaAtual < 1 ? 1 : usuarioLista.Paginacao.PaginaAtual);
                        usuarioLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(usuarioLista.Paginacao.RegistrosPorPagina)));
                        usuarioLista.Paginacao.TotalPaginas = (usuarioLista.Paginacao.TotalPaginas < 1 ? 1 : usuarioLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > usuarioLista.Paginacao.TotalPaginas ? usuarioLista.Paginacao.TotalPaginas : qtdExibe);

                        usuarioLista.Paginacao.PaginaInicial = usuarioLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioLista.Paginacao.PaginaFinal = usuarioLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (usuarioLista.Paginacao.PaginaFinal - 1) : usuarioLista.Paginacao.PaginaFinal);

                        if (usuarioLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - usuarioLista.Paginacao.PaginaInicial;
                            usuarioLista.Paginacao.PaginaInicial += dif;
                            usuarioLista.Paginacao.PaginaFinal += dif;
                        }

                        if (usuarioLista.Paginacao.PaginaFinal > usuarioLista.Paginacao.TotalPaginas) {
                            dif = usuarioLista.Paginacao.PaginaFinal - usuarioLista.Paginacao.TotalPaginas;
                            usuarioLista.Paginacao.PaginaInicial -= dif;
                            usuarioLista.Paginacao.PaginaFinal -= dif;
                        }

                        usuarioLista.Paginacao.PaginaInicial = (usuarioLista.Paginacao.PaginaInicial < 1 ? 1 : usuarioLista.Paginacao.PaginaInicial);
                        usuarioLista.Paginacao.PaginaFinal = (usuarioLista.Paginacao.PaginaFinal > usuarioLista.Paginacao.TotalPaginas ? 
                            usuarioLista.Paginacao.TotalPaginas : usuarioLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioService = null;
                autenticaModel = null;
            }

            return usuarioLista;
        }
    }
}
