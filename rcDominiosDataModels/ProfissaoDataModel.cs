using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class ProfissaoDataModel : DataModel
    {
        public ProfissaoDataTransfer Incluir(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer(profissaoDataTransfer);

                profissaoData.Incluir(profissaoDataTransfer.Profissao);

                _contexto.SaveChanges();

                ProfissaoRetorno.Profissao = new ProfissaoEntity(profissaoDataTransfer.Profissao);
                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel Incluir [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }

        public ProfissaoDataTransfer Alterar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer();

                profissaoData.Alterar(profissaoDataTransfer.Profissao);

                _contexto.SaveChanges();

                ProfissaoRetorno.Profissao = new ProfissaoEntity(profissaoDataTransfer.Profissao);
                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel Alterar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }

        public ProfissaoDataTransfer Excluir(int id)
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Profissao = profissaoData.ConsultarPorId(id);
                profissaoData.Excluir(ProfissaoRetorno.Profissao);

                _contexto.SaveChanges();

                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel Excluir [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }

        public ProfissaoDataTransfer Listar()
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.ProfissaoLista = profissaoData.Listar();
                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel Listar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }

        public ProfissaoDataTransfer ConsultarPorId(int id)
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Profissao = profissaoData.ConsultarPorId(id);
                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }

        public ProfissaoDataTransfer Consultar(ProfissaoDataTransfer profissaoDataTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoDataTransfer ProfissaoRetorno;

            try {
                profissaoData = new ProfissaoData(_contexto);
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.ProfissaoLista = profissaoData.Consultar(profissaoDataTransfer);
                ProfissaoRetorno.Validacao = true;
                ProfissaoRetorno.Erro = false;
            } catch (Exception ex) {
                ProfissaoRetorno = new ProfissaoDataTransfer();

                ProfissaoRetorno.Validacao = false;
                ProfissaoRetorno.Erro = true;
                ProfissaoRetorno.ErroMensagens.Add("Erro em ProfissaoDataModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return ProfissaoRetorno;
        }
    }
}
