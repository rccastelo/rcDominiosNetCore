using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class EstadoCivilModel
    {
        public EstadoCivilDataTransfer Incluir(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilDataTransfer estadoCivilDTValidacao;
            EstadoCivilDataTransfer estadoCivilDTInclusao;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDataTransfer.EstadoCivil.Criacao = DateTime.Today;
                estadoCivilDataTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivilDTValidacao = estadoCivilBusiness.Validar(estadoCivilDataTransfer);

                if (!estadoCivilDTValidacao.Erro) {
                    if (estadoCivilDTValidacao.Validacao) {
                        estadoCivilDTInclusao = estadoCivilDataModel.Incluir(estadoCivilDTValidacao);
                    } else {
                        estadoCivilDTInclusao = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                    }
                } else {
                    estadoCivilDTInclusao = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                }
            } catch (Exception ex) {
                estadoCivilDTInclusao = new EstadoCivilDataTransfer();

                estadoCivilDTInclusao.Validacao = false;
                estadoCivilDTInclusao.Erro = true;
                estadoCivilDTInclusao.ErroMensagens.Add("Erro em EstadoCivilModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilDTValidacao = null;
            }

            return estadoCivilDTInclusao;
        }

        public EstadoCivilDataTransfer Alterar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilDataTransfer estadoCivilDTValidacao;
            EstadoCivilDataTransfer estadoCivilDTAlteracao;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDataTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivilDTValidacao = estadoCivilBusiness.Validar(estadoCivilDataTransfer);

                if (!estadoCivilDTValidacao.Erro) {
                    if (estadoCivilDTValidacao.Validacao) {
                        estadoCivilDTAlteracao = estadoCivilDataModel.Alterar(estadoCivilDTValidacao);
                    } else {
                        estadoCivilDTAlteracao = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                    }
                } else {
                    estadoCivilDTAlteracao = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                }
            } catch (Exception ex) {
                estadoCivilDTAlteracao = new EstadoCivilDataTransfer();

                estadoCivilDTAlteracao.Validacao = false;
                estadoCivilDTAlteracao.Erro = true;
                estadoCivilDTAlteracao.ErroMensagens.Add("Erro em EstadoCivilModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilDTValidacao = null;
            }

            return estadoCivilDTAlteracao;
        }

        public EstadoCivilDataTransfer Excluir(int id)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilDataTransfer estadoCivilDTExclusao;

            try {
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDTExclusao = estadoCivilDataModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivilDTExclusao = new EstadoCivilDataTransfer();

                estadoCivilDTExclusao.Validacao = false;
                estadoCivilDTExclusao.Erro = true;
                estadoCivilDTExclusao.ErroMensagens.Add("Erro em EstadoCivilModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
            }

            return estadoCivilDTExclusao;
        }

        public EstadoCivilDataTransfer Listar()
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilDataTransfer estadoCivilDTLista;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDTLista = estadoCivilDataModel.Listar();
            } catch (Exception ex) {
                estadoCivilDTLista = new EstadoCivilDataTransfer();

                estadoCivilDTLista.Validacao = false;
                estadoCivilDTLista.Erro = true;
                estadoCivilDTLista.ErroMensagens.Add("Erro em EstadoCivilModel Listar [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
            }

            return estadoCivilDTLista;
        }

        public EstadoCivilDataTransfer ConsultarPorId(int id)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilDataTransfer estadoCivilDTForm;
            
            try {
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDTForm = estadoCivilDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                estadoCivilDTForm = new EstadoCivilDataTransfer();

                estadoCivilDTForm.Validacao = false;
                estadoCivilDTForm.Erro = true;
                estadoCivilDTForm.ErroMensagens.Add("Erro em EstadoCivilModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
            }

            return estadoCivilDTForm;
        }

        public EstadoCivilDataTransfer Consultar(EstadoCivilDataTransfer estadoCivilDataTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilDataTransfer estadoCivilDTValidacao;
            EstadoCivilDataTransfer estadoCivilDTConsulta;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilDTValidacao = estadoCivilBusiness.ValidarConsulta(estadoCivilDataTransfer);

                if (!estadoCivilDTValidacao.Erro) {
                    if (estadoCivilDTValidacao.Validacao) {
                        estadoCivilDTConsulta = estadoCivilDataModel.Consultar(estadoCivilDTValidacao);
                    } else {
                        estadoCivilDTConsulta = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                    }
                } else {
                    estadoCivilDTConsulta = new EstadoCivilDataTransfer(estadoCivilDTValidacao);
                }
            } catch (Exception ex) {
                estadoCivilDTConsulta = new EstadoCivilDataTransfer();

                estadoCivilDTConsulta.Validacao = false;
                estadoCivilDTConsulta.Erro = true;
                estadoCivilDTConsulta.ErroMensagens.Add("Erro em EstadoCivilModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilDTValidacao = null;
            }

            return estadoCivilDTConsulta;
        }
    }
}
