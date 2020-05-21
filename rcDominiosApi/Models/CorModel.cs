using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Models
{
    public class CorModel
    {
        public CorDataTransfer Incluir(CorDataTransfer corDataTransfer)
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorDataTransfer corDTValidacao;
            CorDataTransfer corDTInclusao;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corDataTransfer.Cor.Criacao = DateTime.Today;
                corDataTransfer.Cor.Alteracao = DateTime.Today;

                corDTValidacao = corBusiness.Validar(corDataTransfer);

                if (!corDTValidacao.Erro) {
                    if (corDTValidacao.Validacao) {
                        corDTInclusao = corDataModel.Incluir(corDTValidacao);
                    } else {
                        corDTInclusao = new CorDataTransfer(corDTValidacao);
                    }
                } else {
                    corDTInclusao = new CorDataTransfer(corDTValidacao);
                }
            } catch (Exception ex) {
                corDTInclusao = new CorDataTransfer();

                corDTInclusao.Validacao = false;
                corDTInclusao.Erro = true;
                corDTInclusao.IncluirErroMensagem("Erro em CorModel Incluir [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
                corDTValidacao = null;
            }

            return corDTInclusao;
        }

        public CorDataTransfer Alterar(CorDataTransfer corDataTransfer)
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorDataTransfer corDTValidacao;
            CorDataTransfer corDTAlteracao;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corDataTransfer.Cor.Alteracao = DateTime.Today;

                corDTValidacao = corBusiness.Validar(corDataTransfer);

                if (!corDTValidacao.Erro) {
                    if (corDTValidacao.Validacao) {
                        corDTAlteracao = corDataModel.Alterar(corDTValidacao);
                    } else {
                        corDTAlteracao = new CorDataTransfer(corDTValidacao);
                    }
                } else {
                    corDTAlteracao = new CorDataTransfer(corDTValidacao);
                }
            } catch (Exception ex) {
                corDTAlteracao = new CorDataTransfer();

                corDTAlteracao.Validacao = false;
                corDTAlteracao.Erro = true;
                corDTAlteracao.IncluirErroMensagem("Erro em CorModel Alterar [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
                corDTValidacao = null;
            }

            return corDTAlteracao;
        }

        public CorDataTransfer Excluir(int id)
        {
            CorDataModel corDataModel;
            CorDataTransfer corDTExclusao;

            try {
                corDataModel = new CorDataModel();

                corDTExclusao = corDataModel.Excluir(id);
            } catch (Exception ex) {
                corDTExclusao = new CorDataTransfer();

                corDTExclusao.Validacao = false;
                corDTExclusao.Erro = true;
                corDTExclusao.IncluirErroMensagem("Erro em CorModel Excluir [" + ex.Message + "]");
            } finally {
                corDataModel = null;
            }

            return corDTExclusao;
        }

        public CorDataTransfer Listar()
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorDataTransfer corDTLista;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corDTLista = corDataModel.Listar();
            } catch (Exception ex) {
                corDTLista = new CorDataTransfer();

                corDTLista.Validacao = false;
                corDTLista.Erro = true;
                corDTLista.IncluirErroMensagem("Erro em CorModel Listar [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
            }

            return corDTLista;
        }

        public CorDataTransfer ConsultarPorId(int id)
        {
            CorDataModel corDataModel;
            CorDataTransfer corDTForm;
            
            try {
                corDataModel = new CorDataModel();

                corDTForm = corDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                corDTForm = new CorDataTransfer();

                corDTForm.Validacao = false;
                corDTForm.Erro = true;
                corDTForm.IncluirErroMensagem("Erro em CorModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corDataModel = null;
            }

            return corDTForm;
        }
    }
}
