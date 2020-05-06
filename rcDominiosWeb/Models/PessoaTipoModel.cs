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
            PessoaTipoDataTransfer pessoaTipoDataTransferValidacao;
            PessoaTipoDataTransfer pessoaTipoDataTransferInclusao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDataTransfer.PessoaTipo.Criacao = DateTime.Today;
                pessoaTipoDataTransfer.PessoaTipo.Alteracao = DateTime.Today;
                pessoaTipoDataTransfer.PessoaTipo.Ativo = true;

                pessoaTipoDataTransferValidacao = pessoaTipoBusiness.Validar(pessoaTipoDataTransfer);

                if (!pessoaTipoDataTransferValidacao.Erro) {
                    if (pessoaTipoDataTransferValidacao.Validacao) {
                        pessoaTipoDataTransferInclusao = pessoaTipoDataModel.Incluir(pessoaTipoDataTransferValidacao);
                    } else {
                        pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer(pessoaTipoDataTransferValidacao);
                    }
                } else {
                    pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer(pessoaTipoDataTransferValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoDataTransferInclusao = new PessoaTipoDataTransfer();

                pessoaTipoDataTransferInclusao.Validacao = false;
                pessoaTipoDataTransferInclusao.Erro = true;
                pessoaTipoDataTransferInclusao.ErroMensagens.Add("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoDataTransferValidacao = null;
            }

            return pessoaTipoDataTransferInclusao;
        }

        public PessoaTipoDataTransfer Listar()
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoDataTransfer pessoaTipoDataTransferLista;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoDataTransferLista = pessoaTipoDataModel.Listar();
            } catch (Exception ex) {
                pessoaTipoDataTransferLista = new PessoaTipoDataTransfer();

                pessoaTipoDataTransferLista.Validacao = false;
                pessoaTipoDataTransferLista.Erro = true;
                pessoaTipoDataTransferLista.ErroMensagens.Add("Erro em PessoaTipoModel Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
            }

            return pessoaTipoDataTransferLista;
        }
    }
}
