using System;
using System.Threading.Tasks;
using rcDominiosTransfers;
using rcDominiosWeb.Services;

namespace rcDominiosWeb.Models
{
    public class UsuarioModel
    {
        public async Task<UsuarioTransfer> Incluir(UsuarioTransfer usuarioTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;

            try {
                usuarioService = new UsuarioService();

                usuarioTransfer.Usuario.Criacao = DateTime.Today;
                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuario = await usuarioService.Incluir(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioService = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Alterar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;

            try {
                usuarioService = new UsuarioService();

                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuario = await usuarioService.Alterar(usuarioTransfer);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioService = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Excluir(int id)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;

            try {
                usuarioService = new UsuarioService();

                usuario = await usuarioService.Excluir(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioService = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> ConsultarPorId(int id)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuario;
            
            try {
                usuarioService = new UsuarioService();

                usuario = await usuarioService.ConsultarPorId(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Validacao = false;
                usuario.Erro = true;
                usuario.IncluirErroMensagem("Erro em UsuarioModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioService = null;
            }

            return usuario;
        }

        public async Task<UsuarioTransfer> Consultar(UsuarioTransfer usuarioListaTransfer)
        {
            UsuarioService usuarioService;
            UsuarioTransfer usuarioLista;
            int dif = 0;
            int qtdExibe = 5;

            try {
                usuarioService = new UsuarioService();

                usuarioLista = await usuarioService.Consultar(usuarioListaTransfer);

                if (usuarioLista != null) {
                    if (usuarioLista.TotalRegistros > 1) {
                        if (usuarioLista.RegistrosPorPagina < 1) {
                            usuarioLista.RegistrosPorPagina = 30;
                        } else if (usuarioLista.RegistrosPorPagina > 200) {
                            usuarioLista.RegistrosPorPagina = 30;
                        }

                        usuarioLista.PaginaAtual = (usuarioLista.PaginaAtual < 1 ? 1 : usuarioLista.PaginaAtual);
                        usuarioLista.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioLista.TotalRegistros) 
                            / @Convert.ToDecimal(usuarioLista.RegistrosPorPagina)));
                        usuarioLista.TotalPaginas = (usuarioLista.TotalPaginas < 1 ? 1 : usuarioLista.TotalPaginas);

                        qtdExibe = (qtdExibe > usuarioLista.TotalPaginas ? usuarioLista.TotalPaginas : qtdExibe);

                        usuarioLista.PaginaInicial = usuarioLista.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioLista.PaginaFinal = usuarioLista.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        usuarioLista.PaginaFinal = ((qtdExibe % 2) == 0 ? (usuarioLista.PaginaFinal - 1) : usuarioLista.PaginaFinal);

                        if (usuarioLista.PaginaInicial < 1) {
                            dif = 1 - usuarioLista.PaginaInicial;
                            usuarioLista.PaginaInicial += dif;
                            usuarioLista.PaginaFinal += dif;
                        }

                        if (usuarioLista.PaginaFinal > usuarioLista.TotalPaginas) {
                            dif = usuarioLista.PaginaFinal - usuarioLista.TotalPaginas;
                            usuarioLista.PaginaInicial -= dif;
                            usuarioLista.PaginaFinal -= dif;
                        }

                        usuarioLista.PaginaInicial = (usuarioLista.PaginaInicial < 1 ? 1 : usuarioLista.PaginaInicial);
                        usuarioLista.PaginaFinal = (usuarioLista.PaginaFinal > usuarioLista.TotalPaginas ? 
                            usuarioLista.TotalPaginas : usuarioLista.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Validacao = false;
                usuarioLista.Erro = true;
                usuarioLista.IncluirErroMensagem("Erro em UsuarioModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioService = null;
            }

            return usuarioLista;
        }
    }
}
