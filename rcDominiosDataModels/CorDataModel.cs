using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class CorDataModel : DataModel
    {
        public CorDataTransfer Incluir(CorDataTransfer corDataTransfer)
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer(corDataTransfer);

                corData.Incluir(corDataTransfer.Cor);

                _contexto.SaveChanges();

                CorRetorno.Cor = new CorEntity(corDataTransfer.Cor);
                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel Incluir [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }

        public CorDataTransfer Alterar(CorDataTransfer corDataTransfer)
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer();

                corData.Alterar(corDataTransfer.Cor);

                _contexto.SaveChanges();

                CorRetorno.Cor = new CorEntity(corDataTransfer.Cor);
                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel Alterar [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }

        public CorDataTransfer Excluir(int id)
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer();

                CorRetorno.Cor = corData.ConsultarPorId(id);
                corData.Excluir(CorRetorno.Cor);

                _contexto.SaveChanges();

                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel Excluir [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }

        public CorDataTransfer Listar()
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer();

                CorRetorno.CorLista = corData.Listar();
                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel Listar [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }

        public CorDataTransfer ConsultarPorId(int id)
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer();

                CorRetorno.Cor = corData.ConsultarPorId(id);
                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }

        public CorDataTransfer Consultar(CorDataTransfer corDataTransfer)
        {
            CorData corData;
            CorDataTransfer CorRetorno;

            try {
                corData = new CorData(_contexto);
                CorRetorno = new CorDataTransfer();

                CorRetorno.CorLista = corData.Consultar(corDataTransfer);
                CorRetorno.Validacao = true;
                CorRetorno.Erro = false;
            } catch (Exception ex) {
                CorRetorno = new CorDataTransfer();

                CorRetorno.Validacao = false;
                CorRetorno.Erro = true;
                CorRetorno.IncluirErroMensagem("Erro em CorDataModel Consultar [" + ex.Message + "]");
            } finally {
                corData = null;
            }

            return CorRetorno;
        }
    }
}
