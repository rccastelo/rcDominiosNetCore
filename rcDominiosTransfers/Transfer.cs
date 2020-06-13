using System.Collections.Generic;

namespace rcDominiosTransfers
{
    public abstract class Transfer
    {
        public bool Validacao { get; set; } 

        public bool Erro { get; set; }

        public IList<string> Mensagens { get; set; }

        public Transfer()
        {
            this.Validacao = true;
            this.Erro = false;
        }

        public Transfer(Transfer transfer)
        {
            if (transfer != null) {
                this.Validacao = transfer.Validacao;
                this.Erro = transfer.Erro;
                if (transfer.Mensagens != null) {
                    this.Mensagens = new List<string>(transfer.Mensagens);
                }
            }
        }

        public void IncluirMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem)) {
                if (this.Mensagens == null) {
                    this.Mensagens = new List<string>();
                }

                this.Mensagens.Add(mensagem);
            }
        }
    }
}
