using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class TelefoneTipoDataModel : DataModel
    {
        public TelefoneTipoTransfer Incluir(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                telefoneTipo = new TelefoneTipoTransfer(telefoneTipoTransfer);

                telefoneTipoData.Incluir(telefoneTipoTransfer.TelefoneTipo);

                _contexto.SaveChanges();

                telefoneTipo.TelefoneTipo = new TelefoneTipoEntity(telefoneTipoTransfer.TelefoneTipo);
                telefoneTipo.Validacao = true;
                telefoneTipo.Erro = false;
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer Alterar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipoData.Alterar(telefoneTipoTransfer.TelefoneTipo);

                _contexto.SaveChanges();

                telefoneTipo.TelefoneTipo = new TelefoneTipoEntity(telefoneTipoTransfer.TelefoneTipo);
                telefoneTipo.Validacao = true;
                telefoneTipo.Erro = false;
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer Excluir(int id)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.TelefoneTipo = telefoneTipoData.ConsultarPorId(id);
                telefoneTipoData.Excluir(telefoneTipo.TelefoneTipo);

                _contexto.SaveChanges();

                telefoneTipo.Validacao = true;
                telefoneTipo.Erro = false;
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer ConsultarPorId(int id)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoTransfer telefoneTipo;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.TelefoneTipo = telefoneTipoData.ConsultarPorId(id);
                telefoneTipo.Validacao = true;
                telefoneTipo.Erro = false;
            } catch (Exception ex) {
                telefoneTipo = new TelefoneTipoTransfer();

                telefoneTipo.Validacao = false;
                telefoneTipo.Erro = true;
                telefoneTipo.IncluirErroMensagem("Erro em TelefoneTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return telefoneTipo;
        }

        public TelefoneTipoTransfer Consultar(TelefoneTipoTransfer telefoneTipoTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoTransfer telefoneTipoLista;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);

                telefoneTipoLista = telefoneTipoData.Consultar(telefoneTipoTransfer);
                telefoneTipoLista.Validacao = true;
                telefoneTipoLista.Erro = false;
            } catch (Exception ex) {
                telefoneTipoLista = new TelefoneTipoTransfer();

                telefoneTipoLista.Validacao = false;
                telefoneTipoLista.Erro = true;
                telefoneTipoLista.IncluirErroMensagem("Erro em TelefoneTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return telefoneTipoLista;
        }
    }
}
