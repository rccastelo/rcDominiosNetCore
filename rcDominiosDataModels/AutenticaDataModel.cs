using System;
using rcDominiosDatas;
using rcDominiosTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class AutenticaDataModel : DataModel
    {
        public AutenticaTransfer Autenticar(AutenticaTransfer autenticaTransfer)
        {
            AutenticaData autenticaData;
            AutenticaTransfer autentica;

            try {
                autenticaData = new AutenticaData(_contexto);

                autentica = autenticaData.Autenticar(autenticaTransfer);
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaDataModel Autenticar [" + ex.Message + "]");
            } finally {
                autenticaData = null;
            }

            return autentica;
        }
    }
}
