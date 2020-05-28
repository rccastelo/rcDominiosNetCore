using System;
using rcDominiosDatas;
using rcDominiosTransfers;
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
                profissao.IncluirMensagem("Erro em ProfissaoDataModel Incluir [" + ex.Message + "]");
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
                profissao.IncluirMensagem("Erro em ProfissaoDataModel Alterar [" + ex.Message + "]");
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
                profissao.IncluirMensagem("Erro em ProfissaoDataModel Excluir [" + ex.Message + "]");
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
                profissao.IncluirMensagem("Erro em ProfissaoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissao;
        }

        public ProfissaoTransfer Consultar(ProfissaoTransfer profissaoTransfer)
        {
            ProfissaoData profissaoData;
            ProfissaoTransfer profissaoLista;

            try {
                profissaoData = new ProfissaoData(_contexto);

                profissaoLista = profissaoData.Consultar(profissaoTransfer);
                profissaoLista.Validacao = true;
                profissaoLista.Erro = false;
            } catch (Exception ex) {
                profissaoLista = new ProfissaoTransfer();

                profissaoLista.Validacao = false;
                profissaoLista.Erro = true;
                profissaoLista.IncluirMensagem("Erro em ProfissaoDataModel Consultar [" + ex.Message + "]");
            } finally {
                profissaoData = null;
            }

            return profissaoLista;
        }
    }
}
