using System.Collections.Generic;

namespace rcDominiosDataTransfers
{
    public abstract class DataTransfer
    {
        public bool Validacao { get; set; } 

        public IList<string> ValidacaoMensagens { get; set; } 

        public bool Erro { get; set; }

        public IList<string> ErroMensagens { get; set; }

        public string Sistema { get; set; }

        public string BaseDados { get; set; }

        public DataTransfer()
        {
            this.ValidacaoMensagens = new List<string>();
            this.ErroMensagens = new List<string>();
        }

        public DataTransfer(DataTransfer dataTransfer)
        {
            if (dataTransfer != null) {
                this.Validacao = dataTransfer.Validacao;
                this.ValidacaoMensagens = new List<string>(dataTransfer.ValidacaoMensagens);
                this.Erro = dataTransfer.Erro;
                this.ErroMensagens = new List<string>(dataTransfer.ErroMensagens);
                this.Sistema = dataTransfer.Sistema;
                this.BaseDados = dataTransfer.BaseDados;
            }
        }  
    }
}
