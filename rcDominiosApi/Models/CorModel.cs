using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class CorModel
    {
        public CorTransfer Incluir(CorTransfer corTransfer)
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorTransfer corValidacao;
            CorTransfer corInclusao;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corTransfer.Cor.Criacao = DateTime.Today;
                corTransfer.Cor.Alteracao = DateTime.Today;

                corValidacao = corBusiness.Validar(corTransfer);

                if (!corValidacao.Erro) {
                    if (corValidacao.Validacao) {
                        corInclusao = corDataModel.Incluir(corValidacao);
                    } else {
                        corInclusao = new CorTransfer(corValidacao);
                    }
                } else {
                    corInclusao = new CorTransfer(corValidacao);
                }
            } catch (Exception ex) {
                corInclusao = new CorTransfer();

                corInclusao.Validacao = false;
                corInclusao.Erro = true;
                corInclusao.IncluirErroMensagem("Erro em CorModel Incluir [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
                corValidacao = null;
            }

            return corInclusao;
        }

        public CorTransfer Alterar(CorTransfer corTransfer)
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorTransfer corValidacao;
            CorTransfer corAlteracao;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corTransfer.Cor.Alteracao = DateTime.Today;

                corValidacao = corBusiness.Validar(corTransfer);

                if (!corValidacao.Erro) {
                    if (corValidacao.Validacao) {
                        corAlteracao = corDataModel.Alterar(corValidacao);
                    } else {
                        corAlteracao = new CorTransfer(corValidacao);
                    }
                } else {
                    corAlteracao = new CorTransfer(corValidacao);
                }
            } catch (Exception ex) {
                corAlteracao = new CorTransfer();

                corAlteracao.Validacao = false;
                corAlteracao.Erro = true;
                corAlteracao.IncluirErroMensagem("Erro em CorModel Alterar [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
                corValidacao = null;
            }

            return corAlteracao;
        }

        public CorTransfer Excluir(int id)
        {
            CorDataModel corDataModel;
            CorTransfer cor;

            try {
                corDataModel = new CorDataModel();

                cor = corDataModel.Excluir(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel Excluir [" + ex.Message + "]");
            } finally {
                corDataModel = null;
            }

            return cor;
        }

        public CorTransfer ConsultarPorId(int id)
        {
            CorDataModel corDataModel;
            CorTransfer cor;
            
            try {
                corDataModel = new CorDataModel();

                cor = corDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                cor = new CorTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirErroMensagem("Erro em CorModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corDataModel = null;
            }

            return cor;
        }

        public CorTransfer Consultar(CorTransfer corListaTransfer)
        {
            CorDataModel corDataModel;
            CorBusiness corBusiness;
            CorTransfer corValidacao;
            CorTransfer corLista;

            try {
                corBusiness = new CorBusiness();
                corDataModel = new CorDataModel();

                corValidacao = corBusiness.ValidarConsulta(corListaTransfer);

                if (!corValidacao.Erro) {
                    if (corValidacao.Validacao) {
                        corLista = corDataModel.Consultar(corValidacao);

                        if (corLista != null) {
                            corLista.PaginaAtual = (corListaTransfer.PaginaAtual < 1 ? 1 : corListaTransfer.PaginaAtual);
                            corLista.TotalPaginas = 
                                Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(corLista.TotalRegistros) 
                                / @Convert.ToDecimal(corLista.RegistrosPorPagina)));
                        }
                    } else {
                        corLista = new CorTransfer(corValidacao);
                    }
                } else {
                    corLista = new CorTransfer(corValidacao);
                }
            } catch (Exception ex) {
                corLista = new CorTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirErroMensagem("Erro em CorModel Consultar [" + ex.Message + "]");
            } finally {
                corDataModel = null;
                corBusiness = null;
                corValidacao = null;
            }

            return corLista;
        }
    }
}
