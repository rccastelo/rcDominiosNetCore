using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class PessoaTipoModel
    {
        public PessoaTipoDataTransfer Incluir(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoDataTransfer pessoaTipoDTValidacao;
            PessoaTipoDataTransfer pessoaTipoDTInclusao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDataTransfer.PessoaTipo.Criacao = DateTime.Today;
                pessoaTipoDataTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipoDTValidacao = pessoaTipoBusiness.Validar(pessoaTipoDataTransfer);

                if (!pessoaTipoDTValidacao.Erro) {
                    if (pessoaTipoDTValidacao.Validacao) {
                        pessoaTipoDTInclusao = pessoaTipoDataModel.Incluir(pessoaTipoDTValidacao);
                    } else {
                        pessoaTipoDTInclusao = new PessoaTipoDataTransfer(pessoaTipoDTValidacao);
                    }
                } else {
                    pessoaTipoDTInclusao = new PessoaTipoDataTransfer(pessoaTipoDTValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoDTInclusao = new PessoaTipoDataTransfer();

                pessoaTipoDTInclusao.Validacao = false;
                pessoaTipoDTInclusao.Erro = true;
                pessoaTipoDTInclusao.ErroMensagens.Add("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoDTValidacao = null;
            }

            return pessoaTipoDTInclusao;
        }

        public PessoaTipoDataTransfer Alterar(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoDataTransfer pessoaTipoDTValidacao;
            PessoaTipoDataTransfer pessoaTipoDTAlteracao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDataTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipoDTValidacao = pessoaTipoBusiness.Validar(pessoaTipoDataTransfer);

                if (!pessoaTipoDTValidacao.Erro) {
                    if (pessoaTipoDTValidacao.Validacao) {
                        pessoaTipoDTAlteracao = pessoaTipoDataModel.Alterar(pessoaTipoDTValidacao);
                    } else {
                        pessoaTipoDTAlteracao = new PessoaTipoDataTransfer(pessoaTipoDTValidacao);
                    }
                } else {
                    pessoaTipoDTAlteracao = new PessoaTipoDataTransfer(pessoaTipoDTValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoDTAlteracao = new PessoaTipoDataTransfer();

                pessoaTipoDTAlteracao.Validacao = false;
                pessoaTipoDTAlteracao.Erro = true;
                pessoaTipoDTAlteracao.ErroMensagens.Add("Erro em PessoaTipoModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoDTValidacao = null;
            }

            return pessoaTipoDTAlteracao;
        }

        public PessoaTipoDataTransfer Excluir(int id)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoDataTransfer pessoaTipoDTExclusao;

            try {
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDTExclusao = pessoaTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipoDTExclusao = new PessoaTipoDataTransfer();

                pessoaTipoDTExclusao.Validacao = false;
                pessoaTipoDTExclusao.Erro = true;
                pessoaTipoDTExclusao.ErroMensagens.Add("Erro em PessoaTipoModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
            }

            return pessoaTipoDTExclusao;
        }

        public PessoaTipoDataTransfer Listar()
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoDataTransfer pessoaTipoDTLista;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDTLista = pessoaTipoDataModel.Listar();
            } catch (Exception ex) {
                pessoaTipoDTLista = new PessoaTipoDataTransfer();

                pessoaTipoDTLista.Validacao = false;
                pessoaTipoDTLista.Erro = true;
                pessoaTipoDTLista.ErroMensagens.Add("Erro em PessoaTipoModel Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
            }

            return pessoaTipoDTLista;
        }

        public PessoaTipoDataTransfer ConsultarPorId(int id)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoDataTransfer pessoaTipoDTForm;
            
            try {
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDTForm = pessoaTipoDataModel.ConsultarPorId(id);
            } catch {
                pessoaTipoDTForm = new PessoaTipoDataTransfer();

                pessoaTipoDTForm.Validacao = false;
                pessoaTipoDTForm.ValidacaoMensagens.Add("Erro em PessoaTipoModel ConsultarPorId");
            } finally {
                pessoaTipoDataModel = null;
            }

            return pessoaTipoDTForm;
        }
    }
}
