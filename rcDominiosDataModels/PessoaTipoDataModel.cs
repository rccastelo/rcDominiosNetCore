using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class PessoaTipoDataModel : DataModel
    {
        public PessoaTipoTransfer Incluir(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer(pessoaTipoTransfer);

                pessoaTipoData.Incluir(pessoaTipoTransfer.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.PessoaTipo = new PessoaTipoEntity(pessoaTipoTransfer.PessoaTipo);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Alterar(PessoaTipoTransfer pessoaTipoTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipoData.Alterar(pessoaTipoTransfer.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.PessoaTipo = new PessoaTipoEntity(pessoaTipoTransfer.PessoaTipo);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer Excluir(int id)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                pessoaTipoData.Excluir(pessoaTipo.PessoaTipo);

                _contexto.SaveChanges();

                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoTransfer ConsultarPorId(int id)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoTransfer pessoaTipo;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                pessoaTipo.Validacao = true;
                pessoaTipo.Erro = false;
            } catch (Exception ex) {
                pessoaTipo = new PessoaTipoTransfer();

                pessoaTipo.Validacao = false;
                pessoaTipo.Erro = true;
                pessoaTipo.IncluirErroMensagem("Erro em PessoaTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipo;
        }

        public PessoaTipoListaTransfer Consultar(PessoaTipoListaTransfer pessoaTipoListaTransfer)
        {
            PessoaTipoData pessoaTipoData;
            PessoaTipoListaTransfer pessoaTipoLista;

            try {
                pessoaTipoData = new PessoaTipoData(_contexto);

                pessoaTipoLista = pessoaTipoData.Consultar(pessoaTipoListaTransfer);
                pessoaTipoLista.Validacao = true;
                pessoaTipoLista.Erro = false;
            } catch (Exception ex) {
                pessoaTipoLista = new PessoaTipoListaTransfer();

                pessoaTipoLista.Validacao = false;
                pessoaTipoLista.Erro = true;
                pessoaTipoLista.IncluirErroMensagem("Erro em PessoaTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return pessoaTipoLista;
        }
    }
}
