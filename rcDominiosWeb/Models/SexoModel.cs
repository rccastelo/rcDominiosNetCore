using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosDataTransfers;

namespace rcDominiosWeb.Models
{
    public class SexoModel
    {
        public SexoDataTransfer Incluir(SexoDataTransfer sexoDataTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoDataTransfer sexoDTValidacao;
            SexoDataTransfer sexoDTInclusao;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoDataTransfer.Sexo.Criacao = DateTime.Today;
                sexoDataTransfer.Sexo.Alteracao = DateTime.Today;

                sexoDTValidacao = sexoBusiness.Validar(sexoDataTransfer);

                if (!sexoDTValidacao.Erro) {
                    if (sexoDTValidacao.Validacao) {
                        sexoDTInclusao = sexoDataModel.Incluir(sexoDTValidacao);
                    } else {
                        sexoDTInclusao = new SexoDataTransfer(sexoDTValidacao);
                    }
                } else {
                    sexoDTInclusao = new SexoDataTransfer(sexoDTValidacao);
                }
            } catch (Exception ex) {
                sexoDTInclusao = new SexoDataTransfer();

                sexoDTInclusao.Validacao = false;
                sexoDTInclusao.Erro = true;
                sexoDTInclusao.ErroMensagens.Add("Erro em SexoModel Incluir [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoDTValidacao = null;
            }

            return sexoDTInclusao;
        }

        public SexoDataTransfer Alterar(SexoDataTransfer sexoDataTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoDataTransfer sexoDTValidacao;
            SexoDataTransfer sexoDTAlteracao;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoDataTransfer.Sexo.Alteracao = DateTime.Today;

                sexoDTValidacao = sexoBusiness.Validar(sexoDataTransfer);

                if (!sexoDTValidacao.Erro) {
                    if (sexoDTValidacao.Validacao) {
                        sexoDTAlteracao = sexoDataModel.Alterar(sexoDTValidacao);
                    } else {
                        sexoDTAlteracao = new SexoDataTransfer(sexoDTValidacao);
                    }
                } else {
                    sexoDTAlteracao = new SexoDataTransfer(sexoDTValidacao);
                }
            } catch (Exception ex) {
                sexoDTAlteracao = new SexoDataTransfer();

                sexoDTAlteracao.Validacao = false;
                sexoDTAlteracao.Erro = true;
                sexoDTAlteracao.ErroMensagens.Add("Erro em SexoModel Alterar [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoDTValidacao = null;
            }

            return sexoDTAlteracao;
        }

        public SexoDataTransfer Excluir(int id)
        {
            SexoDataModel sexoDataModel;
            SexoDataTransfer sexoDTExclusao;

            try {
                sexoDataModel = new SexoDataModel();

                sexoDTExclusao = sexoDataModel.Excluir(id);
            } catch (Exception ex) {
                sexoDTExclusao = new SexoDataTransfer();

                sexoDTExclusao.Validacao = false;
                sexoDTExclusao.Erro = true;
                sexoDTExclusao.ErroMensagens.Add("Erro em SexoModel Excluir [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
            }

            return sexoDTExclusao;
        }

        public SexoDataTransfer Listar()
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoDataTransfer sexoDTLista;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoDTLista = sexoDataModel.Listar();
            } catch (Exception ex) {
                sexoDTLista = new SexoDataTransfer();

                sexoDTLista.Validacao = false;
                sexoDTLista.Erro = true;
                sexoDTLista.ErroMensagens.Add("Erro em SexoModel Listar [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
            }

            return sexoDTLista;
        }

        public SexoDataTransfer ConsultarPorId(int id)
        {
            SexoDataModel sexoDataModel;
            SexoDataTransfer sexoDTForm;
            
            try {
                sexoDataModel = new SexoDataModel();

                sexoDTForm = sexoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                sexoDTForm = new SexoDataTransfer();

                sexoDTForm.Validacao = false;
                sexoDTForm.Erro = true;
                sexoDTForm.ErroMensagens.Add("Erro em SexoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
            }

            return sexoDTForm;
        }

        public SexoDataTransfer Consultar(SexoDataTransfer sexoDataTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoDataTransfer sexoDTValidacao;
            SexoDataTransfer sexoDTConsulta;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoDTValidacao = sexoBusiness.ValidarConsulta(sexoDataTransfer);

                if (!sexoDTValidacao.Erro) {
                    if (sexoDTValidacao.Validacao) {
                        sexoDTConsulta = sexoDataModel.Consultar(sexoDTValidacao);
                    } else {
                        sexoDTConsulta = new SexoDataTransfer(sexoDTValidacao);
                    }
                } else {
                    sexoDTConsulta = new SexoDataTransfer(sexoDTValidacao);
                }
            } catch (Exception ex) {
                sexoDTConsulta = new SexoDataTransfer();

                sexoDTConsulta.Validacao = false;
                sexoDTConsulta.Erro = true;
                sexoDTConsulta.ErroMensagens.Add("Erro em SexoModel Consultar [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoDTValidacao = null;
            }

            return sexoDTConsulta;
        }
    }
}
