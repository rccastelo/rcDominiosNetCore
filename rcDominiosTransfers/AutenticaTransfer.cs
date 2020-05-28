using System.Collections.Generic;

namespace rcDominiosTransfers
{
    public class AutenticaTransfer : Transfer
    {
        public string Apelido { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }

        public bool Autenticado { get; set; }

        public AutenticaTransfer() 
            : base()
        {
            this.Autenticado = false;
            this.Token = null;
        }

        public AutenticaTransfer(AutenticaTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                this.Apelido = transfer.Apelido;
                this.Senha = transfer.Senha;
                this.Token = transfer.Token;
                this.Autenticado = transfer.Autenticado;
            }
        }
    }
}
