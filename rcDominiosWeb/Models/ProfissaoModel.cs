using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class ProfissaoModel
    {
        public ProfissaoDataTransfer Incluir(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoDataTransfer profissaoDTValidacao;
            ProfissaoDataTransfer profissaoDTInclusao;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDataTransfer.Profissao.Criacao = DateTime.Today;
                profissaoDataTransfer.Profissao.Alteracao = DateTime.Today;

                profissaoDTValidacao = profissaoBusiness.Validar(profissaoDataTransfer);

                if (!profissaoDTValidacao.Erro) {
                    if (profissaoDTValidacao.Validacao) {
                        profissaoDTInclusao = profissaoDataModel.Incluir(profissaoDTValidacao);
                    } else {
                        profissaoDTInclusao = new ProfissaoDataTransfer(profissaoDTValidacao);
                    }
                } else {
                    profissaoDTInclusao = new ProfissaoDataTransfer(profissaoDTValidacao);
                }
            } catch (Exception ex) {
                profissaoDTInclusao = new ProfissaoDataTransfer();

                profissaoDTInclusao.Validacao = false;
                profissaoDTInclusao.Erro = true;
                profissaoDTInclusao.ErroMensagens.Add("Erro em ProfissaoModel Incluir [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoDTValidacao = null;
            }

            return profissaoDTInclusao;
        }

        public ProfissaoDataTransfer Alterar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoDataTransfer profissaoDTValidacao;
            ProfissaoDataTransfer profissaoDTAlteracao;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDataTransfer.Profissao.Alteracao = DateTime.Today;

                profissaoDTValidacao = profissaoBusiness.Validar(profissaoDataTransfer);

                if (!profissaoDTValidacao.Erro) {
                    if (profissaoDTValidacao.Validacao) {
                        profissaoDTAlteracao = profissaoDataModel.Alterar(profissaoDTValidacao);
                    } else {
                        profissaoDTAlteracao = new ProfissaoDataTransfer(profissaoDTValidacao);
                    }
                } else {
                    profissaoDTAlteracao = new ProfissaoDataTransfer(profissaoDTValidacao);
                }
            } catch (Exception ex) {
                profissaoDTAlteracao = new ProfissaoDataTransfer();

                profissaoDTAlteracao.Validacao = false;
                profissaoDTAlteracao.Erro = true;
                profissaoDTAlteracao.ErroMensagens.Add("Erro em ProfissaoModel Alterar [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoDTValidacao = null;
            }

            return profissaoDTAlteracao;
        }

        public ProfissaoDataTransfer Excluir(int id)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoDataTransfer profissaoDTExclusao;

            try {
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDTExclusao = profissaoDataModel.Excluir(id);
            } catch (Exception ex) {
                profissaoDTExclusao = new ProfissaoDataTransfer();

                profissaoDTExclusao.Validacao = false;
                profissaoDTExclusao.Erro = true;
                profissaoDTExclusao.ErroMensagens.Add("Erro em ProfissaoModel Excluir [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
            }

            return profissaoDTExclusao;
        }

        public ProfissaoDataTransfer Listar()
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoDataTransfer profissaoDTLista;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDTLista = profissaoDataModel.Listar();
            } catch (Exception ex) {
                profissaoDTLista = new ProfissaoDataTransfer();

                profissaoDTLista.Validacao = false;
                profissaoDTLista.Erro = true;
                profissaoDTLista.ErroMensagens.Add("Erro em ProfissaoModel Listar [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
            }

            return profissaoDTLista;
        }

        public ProfissaoDataTransfer ConsultarPorId(int id)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoDataTransfer profissaoDTForm;
            
            try {
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDTForm = profissaoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                profissaoDTForm = new ProfissaoDataTransfer();

                profissaoDTForm.Validacao = false;
                profissaoDTForm.Erro = true;
                profissaoDTForm.ErroMensagens.Add("Erro em ProfissaoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
            }

            return profissaoDTForm;
        }

        public ProfissaoDataTransfer Consultar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoDataModel profissaoDataModel;
            ProfissaoBusiness profissaoBusiness;
            ProfissaoDataTransfer profissaoDTValidacao;
            ProfissaoDataTransfer profissaoDTConsulta;

            try {
                profissaoBusiness = new ProfissaoBusiness();
                profissaoDataModel = new ProfissaoDataModel();

                profissaoDTValidacao = profissaoBusiness.ValidarConsulta(profissaoDataTransfer);

                if (!profissaoDTValidacao.Erro) {
                    if (profissaoDTValidacao.Validacao) {
                        profissaoDTConsulta = profissaoDataModel.Consultar(profissaoDTValidacao);
                    } else {
                        profissaoDTConsulta = new ProfissaoDataTransfer(profissaoDTValidacao);
                    }
                } else {
                    profissaoDTConsulta = new ProfissaoDataTransfer(profissaoDTValidacao);
                }
            } catch (Exception ex) {
                profissaoDTConsulta = new ProfissaoDataTransfer();

                profissaoDTConsulta.Validacao = false;
                profissaoDTConsulta.Erro = true;
                profissaoDTConsulta.ErroMensagens.Add("Erro em ProfissaoModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoDataModel = null;
                profissaoBusiness = null;
                profissaoDTValidacao = null;
            }

            return profissaoDTConsulta;
        }
    }
}
