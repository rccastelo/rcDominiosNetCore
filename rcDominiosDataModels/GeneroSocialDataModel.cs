using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class GeneroSocialDataModel : DataModel
    {
        public GeneroSocialTransfer Incluir(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                generoSocial = new GeneroSocialTransfer(generoSocialTransfer);

                generoSocialData.Incluir(generoSocialTransfer.GeneroSocial);

                _contexto.SaveChanges();

                generoSocial.GeneroSocial = new GeneroSocialEntity(generoSocialTransfer.GeneroSocial);
                generoSocial.Validacao = true;
                generoSocial.Erro = false;
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialDataModel Incluir [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer Alterar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                generoSocial = new GeneroSocialTransfer();

                generoSocialData.Alterar(generoSocialTransfer.GeneroSocial);

                _contexto.SaveChanges();

                generoSocial.GeneroSocial = new GeneroSocialEntity(generoSocialTransfer.GeneroSocial);
                generoSocial.Validacao = true;
                generoSocial.Erro = false;
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialDataModel Alterar [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer Excluir(int id)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                generoSocial = new GeneroSocialTransfer();

                generoSocial.GeneroSocial = generoSocialData.ConsultarPorId(id);
                generoSocialData.Excluir(generoSocial.GeneroSocial);

                _contexto.SaveChanges();

                generoSocial.Validacao = true;
                generoSocial.Erro = false;
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialDataModel Excluir [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer ConsultarPorId(int id)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialTransfer generoSocial;

            try {
                generoSocialData = new GeneroSocialData(_contexto);
                generoSocial = new GeneroSocialTransfer();

                generoSocial.GeneroSocial = generoSocialData.ConsultarPorId(id);
                generoSocial.Validacao = true;
                generoSocial.Erro = false;
            } catch (Exception ex) {
                generoSocial = new GeneroSocialTransfer();

                generoSocial.Validacao = false;
                generoSocial.Erro = true;
                generoSocial.IncluirMensagem("Erro em GeneroSocialDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return generoSocial;
        }

        public GeneroSocialTransfer Consultar(GeneroSocialTransfer generoSocialTransfer)
        {
            GeneroSocialData generoSocialData;
            GeneroSocialTransfer generoSocialLista;

            try {
                generoSocialData = new GeneroSocialData(_contexto);

                generoSocialLista = generoSocialData.Consultar(generoSocialTransfer);
                generoSocialLista.Validacao = true;
                generoSocialLista.Erro = false;
            } catch (Exception ex) {
                generoSocialLista = new GeneroSocialTransfer();

                generoSocialLista.Validacao = false;
                generoSocialLista.Erro = true;
                generoSocialLista.IncluirMensagem("Erro em GeneroSocialDataModel Consultar [" + ex.Message + "]");
            } finally {
                generoSocialData = null;
            }

            return generoSocialLista;
        }
    }
}
