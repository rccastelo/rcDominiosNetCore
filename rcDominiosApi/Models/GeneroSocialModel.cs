using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class GeneroSocialModel
    {
        public GeneroSocialTransfer Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialTransfer generoSocialValidacao;
            GeneroSocialTransfer generoSocialInclusao;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialTransfer.GeneroSocial.Criacao = DateTime.Today;
                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocialValidacao = generoSocialBusiness.Validar(generoSocialTransfer);

                if (!generoSocialValidacao.Erro) {
                    if (generoSocialValidacao.Validacao) {
                        generoSocialInclusao = generoSocialDataModel.Incluir(generoSocialValidacao);
                    } else {
                        generoSocialInclusao = new GeneroSocialTransfer(generoSocialValidacao);
                    }
                } else {
                    generoSocialInclusao = new GeneroSocialTransfer(generoSocialValidacao);
                }
            } catch (Exception ex) {
                generoSocialInclusao = new GeneroSocialTransfer();

                generoSocialInclusao.Validacao = false;
                generoSocialInclusao.Erro = true;
                generoSocialInclusao.IncluirMensagem("Erro em GeneroSocialModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialValidacao = null;
            }

            return generoSocialInclusao;
        }

        public GeneroSocialTransfer Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialTransfer generoSocialValidacao;
            GeneroSocialTransfer generoSocialAlteracao;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocialValidacao = generoSocialBusiness.Validar(generoSocialTransfer);

                if (!generoSocialValidacao.Erro) {
                    if (generoSocialValidacao.Validacao) {
                        generoSocialAlteracao = generoSocialDataModel.Alterar(generoSocialValidacao);
                    } else {
                        generoSocialAlteracao = new GeneroSocialTransfer(generoSocialValidacao);
                    }
                } else {
                    generoSocialAlteracao = new GeneroSocialTransfer(generoSocialValidacao);
                }
            } catch (Exception ex) {
                generoSocialAlteracao = new GeneroSocialTransfer();

                generoSocialAlteracao.Validacao = false;
                generoSocialAlteracao.Erro = true;
                generoSocialAlteracao.IncluirMensagem("Erro em GeneroSocialModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialValidacao = null;
            }

            return generoSocialAlteracao;
        }

        public GeneroSocialTransfer Excluir(int id)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocial = generoSocialDataModel.Excluir(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer ConsultarPorId(int id)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialTransfer generoSocial;
            
            try {
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocial = generoSocialDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer Consultar(GeneroSocialTransfer generoSocialListaTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialTransfer generoSocialValidacao;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialValidacao = generoSocialBusiness.ValidarConsulta(generoSocialListaTransfer);

                if (!generoSocialValidacao.Erro) {
                    if (generoSocialValidacao.Validacao) {
                        generoSocialLista = generoSocialDataModel.Consultar(generoSocialValidacao);

                        if (generoSocialLista != null) {
                            if (generoSocialLista.TotalRegistros > 0) {
                                if (generoSocialLista.RegistrosPorPagina < 1) {
                                    generoSocialLista.RegistrosPorPagina = 30;
                                } else if (generoSocialLista.RegistrosPorPagina > 200) {
                                    generoSocialLista.RegistrosPorPagina = 30;
                                }
                                generoSocialLista.PaginaAtual = (generoSocialListaTransfer.PaginaAtual < 1 ? 1 : generoSocialListaTransfer.PaginaAtual);
                                generoSocialLista.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(generoSocialLista.TotalRegistros) 
                                    / @Convert.ToDecimal(generoSocialLista.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        generoSocialLista = new GeneroSocialTransfer(generoSocialValidacao);
                    }
                } else {
                    generoSocialLista = new GeneroSocialTransfer(generoSocialValidacao);
                }
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialValidacao = null;
            }

            return generoSocialLista;
        }
    }
}
