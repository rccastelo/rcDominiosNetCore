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
