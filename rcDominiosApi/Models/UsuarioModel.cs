using System;
using rcDominiosCriptografia;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class UsuarioModel
    {
        public UsuarioTransfer Incluir(UsuarioTransfer usuarioTransfer)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioBusiness usuarioBusiness;
            UsuarioTransfer usuarioValidacao;
            UsuarioTransfer usuarioInclusao;

            try {
                usuarioBusiness = new UsuarioBusiness();
                usuarioDataModel = new UsuarioDataModel();

                usuarioTransfer.Usuario.Criacao = DateTime.Today;
                usuarioTransfer.Usuario.Alteracao = DateTime.Today;
                usuarioTransfer.TipoAcao = "Inclusao";

                usuarioValidacao = usuarioBusiness.Validar(usuarioTransfer);

                if (!usuarioValidacao.Erro) {
                    if (usuarioValidacao.Validacao) {
                        //-- Criptografia da senha
                        string apelidoSenha = (usuarioValidacao.Usuario.Apelido + usuarioValidacao.Usuario.Senha);

                        string apelidoSenhaCripto = Criptografia.CriptravarSHA512(apelidoSenha);

                        usuarioValidacao.Usuario.Senha = apelidoSenhaCripto;
                        //-------------------------

                        usuarioInclusao = usuarioDataModel.Incluir(usuarioValidacao);
                    } else {
                        usuarioInclusao = new UsuarioTransfer(usuarioValidacao);
                    }
                } else {
                    usuarioInclusao = new UsuarioTransfer(usuarioValidacao);
                }
            } catch (Exception ex) {
                usuarioInclusao = new UsuarioTransfer();

                usuarioInclusao.Erro = true;
                usuarioInclusao.IncluirMensagem("Erro em UsuarioModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
                usuarioBusiness = null;
                usuarioValidacao = null;
            }

            return usuarioInclusao;
        }

        public UsuarioTransfer Alterar(UsuarioTransfer usuarioTransfer)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioBusiness usuarioBusiness;
            UsuarioTransfer usuarioValidacao;
            UsuarioTransfer usuarioAlteracao;

            try {
                usuarioBusiness = new UsuarioBusiness();
                usuarioDataModel = new UsuarioDataModel();

                usuarioTransfer.Usuario.Alteracao = DateTime.Today;
                usuarioTransfer.TipoAcao = "Alteracao";

                usuarioValidacao = usuarioBusiness.Validar(usuarioTransfer);

                if (!usuarioValidacao.Erro) {
                    if (usuarioValidacao.Validacao) {
                        usuarioAlteracao = usuarioDataModel.Alterar(usuarioValidacao);
                    } else {
                        usuarioAlteracao = new UsuarioTransfer(usuarioValidacao);
                    }
                } else {
                    usuarioAlteracao = new UsuarioTransfer(usuarioValidacao);
                }
            } catch (Exception ex) {
                usuarioAlteracao = new UsuarioTransfer();

                usuarioAlteracao.Erro = true;
                usuarioAlteracao.IncluirMensagem("Erro em UsuarioModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
                usuarioBusiness = null;
                usuarioValidacao = null;
            }

            return usuarioAlteracao;
        }

        public UsuarioTransfer AlterarSenha(UsuarioTransfer usuarioTransfer)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioBusiness usuarioBusiness;
            UsuarioTransfer usuarioValidacao;
            UsuarioTransfer usuarioAlteracao;

            try {
                usuarioBusiness = new UsuarioBusiness();
                usuarioDataModel = new UsuarioDataModel();

                usuarioTransfer.Usuario.Alteracao = DateTime.Today;

                usuarioValidacao = usuarioBusiness.Validar(usuarioTransfer);

                if (!usuarioValidacao.Erro) {
                    if (usuarioValidacao.Validacao) {
                        usuarioAlteracao = usuarioDataModel.Alterar(usuarioValidacao);
                    } else {
                        usuarioAlteracao = new UsuarioTransfer(usuarioValidacao);
                    }
                } else {
                    usuarioAlteracao = new UsuarioTransfer(usuarioValidacao);
                }
            } catch (Exception ex) {
                usuarioAlteracao = new UsuarioTransfer();

                usuarioAlteracao.Erro = true;
                usuarioAlteracao.IncluirMensagem("Erro em UsuarioModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
                usuarioBusiness = null;
                usuarioValidacao = null;
            }

            return usuarioAlteracao;
        }

        public UsuarioTransfer Excluir(int id)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioTransfer usuario;

            try {
                usuarioDataModel = new UsuarioDataModel();

                usuario = usuarioDataModel.Excluir(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
            }

            return usuario;
        }

        public UsuarioTransfer ConsultarPorId(int id)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioTransfer usuario;
            
            try {
                usuarioDataModel = new UsuarioDataModel();

                usuario = usuarioDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                usuario = new UsuarioTransfer();

                usuario.Erro = true;
                usuario.IncluirMensagem("Erro em UsuarioModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
            }

            return usuario;
        }

        public UsuarioTransfer Consultar(UsuarioTransfer usuarioListaTransfer)
        {
            UsuarioDataModel usuarioDataModel;
            UsuarioBusiness usuarioBusiness;
            UsuarioTransfer usuarioValidacao;
            UsuarioTransfer usuarioLista;

            try {
                usuarioBusiness = new UsuarioBusiness();
                usuarioDataModel = new UsuarioDataModel();

                usuarioValidacao = usuarioBusiness.ValidarConsulta(usuarioListaTransfer);

                if (!usuarioValidacao.Erro) {
                    if (usuarioValidacao.Validacao) {
                        usuarioLista = usuarioDataModel.Consultar(usuarioValidacao);

                        if (usuarioLista != null) {
                            if (usuarioLista.Paginacao.TotalRegistros > 0) {
                                if (usuarioLista.Paginacao.RegistrosPorPagina < 1) {
                                    usuarioLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (usuarioLista.Paginacao.RegistrosPorPagina > 200) {
                                    usuarioLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                usuarioLista.Paginacao.PaginaAtual = (usuarioListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : usuarioListaTransfer.Paginacao.PaginaAtual);
                                usuarioLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(usuarioLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        usuarioLista = new UsuarioTransfer(usuarioValidacao);
                    }
                } else {
                    usuarioLista = new UsuarioTransfer(usuarioValidacao);
                }
            } catch (Exception ex) {
                usuarioLista = new UsuarioTransfer();

                usuarioLista.Erro = true;
                usuarioLista.IncluirMensagem("Erro em UsuarioModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioDataModel = null;
                usuarioBusiness = null;
                usuarioValidacao = null;
            }

            return usuarioLista;
        }
    }
}
