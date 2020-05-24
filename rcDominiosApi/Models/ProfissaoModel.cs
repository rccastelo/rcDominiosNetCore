using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class ProfissaoModel
    {
        public ProfissaoTransfer Incluir(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoTransfer profissaoValidacao;
            ProfissaoTransfer profissaoInclusao;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoTransfer.Profissao.Criacao = DateTime.Today;
                profissaoTransfer.Profissao.Alteracao = DateTime.Today;

                profissaoValidacao = profissaoBusiness.Validar(profissaoTransfer);

                if (!profissaoValidacao.Erro) {
                    if (profissaoValidacao.Validacao) {
                        profissaoInclusao = profissaoDataModel.Incluir(profissaoValidacao);
                    } else {
                        profissaoInclusao = new ProfissaoTransfer(profissaoValidacao);
                    }
                } else {
                    profissaoInclusao = new ProfissaoTransfer(profissaoValidacao);
                }
            } catch (Exception ex) {
                profissaoInclusao = new ProfissaoTransfer();

                profissaoInclusao.Validacao = false;
                profissaoInclusao.Erro = true;
                profissaoInclusao.IncluirErroMensagem("Erro em ProfissaoModel Incluir [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoValidacao = null;
            }

            return profissaoInclusao;
        }

        public ProfissaoTransfer Alterar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoTransfer profissaoValidacao;
            ProfissaoTransfer profissaoAlteracao;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoTransfer.Profissao.Alteracao = DateTime.Today;

                profissaoValidacao = profissaoBusiness.Validar(profissaoTransfer);

                if (!profissaoValidacao.Erro) {
                    if (profissaoValidacao.Validacao) {
                        profissaoAlteracao = profissaoDataModel.Alterar(profissaoValidacao);
                    } else {
                        profissaoAlteracao = new ProfissaoTransfer(profissaoValidacao);
                    }
                } else {
                    profissaoAlteracao = new ProfissaoTransfer(profissaoValidacao);
                }
            } catch (Exception ex) {
                profissaoAlteracao = new ProfissaoTransfer();

                profissaoAlteracao.Validacao = false;
                profissaoAlteracao.Erro = true;
                profissaoAlteracao.IncluirErroMensagem("Erro em ProfissaoModel Alterar [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoValidacao = null;
            }

            return profissaoAlteracao;
        }

        public ProfissaoTransfer Excluir(int id)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoTransfer profissao;

            try {
                profissaoDataModel = new ProfissaoDataModel();

                profissao = profissaoDataModel.Excluir(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoModel Excluir [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
            }

            return profissao;
        }

        public ProfissaoTransfer ConsultarPorId(int id)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoTransfer profissao;
            
            try {
                profissaoDataModel = new ProfissaoDataModel();

                profissao = profissaoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
            }

            return profissao;
        }

        public ProfissaoTransfer Consultar(ProfissaoTransfer profissaoListaTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoTransfer profissaoValidacao;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoValidacao = profissaoBusiness.ValidarConsulta(profissaoListaTransfer);

                if (!profissaoValidacao.Erro) {
                    if (profissaoValidacao.Validacao) {
                        profissaoLista = profissaoDataModel.Consultar(profissaoValidacao);

                        if (profissaoLista != null) {
                            profissaoLista.PaginaAtual = (profissaoListaTransfer.PaginaAtual < 1 ? 1 : profissaoListaTransfer.PaginaAtual);
                            profissaoLista.TotalPaginas = 
                                Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(profissaoLista.TotalRegistros) 
                                / @Convert.ToDecimal(profissaoLista.RegistrosPorPagina)));
                        }
                    } else {
                        profissaoLista = new ProfissaoTransfer(profissaoValidacao);
                    }
                } else {
                    profissaoLista = new ProfissaoTransfer(profissaoValidacao);
                }
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoValidacao = null;
            }

            return profissaoLista;
        }
    }
}
