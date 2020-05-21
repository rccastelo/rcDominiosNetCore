using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class EnderecoTipoModel
    {
        public EnderecoTipoDataTransfer Incluir(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoDataTransfer enderecoTipoDTValidacao;
            EnderecoTipoDataTransfer enderecoTipoDTInclusao;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDataTransfer.EnderecoTipo.Criacao = DateTime.Today;
                enderecoTipoDataTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipoDTValidacao = enderecoTipoBusiness.Validar(enderecoTipoDataTransfer);

                if (!enderecoTipoDTValidacao.Erro) {
                    if (enderecoTipoDTValidacao.Validacao) {
                        enderecoTipoDTInclusao = enderecoTipoDataModel.Incluir(enderecoTipoDTValidacao);
                    } else {
                        enderecoTipoDTInclusao = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                    }
                } else {
                    enderecoTipoDTInclusao = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoDTInclusao = new EnderecoTipoDataTransfer();

                enderecoTipoDTInclusao.Validacao = false;
                enderecoTipoDTInclusao.Erro = true;
                enderecoTipoDTInclusao.IncluirErroMensagem("Erro em EnderecoTipoModel Incluir [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoDTValidacao = null;
            }

            return enderecoTipoDTInclusao;
        }

        public EnderecoTipoDataTransfer Alterar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoDataTransfer enderecoTipoDTValidacao;
            EnderecoTipoDataTransfer enderecoTipoDTAlteracao;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDataTransfer.EnderecoTipo.Alteracao = DateTime.Today;

                enderecoTipoDTValidacao = enderecoTipoBusiness.Validar(enderecoTipoDataTransfer);

                if (!enderecoTipoDTValidacao.Erro) {
                    if (enderecoTipoDTValidacao.Validacao) {
                        enderecoTipoDTAlteracao = enderecoTipoDataModel.Alterar(enderecoTipoDTValidacao);
                    } else {
                        enderecoTipoDTAlteracao = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                    }
                } else {
                    enderecoTipoDTAlteracao = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoDTAlteracao = new EnderecoTipoDataTransfer();

                enderecoTipoDTAlteracao.Validacao = false;
                enderecoTipoDTAlteracao.Erro = true;
                enderecoTipoDTAlteracao.IncluirErroMensagem("Erro em EnderecoTipoModel Alterar [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoDTValidacao = null;
            }

            return enderecoTipoDTAlteracao;
        }

        public EnderecoTipoDataTransfer Excluir(int id)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoDataTransfer enderecoTipoDTExclusao;

            try {
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDTExclusao = enderecoTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                enderecoTipoDTExclusao = new EnderecoTipoDataTransfer();

                enderecoTipoDTExclusao.Validacao = false;
                enderecoTipoDTExclusao.Erro = true;
                enderecoTipoDTExclusao.IncluirErroMensagem("Erro em EnderecoTipoModel Excluir [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
            }

            return enderecoTipoDTExclusao;
        }

        public EnderecoTipoDataTransfer Listar()
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoDataTransfer enderecoTipoDTLista;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDTLista = enderecoTipoDataModel.Listar();
            } catch (Exception ex) {
                enderecoTipoDTLista = new EnderecoTipoDataTransfer();

                enderecoTipoDTLista.Validacao = false;
                enderecoTipoDTLista.Erro = true;
                enderecoTipoDTLista.IncluirErroMensagem("Erro em EnderecoTipoModel Listar [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
            }

            return enderecoTipoDTLista;
        }

        public EnderecoTipoDataTransfer ConsultarPorId(int id)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoDataTransfer enderecoTipoDTForm;
            
            try {
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDTForm = enderecoTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                enderecoTipoDTForm = new EnderecoTipoDataTransfer();

                enderecoTipoDTForm.Validacao = false;
                enderecoTipoDTForm.Erro = true;
                enderecoTipoDTForm.IncluirErroMensagem("Erro em EnderecoTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
            }

            return enderecoTipoDTForm;
        }

        public EnderecoTipoDataTransfer Consultar(EnderecoTipoDataTransfer enderecoTipoDataTransfer)
        {
            EnderecoTipoDataModel enderecoTipoDataModel;
            EnderecoTipoBusiness enderecoTipoBusiness;
            EnderecoTipoDataTransfer enderecoTipoDTValidacao;
            EnderecoTipoDataTransfer enderecoTipoDTConsulta;

            try {
                enderecoTipoBusiness = new EnderecoTipoBusiness();
                enderecoTipoDataModel = new EnderecoTipoDataModel();

                enderecoTipoDTValidacao = enderecoTipoBusiness.ValidarConsulta(enderecoTipoDataTransfer);

                if (!enderecoTipoDTValidacao.Erro) {
                    if (enderecoTipoDTValidacao.Validacao) {
                        enderecoTipoDTConsulta = enderecoTipoDataModel.Consultar(enderecoTipoDTValidacao);
                    } else {
                        enderecoTipoDTConsulta = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                    }
                } else {
                    enderecoTipoDTConsulta = new EnderecoTipoDataTransfer(enderecoTipoDTValidacao);
                }
            } catch (Exception ex) {
                enderecoTipoDTConsulta = new EnderecoTipoDataTransfer();

                enderecoTipoDTConsulta.Validacao = false;
                enderecoTipoDTConsulta.Erro = true;
                enderecoTipoDTConsulta.IncluirErroMensagem("Erro em EnderecoTipoModel Consultar [" + ex.Message + "]");
            } finally {
                enderecoTipoDataModel = null;
                enderecoTipoBusiness = null;
                enderecoTipoDTValidacao = null;
            }

            return enderecoTipoDTConsulta;
        }
    }
}
