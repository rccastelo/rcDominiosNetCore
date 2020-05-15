using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosApi.Models
{
    public class ContaBancariaModel
    {
        public ContaBancariaDataTransfer Incluir(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaDataTransfer contaBancariaDTValidacao;
            ContaBancariaDataTransfer contaBancariaDTInclusao;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaDataTransfer.ContaBancaria.Criacao = DateTime.Today;
                contaBancariaDataTransfer.ContaBancaria.Alteracao = DateTime.Today;

                contaBancariaDTValidacao = contaBancariaBusiness.Validar(contaBancariaDataTransfer);

                if (!contaBancariaDTValidacao.Erro) {
                    if (contaBancariaDTValidacao.Validacao) {
                        contaBancariaDTInclusao = contaBancariaDataModel.Incluir(contaBancariaDTValidacao);
                    } else {
                        contaBancariaDTInclusao = new ContaBancariaDataTransfer(contaBancariaDTValidacao);
                    }
                } else {
                    contaBancariaDTInclusao = new ContaBancariaDataTransfer(contaBancariaDTValidacao);
                }
            } catch (Exception ex) {
                contaBancariaDTInclusao = new ContaBancariaDataTransfer();

                contaBancariaDTInclusao.Validacao = false;
                contaBancariaDTInclusao.Erro = true;
                contaBancariaDTInclusao.ErroMensagens.Add("Erro em ContaBancariaModel Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
                contaBancariaDTValidacao = null;
            }

            return contaBancariaDTInclusao;
        }

        public ContaBancariaDataTransfer Alterar(ContaBancariaDataTransfer contaBancariaDataTransfer)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaDataTransfer contaBancariaDTValidacao;
            ContaBancariaDataTransfer contaBancariaDTAlteracao;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaDataTransfer.ContaBancaria.Alteracao = DateTime.Today;

                contaBancariaDTValidacao = contaBancariaBusiness.Validar(contaBancariaDataTransfer);

                if (!contaBancariaDTValidacao.Erro) {
                    if (contaBancariaDTValidacao.Validacao) {
                        contaBancariaDTAlteracao = contaBancariaDataModel.Alterar(contaBancariaDTValidacao);
                    } else {
                        contaBancariaDTAlteracao = new ContaBancariaDataTransfer(contaBancariaDTValidacao);
                    }
                } else {
                    contaBancariaDTAlteracao = new ContaBancariaDataTransfer(contaBancariaDTValidacao);
                }
            } catch (Exception ex) {
                contaBancariaDTAlteracao = new ContaBancariaDataTransfer();

                contaBancariaDTAlteracao.Validacao = false;
                contaBancariaDTAlteracao.Erro = true;
                contaBancariaDTAlteracao.ErroMensagens.Add("Erro em ContaBancariaModel Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
                contaBancariaDTValidacao = null;
            }

            return contaBancariaDTAlteracao;
        }

        public ContaBancariaDataTransfer Excluir(int id)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaDataTransfer contaBancariaDTExclusao;

            try {
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaDTExclusao = contaBancariaDataModel.Excluir(id);
            } catch (Exception ex) {
                contaBancariaDTExclusao = new ContaBancariaDataTransfer();

                contaBancariaDTExclusao.Validacao = false;
                contaBancariaDTExclusao.Erro = true;
                contaBancariaDTExclusao.ErroMensagens.Add("Erro em ContaBancariaModel Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
            }

            return contaBancariaDTExclusao;
        }

        public ContaBancariaDataTransfer Listar()
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaDataTransfer contaBancariaDTLista;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaDTLista = contaBancariaDataModel.Listar();
            } catch (Exception ex) {
                contaBancariaDTLista = new ContaBancariaDataTransfer();

                contaBancariaDTLista.Validacao = false;
                contaBancariaDTLista.Erro = true;
                contaBancariaDTLista.ErroMensagens.Add("Erro em ContaBancariaModel Listar [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
            }

            return contaBancariaDTLista;
        }

        public ContaBancariaDataTransfer ConsultarPorId(int id)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaDataTransfer contaBancariaDTForm;
            
            try {
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaDTForm = contaBancariaDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                contaBancariaDTForm = new ContaBancariaDataTransfer();

                contaBancariaDTForm.Validacao = false;
                contaBancariaDTForm.Erro = true;
                contaBancariaDTForm.ErroMensagens.Add("Erro em ContaBancariaModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
            }

            return contaBancariaDTForm;
        }
    }
}
