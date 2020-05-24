using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class EstadoCivilModel
    {
        public EstadoCivilTransfer Incluir(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilTransfer estadoCivilValidacao;
            EstadoCivilTransfer estadoCivilInclusao;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilTransfer.EstadoCivil.Criacao = DateTime.Today;
                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivilValidacao = estadoCivilBusiness.Validar(estadoCivilTransfer);

                if (!estadoCivilValidacao.Erro) {
                    if (estadoCivilValidacao.Validacao) {
                        estadoCivilInclusao = estadoCivilDataModel.Incluir(estadoCivilValidacao);
                    } else {
                        estadoCivilInclusao = new EstadoCivilTransfer(estadoCivilValidacao);
                    }
                } else {
                    estadoCivilInclusao = new EstadoCivilTransfer(estadoCivilValidacao);
                }
            } catch (Exception ex) {
                estadoCivilInclusao = new EstadoCivilTransfer();

                estadoCivilInclusao.Validacao = false;
                estadoCivilInclusao.Erro = true;
                estadoCivilInclusao.IncluirErroMensagem("Erro em EstadoCivilModel Incluir [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilValidacao = null;
            }

            return estadoCivilInclusao;
        }

        public EstadoCivilTransfer Alterar(EstadoCivilTransfer estadoCivilTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilTransfer estadoCivilValidacao;
            EstadoCivilTransfer estadoCivilAlteracao;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilTransfer.EstadoCivil.Alteracao = DateTime.Today;

                estadoCivilValidacao = estadoCivilBusiness.Validar(estadoCivilTransfer);

                if (!estadoCivilValidacao.Erro) {
                    if (estadoCivilValidacao.Validacao) {
                        estadoCivilAlteracao = estadoCivilDataModel.Alterar(estadoCivilValidacao);
                    } else {
                        estadoCivilAlteracao = new EstadoCivilTransfer(estadoCivilValidacao);
                    }
                } else {
                    estadoCivilAlteracao = new EstadoCivilTransfer(estadoCivilValidacao);
                }
            } catch (Exception ex) {
                estadoCivilAlteracao = new EstadoCivilTransfer();

                estadoCivilAlteracao.Validacao = false;
                estadoCivilAlteracao.Erro = true;
                estadoCivilAlteracao.IncluirErroMensagem("Erro em EstadoCivilModel Alterar [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilValidacao = null;
            }

            return estadoCivilAlteracao;
        }

        public EstadoCivilTransfer Excluir(int id)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilTransfer estadoCivil;

            try {
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivil = estadoCivilDataModel.Excluir(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel Excluir [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer ConsultarPorId(int id)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilTransfer estadoCivil;
            
            try {
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivil = estadoCivilDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                estadoCivil = new EstadoCivilTransfer();

                estadoCivil.Validacao = false;
                estadoCivil.Erro = true;
                estadoCivil.IncluirErroMensagem("Erro em EstadoCivilModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
            }

            return estadoCivil;
        }

        public EstadoCivilTransfer Consultar(EstadoCivilTransfer estadoCivilListaTransfer)
        {
            EstadoCivilDataModel estadoCivilDataModel;
            EstadoCivilBusiness estadoCivilBusiness;
            EstadoCivilTransfer estadoCivilValidacao;
            EstadoCivilTransfer estadoCivilLista;

            try {
                estadoCivilBusiness = new EstadoCivilBusiness();
                estadoCivilDataModel = new EstadoCivilDataModel();

                estadoCivilValidacao = estadoCivilBusiness.ValidarConsulta(estadoCivilListaTransfer);

                if (!estadoCivilValidacao.Erro) {
                    if (estadoCivilValidacao.Validacao) {
                        estadoCivilLista = estadoCivilDataModel.Consultar(estadoCivilValidacao);

                        if (estadoCivilLista != null) {
                            estadoCivilLista.PaginaAtual = (estadoCivilListaTransfer.PaginaAtual < 1 ? 1 : estadoCivilListaTransfer.PaginaAtual);
                            estadoCivilLista.TotalPaginas = 
                                Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(estadoCivilLista.TotalRegistros) 
                                / @Convert.ToDecimal(estadoCivilLista.RegistrosPorPagina)));
                        }
                    } else {
                        estadoCivilLista = new EstadoCivilTransfer(estadoCivilValidacao);
                    }
                } else {
                    estadoCivilLista = new EstadoCivilTransfer(estadoCivilValidacao);
                }
            } catch (Exception ex) {
                estadoCivilLista = new EstadoCivilTransfer();

                estadoCivilLista.Validacao = false;
                estadoCivilLista.Erro = true;
                estadoCivilLista.IncluirErroMensagem("Erro em EstadoCivilModel Consultar [" + ex.Message + "]");
            } finally {
                estadoCivilDataModel = null;
                estadoCivilBusiness = null;
                estadoCivilValidacao = null;
            }

            return estadoCivilLista;
        }
    }
}
