using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class PessoaTipoModel
    {
        public PessoaTipoTransfer Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoTransfer pessoaTipoValidacao;
            PessoaTipoTransfer pessoaTipoInclusao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoTransfer.PessoaTipo.Criacao = DateTime.Today;
                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipoValidacao = pessoaTipoBusiness.Validar(pessoaTipoTransfer);

                if (!pessoaTipoValidacao.Erro) {
                    if (pessoaTipoValidacao.Validacao) {
                        pessoaTipoInclusao = pessoaTipoDataModel.Incluir(pessoaTipoValidacao);
                    } else {
                        pessoaTipoInclusao = new PessoaTipoTransfer(pessoaTipoValidacao);
                    }
                } else {
                    pessoaTipoInclusao = new PessoaTipoTransfer(pessoaTipoValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoInclusao = new PessoaTipoTransfer();

                pessoaTipoInclusao.Validacao = false;
                pessoaTipoInclusao.Erro = true;
                pessoaTipoInclusao.IncluirMensagem("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoValidacao = null;
            }

            return pessoaTipoInclusao;
        }

        public PessoaTipoTransfer Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoTransfer pessoaTipoValidacao;
            PessoaTipoTransfer pessoaTipoAlteracao;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoTransfer.PessoaTipo.Alteracao = DateTime.Today;

                pessoaTipoValidacao = pessoaTipoBusiness.Validar(pessoaTipoTransfer);

                if (!pessoaTipoValidacao.Erro) {
                    if (pessoaTipoValidacao.Validacao) {
                        pessoaTipoAlteracao = pessoaTipoDataModel.Alterar(pessoaTipoValidacao);
                    } else {
                        pessoaTipoAlteracao = new PessoaTipoTransfer(pessoaTipoValidacao);
                    }
                } else {
                    pessoaTipoAlteracao = new PessoaTipoTransfer(pessoaTipoValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoAlteracao = new PessoaTipoTransfer();

                pessoaTipoAlteracao.Validacao = false;
                pessoaTipoAlteracao.Erro = true;
                pessoaTipoAlteracao.IncluirMensagem("Erro em PessoaTipoModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoValidacao = null;
            }

            return pessoaTipoAlteracao;
        }

        public PessoaTipoTransfer Excluir(int id)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipo = pessoaTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer ConsultarPorId(int id)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoTransfer pessoaTipo;
            
            try {
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipo = pessoaTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirMensagem("Erro em PessoaTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Consultar(PessoaTipoTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoDataModel pessoaTipoDataModel;
            PessoaTipoBusiness pessoaTipoBusiness;
            PessoaTipoTransfer pessoaTipoValidacao;
            PessoaTipoTransfer pessoaTipoLista;

            try {
                pessoaTipoBusiness = new PessoaTipoBusiness();
                pessoaTipoDataModel = new PessoaTipoDataModel();

                pessoaTipoValidacao = pessoaTipoBusiness.ValidarConsulta(pessoaTipoListaTransfer);

                if (!pessoaTipoValidacao.Erro) {
                    if (pessoaTipoValidacao.Validacao) {
                        pessoaTipoLista = pessoaTipoDataModel.Consultar(pessoaTipoValidacao);

                        if (pessoaTipoLista != null) {
                            if (pessoaTipoLista.Paginacao.TotalRegistros > 0) {
                                if (pessoaTipoLista.Paginacao.RegistrosPorPagina < 1) {
                                    pessoaTipoLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (pessoaTipoLista.Paginacao.RegistrosPorPagina > 200) {
                                    pessoaTipoLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                pessoaTipoLista.Paginacao.PaginaAtual = (pessoaTipoListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : pessoaTipoListaTransfer.Paginacao.PaginaAtual);
                                pessoaTipoLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(pessoaTipoLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(pessoaTipoLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        pessoaTipoLista = new PessoaTipoTransfer(pessoaTipoValidacao);
                    }
                } else {
                    pessoaTipoLista = new PessoaTipoTransfer(pessoaTipoValidacao);
                }
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirMensagem("Erro em PessoaTipoModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoValidacao = null;
            }

            return pessoaTipoLista;
        }
    }
}
