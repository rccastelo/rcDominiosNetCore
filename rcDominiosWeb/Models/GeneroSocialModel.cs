using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class GeneroSocialModel
    {
        public GeneroSocialDataTransfer Incluir(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialDataTransfer generoSocialDTValidacao;
            GeneroSocialDataTransfer generoSocialDTInclusao;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDataTransfer.GeneroSocial.Criacao = DateTime.Today;
                generoSocialDataTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocialDTValidacao = generoSocialBusiness.Validar(generoSocialDataTransfer);

                if (!generoSocialDTValidacao.Erro) {
                    if (generoSocialDTValidacao.Validacao) {
                        generoSocialDTInclusao = generoSocialDataModel.Incluir(generoSocialDTValidacao);
                    } else {
                        generoSocialDTInclusao = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                    }
                } else {
                    generoSocialDTInclusao = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                }
            } catch (Exception ex) {
                generoSocialDTInclusao = new GeneroSocialDataTransfer();

                generoSocialDTInclusao.Validacao = false;
                generoSocialDTInclusao.Erro = true;
                generoSocialDTInclusao.IncluirErroMensagem("Erro em GeneroSocialModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialDTValidacao = null;
            }

            return generoSocialDTInclusao;
        }

        public GeneroSocialDataTransfer Alterar(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialDataTransfer generoSocialDTValidacao;
            GeneroSocialDataTransfer generoSocialDTAlteracao;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDataTransfer.GeneroSocial.Alteracao = DateTime.Today;

                generoSocialDTValidacao = generoSocialBusiness.Validar(generoSocialDataTransfer);

                if (!generoSocialDTValidacao.Erro) {
                    if (generoSocialDTValidacao.Validacao) {
                        generoSocialDTAlteracao = generoSocialDataModel.Alterar(generoSocialDTValidacao);
                    } else {
                        generoSocialDTAlteracao = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                    }
                } else {
                    generoSocialDTAlteracao = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                }
            } catch (Exception ex) {
                generoSocialDTAlteracao = new GeneroSocialDataTransfer();

                generoSocialDTAlteracao.Validacao = false;
                generoSocialDTAlteracao.Erro = true;
                generoSocialDTAlteracao.IncluirErroMensagem("Erro em GeneroSocialModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialDTValidacao = null;
            }

            return generoSocialDTAlteracao;
        }

        public GeneroSocialDataTransfer Excluir(int id)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialDataTransfer generoSocialDTExclusao;

            try {
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDTExclusao = generoSocialDataModel.Excluir(id);
            } catch (Exception ex) {
                generoSocialDTExclusao = new GeneroSocialDataTransfer();

                generoSocialDTExclusao.Validacao = false;
                generoSocialDTExclusao.Erro = true;
                generoSocialDTExclusao.IncluirErroMensagem("Erro em GeneroSocialModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
            }

            return generoSocialDTExclusao;
        }

        public GeneroSocialDataTransfer Listar()
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialDataTransfer generoSocialDTLista;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDTLista = generoSocialDataModel.Listar();
            } catch (Exception ex) {
                generoSocialDTLista = new GeneroSocialDataTransfer();

                generoSocialDTLista.Validacao = false;
                generoSocialDTLista.Erro = true;
                generoSocialDTLista.IncluirErroMensagem("Erro em GeneroSocialModel Listar [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
            }

            return generoSocialDTLista;
        }

        public GeneroSocialDataTransfer ConsultarPorId(int id)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialDataTransfer generoSocialDTForm;
            
            try {
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDTForm = generoSocialDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                generoSocialDTForm = new GeneroSocialDataTransfer();

                generoSocialDTForm.Validacao = false;
                generoSocialDTForm.Erro = true;
                generoSocialDTForm.IncluirErroMensagem("Erro em GeneroSocialModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
            }

            return generoSocialDTForm;
        }

        public GeneroSocialDataTransfer Consultar(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialDataModel generoSocialDataModel;
            GeneroSocialBusiness generoSocialBusiness;
            GeneroSocialDataTransfer generoSocialDTValidacao;
            GeneroSocialDataTransfer generoSocialDTConsulta;

            try {
                generoSocialBusiness = new GeneroSocialBusiness();
                generoSocialDataModel = new GeneroSocialDataModel();

                generoSocialDTValidacao = generoSocialBusiness.ValidarConsulta(generoSocialDataTransfer);

                if (!generoSocialDTValidacao.Erro) {
                    if (generoSocialDTValidacao.Validacao) {
                        generoSocialDTConsulta = generoSocialDataModel.Consultar(generoSocialDTValidacao);
                    } else {
                        generoSocialDTConsulta = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                    }
                } else {
                    generoSocialDTConsulta = new GeneroSocialDataTransfer(generoSocialDTValidacao);
                }
            } catch (Exception ex) {
                generoSocialDTConsulta = new GeneroSocialDataTransfer();

                generoSocialDTConsulta.Validacao = false;
                generoSocialDTConsulta.Erro = true;
                generoSocialDTConsulta.IncluirErroMensagem("Erro em GeneroSocialModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialDataModel = null;
                generoSocialBusiness = null;
                generoSocialDTValidacao = null;
            }

            return generoSocialDTConsulta;
        }
    }
}
