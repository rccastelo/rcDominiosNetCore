using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class SexoDataModel : DataModel
    {
        public SexoDataTransfer Incluir(SexoDataTransfer sexoDataTransfer)
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer(sexoDataTransfer);

                sexoData.Incluir(sexoDataTransfer.Sexo);

                _contexto.SaveChanges();

                SexoRetorno.Sexo = new SexoEntity(sexoDataTransfer.Sexo);
                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel Incluir [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }

        public SexoDataTransfer Alterar(SexoDataTransfer sexoDataTransfer)
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer();

                sexoData.Alterar(sexoDataTransfer.Sexo);

                _contexto.SaveChanges();

                SexoRetorno.Sexo = new SexoEntity(sexoDataTransfer.Sexo);
                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel Alterar [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }

        public SexoDataTransfer Excluir(int id)
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Sexo = sexoData.ConsultarPorId(id);
                sexoData.Excluir(SexoRetorno.Sexo);

                _contexto.SaveChanges();

                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel Excluir [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }

        public SexoDataTransfer Listar()
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.SexoLista = sexoData.Listar();
                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel Listar [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }

        public SexoDataTransfer ConsultarPorId(int id)
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Sexo = sexoData.ConsultarPorId(id);
                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }

        public SexoDataTransfer Consultar(SexoDataTransfer sexoDataTransfer)
        {
            SexoData sexoData;
            SexoDataTransfer SexoRetorno;

            try {
                sexoData = new SexoData(_contexto);
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.SexoLista = sexoData.Consultar(sexoDataTransfer);
                SexoRetorno.Validacao = true;
                SexoRetorno.Erro = false;
            } catch (Exception ex) {
                SexoRetorno = new SexoDataTransfer();

                SexoRetorno.Validacao = false;
                SexoRetorno.Erro = true;
                SexoRetorno.IncluirErroMensagem("Erro em SexoDataModel Consultar [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return SexoRetorno;
        }
    }
}
