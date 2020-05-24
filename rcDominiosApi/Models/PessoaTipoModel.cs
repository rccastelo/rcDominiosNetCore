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
                pessoaTipoInclusao.IncluirErroMensagem("Erro em PessoaTipoModel Incluir [" + ex.Message + "]");
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
                pessoaTipoAlteracao.IncluirErroMensagem("Erro em PessoaTipoModel Alterar [" + ex.Message + "]");
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
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel Excluir [" + ex.Message + "]");
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
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoModel ConsultarPorId [" + ex.Message + "]");
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
                            if (pessoaTipoLista.TotalRegistros > 0) {
                                if (pessoaTipoLista.RegistrosPorPagina < 1) {
                                    pessoaTipoLista.RegistrosPorPagina = 30;
                                } else if (pessoaTipoLista.RegistrosPorPagina > 200) {
                                    pessoaTipoLista.RegistrosPorPagina = 30;
                                }
                                pessoaTipoLista.PaginaAtual = (pessoaTipoListaTransfer.PaginaAtual < 1 ? 1 : pessoaTipoListaTransfer.PaginaAtual);
                                pessoaTipoLista.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(pessoaTipoLista.TotalRegistros) 
                                    / @Convert.ToDecimal(pessoaTipoLista.RegistrosPorPagina)));
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
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoDataModel = null;
                pessoaTipoBusiness = null;
                pessoaTipoValidacao = null;
            }

            return pessoaTipoLista;
        }
    }
}
