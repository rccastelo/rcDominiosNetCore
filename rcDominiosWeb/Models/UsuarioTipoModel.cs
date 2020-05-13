using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class UsuarioTipoModel
    {
        public UsuarioTipoDataTransfer Incluir(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoDataTransfer usuarioTipoDTValidacao;
            UsuarioTipoDataTransfer usuarioTipoDTInclusao;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDataTransfer.UsuarioTipo.Criacao = DateTime.Today;
                usuarioTipoDataTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipoDTValidacao = usuarioTipoBusiness.Validar(usuarioTipoDataTransfer);

                if (!usuarioTipoDTValidacao.Erro) {
                    if (usuarioTipoDTValidacao.Validacao) {
                        usuarioTipoDTInclusao = usuarioTipoDataModel.Incluir(usuarioTipoDTValidacao);
                    } else {
                        usuarioTipoDTInclusao = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                    }
                } else {
                    usuarioTipoDTInclusao = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoDTInclusao = new UsuarioTipoDataTransfer();

                usuarioTipoDTInclusao.Validacao = false;
                usuarioTipoDTInclusao.Erro = true;
                usuarioTipoDTInclusao.ErroMensagens.Add("Erro em UsuarioTipoModel Incluir [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoDTValidacao = null;
            }

            return usuarioTipoDTInclusao;
        }

        public UsuarioTipoDataTransfer Alterar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoDataTransfer usuarioTipoDTValidacao;
            UsuarioTipoDataTransfer usuarioTipoDTAlteracao;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDataTransfer.UsuarioTipo.Alteracao = DateTime.Today;

                usuarioTipoDTValidacao = usuarioTipoBusiness.Validar(usuarioTipoDataTransfer);

                if (!usuarioTipoDTValidacao.Erro) {
                    if (usuarioTipoDTValidacao.Validacao) {
                        usuarioTipoDTAlteracao = usuarioTipoDataModel.Alterar(usuarioTipoDTValidacao);
                    } else {
                        usuarioTipoDTAlteracao = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                    }
                } else {
                    usuarioTipoDTAlteracao = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoDTAlteracao = new UsuarioTipoDataTransfer();

                usuarioTipoDTAlteracao.Validacao = false;
                usuarioTipoDTAlteracao.Erro = true;
                usuarioTipoDTAlteracao.ErroMensagens.Add("Erro em UsuarioTipoModel Alterar [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoDTValidacao = null;
            }

            return usuarioTipoDTAlteracao;
        }

        public UsuarioTipoDataTransfer Excluir(int id)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoDataTransfer usuarioTipoDTExclusao;

            try {
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDTExclusao = usuarioTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                usuarioTipoDTExclusao = new UsuarioTipoDataTransfer();

                usuarioTipoDTExclusao.Validacao = false;
                usuarioTipoDTExclusao.Erro = true;
                usuarioTipoDTExclusao.ErroMensagens.Add("Erro em UsuarioTipoModel Excluir [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
            }

            return usuarioTipoDTExclusao;
        }

        public UsuarioTipoDataTransfer Listar()
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoDataTransfer usuarioTipoDTLista;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDTLista = usuarioTipoDataModel.Listar();
            } catch (Exception ex) {
                usuarioTipoDTLista = new UsuarioTipoDataTransfer();

                usuarioTipoDTLista.Validacao = false;
                usuarioTipoDTLista.Erro = true;
                usuarioTipoDTLista.ErroMensagens.Add("Erro em UsuarioTipoModel Listar [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
            }

            return usuarioTipoDTLista;
        }

        public UsuarioTipoDataTransfer ConsultarPorId(int id)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoDataTransfer usuarioTipoDTForm;
            
            try {
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDTForm = usuarioTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                usuarioTipoDTForm = new UsuarioTipoDataTransfer();

                usuarioTipoDTForm.Validacao = false;
                usuarioTipoDTForm.Erro = true;
                usuarioTipoDTForm.ErroMensagens.Add("Erro em UsuarioTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
            }

            return usuarioTipoDTForm;
        }

        public UsuarioTipoDataTransfer Consultar(UsuarioTipoDataTransfer usuarioTipoDataTransfer)
        {
            UsuarioTipoDataModel usuarioTipoDataModel;
            UsuarioTipoBusiness usuarioTipoBusiness;
            UsuarioTipoDataTransfer usuarioTipoDTValidacao;
            UsuarioTipoDataTransfer usuarioTipoDTConsulta;

            try {
                usuarioTipoBusiness = new UsuarioTipoBusiness();
                usuarioTipoDataModel = new UsuarioTipoDataModel();

                usuarioTipoDTValidacao = usuarioTipoBusiness.ValidarConsulta(usuarioTipoDataTransfer);

                if (!usuarioTipoDTValidacao.Erro) {
                    if (usuarioTipoDTValidacao.Validacao) {
                        usuarioTipoDTConsulta = usuarioTipoDataModel.Consultar(usuarioTipoDTValidacao);
                    } else {
                        usuarioTipoDTConsulta = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                    }
                } else {
                    usuarioTipoDTConsulta = new UsuarioTipoDataTransfer(usuarioTipoDTValidacao);
                }
            } catch (Exception ex) {
                usuarioTipoDTConsulta = new UsuarioTipoDataTransfer();

                usuarioTipoDTConsulta.Validacao = false;
                usuarioTipoDTConsulta.Erro = true;
                usuarioTipoDTConsulta.ErroMensagens.Add("Erro em UsuarioTipoModel Consultar [" + ex.Message + "]");
            } finally {
                usuarioTipoDataModel = null;
                usuarioTipoBusiness = null;
                usuarioTipoDTValidacao = null;
            }

            return usuarioTipoDTConsulta;
        }
    }
}
