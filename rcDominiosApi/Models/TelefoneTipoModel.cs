using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class TelefoneTipoModel
    {
        public TelefoneTipoTransfer Incluir(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoTransfer telefoneTipoValidacao;
            TelefoneTipoTransfer telefoneTipoInclusao;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoTransfer.TelefoneTipo.Criacao = DateTime.Today;
                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipoValidacao = telefoneTipoBusiness.Validar(telefoneTipoTransfer);

                if (!telefoneTipoValidacao.Erro) {
                    if (telefoneTipoValidacao.Validacao) {
                        telefoneTipoInclusao = telefoneTipoDataModel.Incluir(telefoneTipoValidacao);
                    } else {
                        telefoneTipoInclusao = new TelefoneTipoTransfer(telefoneTipoValidacao);
                    }
                } else {
                    telefoneTipoInclusao = new TelefoneTipoTransfer(telefoneTipoValidacao);
                }
            } catch (Exception ex) {
                telefoneTipoInclusao = new TelefoneTipoTransfer();

                telefoneTipoInclusao.Validacao = false;
                telefoneTipoInclusao.Erro = true;
                telefoneTipoInclusao.IncluirMensagem("Erro em TelefoneTipoModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
                telefoneTipoValidacao = null;
            }

            return telefoneTipoInclusao;
        }

        public TelefoneTipoTransfer Alterar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoTransfer telefoneTipoValidacao;
            TelefoneTipoTransfer telefoneTipoAlteracao;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoTransfer.TelefoneTipo.Alteracao = DateTime.Today;

                telefoneTipoValidacao = telefoneTipoBusiness.Validar(telefoneTipoTransfer);

                if (!telefoneTipoValidacao.Erro) {
                    if (telefoneTipoValidacao.Validacao) {
                        telefoneTipoAlteracao = telefoneTipoDataModel.Alterar(telefoneTipoValidacao);
                    } else {
                        telefoneTipoAlteracao = new TelefoneTipoTransfer(telefoneTipoValidacao);
                    }
                } else {
                    telefoneTipoAlteracao = new TelefoneTipoTransfer(telefoneTipoValidacao);
                }
            } catch (Exception ex) {
                telefoneTipoAlteracao = new TelefoneTipoTransfer();

                telefoneTipoAlteracao.Validacao = false;
                telefoneTipoAlteracao.Erro = true;
                telefoneTipoAlteracao.IncluirMensagem("Erro em TelefoneTipoModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
                telefoneTipoValidacao = null;
            }

            return telefoneTipoAlteracao;
        }

        public TelefoneTipoTransfer Excluir(int id)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipo = telefoneTipoDataModel.Excluir(id);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer ConsultarPorId(int id)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoTransfer telefoneTipo;
            
            try {
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipo = telefoneTipoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirMensagem("Erro em TelefoneTipoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer Consultar(TelefoneTipoTransfer telefoneTipoListaTransfer)
        {
            TelefoneTipoDataModel telefoneTipoDataModel;
            TelefoneTipoBusiness telefoneTipoBusiness;
            TelefoneTipoTransfer telefoneTipoValidacao;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoBusiness = new TelefoneTipoBusiness();
                telefoneTipoDataModel = new TelefoneTipoDataModel();

                telefoneTipoValidacao = telefoneTipoBusiness.ValidarConsulta(telefoneTipoListaTransfer);

                if (!telefoneTipoValidacao.Erro) {
                    if (telefoneTipoValidacao.Validacao) {
                        telefoneTipoLista = telefoneTipoDataModel.Consultar(telefoneTipoValidacao);

                        if (telefoneTipoLista != null) {
                            if (telefoneTipoLista.Paginacao.TotalRegistros > 0) {
                                if (telefoneTipoLista.Paginacao.RegistrosPorPagina < 1) {
                                    telefoneTipoLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (telefoneTipoLista.Paginacao.RegistrosPorPagina > 200) {
                                    telefoneTipoLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                telefoneTipoLista.Paginacao.PaginaAtual = (telefoneTipoListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : telefoneTipoListaTransfer.Paginacao.PaginaAtual);
                                telefoneTipoLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(telefoneTipoLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(telefoneTipoLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        telefoneTipoLista = new TelefoneTipoTransfer(telefoneTipoValidacao);
                    }
                } else {
                    telefoneTipoLista = new TelefoneTipoTransfer(telefoneTipoValidacao);
                }
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirMensagem("Erro em TelefoneTipoModel Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoDataModel = null;
                telefoneTipoBusiness = null;
                telefoneTipoValidacao = null;
            }

            return telefoneTipoLista;
        }
    }
}
