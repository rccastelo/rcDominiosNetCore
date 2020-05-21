using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class GeneroSocialDataModel : DataModel
    {
        public GeneroSocialDataTransfer Incluir(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer(generoSocialDataTransfer);

                generoSocialData.Incluir(generoSocialDataTransfer.GeneroSocial);

                _contexto.SaveChanges();

                GeneroSocialRetorno.GeneroSocial = new GeneroSocialEntity(generoSocialDataTransfer.GeneroSocial);
                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }

        public GeneroSocialDataTransfer Alterar(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                generoSocialData.Alterar(generoSocialDataTransfer.GeneroSocial);

                _contexto.SaveChanges();

                GeneroSocialRetorno.GeneroSocial = new GeneroSocialEntity(generoSocialDataTransfer.GeneroSocial);
                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }

        public GeneroSocialDataTransfer Excluir(int id)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.GeneroSocial = generoSocialData.ConsultarPorId(id);
                generoSocialData.Excluir(GeneroSocialRetorno.GeneroSocial);

                _contexto.SaveChanges();

                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }

        public GeneroSocialDataTransfer Listar()
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.GeneroSocialLista = generoSocialData.Listar();
                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel Listar [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }

        public GeneroSocialDataTransfer ConsultarPorId(int id)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.GeneroSocial = generoSocialData.ConsultarPorId(id);
                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }

        public GeneroSocialDataTransfer Consultar(GeneroSocialDataTransfer generoSocialDataTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialDataTransfer GeneroSocialRetorno;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.GeneroSocialLista = generoSocialData.Consultar(generoSocialDataTransfer);
                GeneroSocialRetorno.Validacao = true;
                GeneroSocialRetorno.Erro = false;
            } catch (Exception ex) {
                GeneroSocialRetorno = new GeneroSocialDataTransfer();

                GeneroSocialRetorno.Validacao = false;
                GeneroSocialRetorno.Erro = true;
                GeneroSocialRetorno.IncluirErroMensagem("Erro em GeneroSocialDataModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return GeneroSocialRetorno;
        }
    }
}
