using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class TelefoneTipoDataModel : DataModel
    {
        public TelefoneTipoDataTransfer Incluir(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer(telefoneTipoDataTransfer);

                telefoneTipoData.Incluir(telefoneTipoDataTransfer.TelefoneTipo);

                _contexto.SaveChanges();

                TelefoneTipoRetorno.TelefoneTipo = new TelefoneTipoEntity(telefoneTipoDataTransfer.TelefoneTipo);
                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }

        public TelefoneTipoDataTransfer Alterar(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                telefoneTipoData.Alterar(telefoneTipoDataTransfer.TelefoneTipo);

                _contexto.SaveChanges();

                TelefoneTipoRetorno.TelefoneTipo = new TelefoneTipoEntity(telefoneTipoDataTransfer.TelefoneTipo);
                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }

        public TelefoneTipoDataTransfer Excluir(int id)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.TelefoneTipo = telefoneTipoData.ConsultarPorId(id);
                telefoneTipoData.Excluir(TelefoneTipoRetorno.TelefoneTipo);

                _contexto.SaveChanges();

                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }

        public TelefoneTipoDataTransfer Listar()
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.TelefoneTipoLista = telefoneTipoData.Listar();
                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel Listar [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }

        public TelefoneTipoDataTransfer ConsultarPorId(int id)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.TelefoneTipo = telefoneTipoData.ConsultarPorId(id);
                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }

        public TelefoneTipoDataTransfer Consultar(TelefoneTipoDataTransfer telefoneTipoDataTransfer)
        {
            TelefoneTipoData telefoneTipoData;
            TelefoneTipoDataTransfer TelefoneTipoRetorno;

            try {
                telefoneTipoData = new TelefoneTipoData(_contexto);
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.TelefoneTipoLista = telefoneTipoData.Consultar(telefoneTipoDataTransfer);
                TelefoneTipoRetorno.Validacao = true;
                TelefoneTipoRetorno.Erro = false;
            } catch (Exception ex) {
                TelefoneTipoRetorno = new TelefoneTipoDataTransfer();

                TelefoneTipoRetorno.Validacao = false;
                TelefoneTipoRetorno.Erro = true;
                TelefoneTipoRetorno.IncluirErroMensagem("Erro em TelefoneTipoDataModel Consultar [" + ex.Message + "]");
            } finally {
                telefoneTipoData = null;
            }

            return TelefoneTipoRetorno;
        }
    }
}
