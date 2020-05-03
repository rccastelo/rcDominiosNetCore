using System;
using rcDominiosDataTransfers;

namespace rcDominiosBusiness
{
    public class PessoaTipoBusiness
    {
        public PessoaTipoDataTransfer Validar(PessoaTipoDataTransfer pessoaTipoDataTransfer) 
        {
            pessoaTipoDataTransfer.Validacao = true;
            pessoaTipoDataTransfer.Erro = false;

            return new PessoaTipoDataTransfer(pessoaTipoDataTransfer);
        }
    }
}
