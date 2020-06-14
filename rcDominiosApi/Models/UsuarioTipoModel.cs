using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class UsuarioTipoModel
    {
        public UsuarioTipoTransfer Incluir(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoTransfer usuarioTipoValidacao;
            UsuarioTipoTransfer usuarioTipoInclusao;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoTransfer.UsuarioTipo.Criacao = DateTime.Today;
                usuarioTipoTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipoValidacao = usuarioTipoBusiness.Validar(usuarioTipoTransfer);

                if (!usuarioTipoValidacao.Erro) {
                    if (usuarioTipoValidacao.Validacao) {
                        usuarioTipoInclusao = usuarioTipoDataModel.Incluir(usuarioTipoValidacao);
                    } else {
                        usuarioTipoInclusao = new UsuarioTipoTransfer(usuarioTipoValidacao);
                    }
                } else {
                    usuarioTipoInclusao = new UsuarioTipoTransfer(usuarioTipoValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoInclusao = new UsuarioTipoTransfer();

                usuarioTipoInclusao.Validacao = false;
                usuarioTipoInclusao.Erro = true;
                usuarioTipoInclusao.IncluirMensagem("Erro em UsuarioTipoModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoValidacao = null;
            }

            return usuarioTipoInclusao;
        }

        public UsuarioTipoTransfer Alterar(UsuarioTipoTransfer usuarioTipoTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoTransfer usuarioTipoValidacao;
            UsuarioTipoTransfer usuarioTipoAlteracao;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipoValidacao = usuarioTipoBusiness.Validar(usuarioTipoTransfer);

                if (!usuarioTipoValidacao.Erro) {
                    if (usuarioTipoValidacao.Validacao) {
                        usuarioTipoAlteracao = usuarioTipoDataModel.Alterar(usuarioTipoValidacao);
                    } else {
                        usuarioTipoAlteracao = new UsuarioTipoTransfer(usuarioTipoValidacao);
                    }
                } else {
                    usuarioTipoAlteracao = new UsuarioTipoTransfer(usuarioTipoValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoAlteracao = new UsuarioTipoTransfer();

                usuarioTipoAlteracao.Validacao = false;
                usuarioTipoAlteracao.Erro = true;
                usuarioTipoAlteracao.IncluirMensagem("Erro em UsuarioTipoModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoValidacao = null;
            }

            return usuarioTipoAlteracao;
        }

        public UsuarioTipoTransfer Excluir(int id)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoTransfer usuarioTipo;

            try {
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipo = usuarioTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer ConsultarPorId(int id)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoTransfer usuarioTipo;
            
            try {
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipo = usuarioTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                usuarioTipo = new UsuarioTipoTransfer();

                usuarioTipo.Validacao = false;
                usuarioTipo.Erro = true;
                usuarioTipo.IncluirMensagem("Erro em UsuarioTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
            }

            return usuarioTipo;
        }

        public UsuarioTipoTransfer Consultar(UsuarioTipoTransfer usuarioTipoListaTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoTransfer usuarioTipoValidacao;
            UsuarioTipoTransfer usuarioTipoLista;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoValidacao = usuarioTipoBusiness.ValidarConsulta(usuarioTipoListaTransfer);

                if (!usuarioTipoValidacao.Erro) {
                    if (usuarioTipoValidacao.Validacao) {
                        usuarioTipoLista = usuarioTipoDataModel.Consultar(usuarioTipoValidacao);

                        if (usuarioTipoLista != null) {
                            if (usuarioTipoLista.Paginacao.TotalRegistros > 0) {
                                if (usuarioTipoLista.Paginacao.RegistrosPorPagina < 1) {
                                    usuarioTipoLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (usuarioTipoLista.Paginacao.RegistrosPorPagina > 200) {
                                    usuarioTipoLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                usuarioTipoLista.Paginacao.PaginaAtual = (usuarioTipoListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : usuarioTipoListaTransfer.Paginacao.PaginaAtual);
                                usuarioTipoLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(usuarioTipoLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(usuarioTipoLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        usuarioTipoLista = new UsuarioTipoTransfer(usuarioTipoValidacao);
                    }
                } else {
                    usuarioTipoLista = new UsuarioTipoTransfer(usuarioTipoValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoLista = new UsuarioTipoTransfer();

                usuarioTipoLista.Validacao = false;
                usuarioTipoLista.Erro = true;
                usuarioTipoLista.IncluirMensagem("Erro em UsuarioTipoModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoValidacao = null;
            }

            return usuarioTipoLista;
        }
    }
}
