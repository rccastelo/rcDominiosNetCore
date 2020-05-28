using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class SexoDataModel : DataModel
    {
        public SexoTransfer Incluir(SexoTransfer sexoTransfer)
        {
            SexoData sexoData;
            SexoTransfer sexo;

            try {
                sexoData = new SexoData(_contexto);
                sexo = new SexoTransfer(sexoTransfer);

                sexoData.Incluir(sexoTransfer.Sexo);

                _contexto.SaveChanges();

                sexo.Sexo = new SexoEntity(sexoTransfer.Sexo);
                sexo.Validacao = true;
                sexo.Erro = false;
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoDataModel Incluir [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return sexo;
        }

        public SexoTransfer Alterar(SexoTransfer sexoTransfer)
        {
            SexoData sexoData;
            SexoTransfer sexo;

            try {
                sexoData = new SexoData(_contexto);
                sexo = new SexoTransfer();

                sexoData.Alterar(sexoTransfer.Sexo);

                _contexto.SaveChanges();

                sexo.Sexo = new SexoEntity(sexoTransfer.Sexo);
                sexo.Validacao = true;
                sexo.Erro = false;
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoDataModel Alterar [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return sexo;
        }

        public SexoTransfer Excluir(int id)
        {
            SexoData sexoData;
            SexoTransfer sexo;

            try {
                sexoData = new SexoData(_contexto);
                sexo = new SexoTransfer();

                sexo.Sexo = sexoData.ConsultarPorId(id);
                sexoData.Excluir(sexo.Sexo);

                _contexto.SaveChanges();

                sexo.Validacao = true;
                sexo.Erro = false;
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoDataModel Excluir [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return sexo;
        }

        public SexoTransfer ConsultarPorId(int id)
        {
            SexoData sexoData;
            SexoTransfer sexo;

            try {
                sexoData = new SexoData(_contexto);
                sexo = new SexoTransfer();

                sexo.Sexo = sexoData.ConsultarPorId(id);
                sexo.Validacao = true;
                sexo.Erro = false;
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return sexo;
        }

        public SexoTransfer Consultar(SexoTransfer sexoTransfer)
        {
            SexoData sexoData;
            SexoTransfer sexoLista;

            try {
                sexoData = new SexoData(_contexto);

                sexoLista = sexoData.Consultar(sexoTransfer);
                sexoLista.Validacao = true;
                sexoLista.Erro = false;
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoDataModel Consultar [" + ex.Message + "]");
            } finally {
                sexoData = null;
            }

            return sexoLista;
        }
    }
}
