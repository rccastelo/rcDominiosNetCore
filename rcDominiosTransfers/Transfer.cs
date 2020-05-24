using System.Collections.Generic;

namespace rcDominiosTransfers
{
    public abstract class Transfer
    {
        public bool Validacao { get; set; } 

        public IList<string> ValidacaoMensagens { get; set; } 

        public bool Erro { get; set; }

        public IList<string> ErroMensagens { get; set; }

        public bool Info { get; set; }

        public IList<string> InfoMensagens { get; set; }

        public Transfer()
        {
        }

        public Transfer(Transfer transfer)
        {
            if (transfer != null) {
                this.Validacao = transfer.Validacao;
                if (transfer.ValidacaoMensagens != null) {
                    this.ValidacaoMensagens = new List<string>(transfer.ValidacaoMensagens);
                }
                
                this.Erro = transfer.Erro;
                if (transfer.ErroMensagens != null) {
                    this.ErroMensagens = new List<string>(transfer.ErroMensagens);
                }
                
                this.Info = transfer.Info;
                if (transfer.InfoMensagens != null) {
                    this.InfoMensagens = new List<string>(transfer.InfoMensagens);
                }
            }
        }

        public void IncluirValidacaoMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem)) {
                if (this.ValidacaoMensagens == null) {
                    this.ValidacaoMensagens = new List<string>();
                }

                this.ValidacaoMensagens.Add(mensagem);
            }
        }

        public void IncluirErroMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem)) {
                if (this.ErroMensagens == null) {
                    this.ErroMensagens = new List<string>();
                }

                this.ErroMensagens.Add(mensagem);
            }
        }

        public void IncluirInfoMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem)) {
                if (this.InfoMensagens == null) {
                    this.InfoMensagens = new List<string>();
                }

                this.InfoMensagens.Add(mensagem);
            }
        }
    }
}
