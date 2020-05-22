using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class ProfissaoDataModel : DataModel
    {
        public ProfissaoTransfer Incluir(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoTransfer profissao;

            try {
                profissaoData = new ProfissaoData(_contexto);
                profissao = new ProfissaoTransfer(profissaoTransfer);

                profissaoData.Incluir(profissaoTransfer.Profissao);

                _contexto.SaveChanges();

                profissao.Profissao = new ProfissaoEntity(profissaoTransfer.Profissao);
                profissao.Validacao = true;
                profissao.Erro = false;
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoDataModel Incluir [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissao;
        }

        public ProfissaoTransfer Alterar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoTransfer profissao;

            try {
                profissaoData = new ProfissaoData(_contexto);
                profissao = new ProfissaoTransfer();

                profissaoData.Alterar(profissaoTransfer.Profissao);

                _contexto.SaveChanges();

                profissao.Profissao = new ProfissaoEntity(profissaoTransfer.Profissao);
                profissao.Validacao = true;
                profissao.Erro = false;
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoDataModel Alterar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissao;
        }

        public ProfissaoTransfer Excluir(int id)
        {
            ProfissaoData profissaoData;
            ProfissaoTransfer profissao;

            try {
                profissaoData = new ProfissaoData(_contexto);
                profissao = new ProfissaoTransfer();

                profissao.Profissao = profissaoData.ConsultarPorId(id);
                profissaoData.Excluir(profissao.Profissao);

                _contexto.SaveChanges();

                profissao.Validacao = true;
                profissao.Erro = false;
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoDataModel Excluir [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissao;
        }

        public ProfissaoTransfer ConsultarPorId(int id)
        {
            ProfissaoData profissaoData;
            ProfissaoTransfer profissao;

            try {
                profissaoData = new ProfissaoData(_contexto);
                profissao = new ProfissaoTransfer();

                profissao.Profissao = profissaoData.ConsultarPorId(id);
                profissao.Validacao = true;
                profissao.Erro = false;
            } catch (Exception ex) {
                profissao = new ProfissaoTransfer();

                profissao.Validacao = false;
                profissao.Erro = true;
                profissao.IncluirErroMensagem("Erro em ProfissaoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissao;
        }

        public ProfissaoListaTransfer Consultar(ProfissaoListaTransfer profissaoListaTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoListaTransfer profissaoLista;

            try {
                profissaoData = new ProfissaoData(_contexto);

                profissaoLista = profissaoData.Consultar(profissaoListaTransfer);
                profissaoLista.Validacao = true;
                profissaoLista.Erro = false;
            } catch (Exception ex) {
                profissaoLista = new ProfissaoListaTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirErroMensagem("Erro em ProfissaoDataModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissaoLista;
        }
    }
}
