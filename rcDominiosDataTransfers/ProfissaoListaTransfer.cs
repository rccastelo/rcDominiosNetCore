using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class ProfissaoListaTransfer : DataTransfer
    {
        public IList<ProfissaoEntity> ProfissaoLista { get; set; }

        public int Pagina { get; set; }
        
        public int Quantidade { get; set; }
        
        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string Descricao { get; set; }

        public string Codigo { get; set; }

        public string Ativo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoAte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoAte { get; set; }

        public ProfissaoListaTransfer() 
            : base()
        {
        }

        public ProfissaoListaTransfer(ProfissaoListaTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.ProfissaoLista != null) {
                    this.ProfissaoLista = new List<ProfissaoEntity>(transfer.ProfissaoLista);
                }
                this.IdDe = transfer.IdDe;
                this.IdAte = transfer.IdAte;
                this.Descricao = transfer.Descricao;
                this.Codigo = transfer.Codigo;
                this.Ativo = transfer.Ativo;
                this.CriacaoDe = transfer.CriacaoDe;
                this.CriacaoAte = transfer.CriacaoAte;
                this.AlteracaoDe = transfer.AlteracaoDe;
                this.AlteracaoAte = transfer.AlteracaoAte;
            }
        }

        public void IncluirProfissao(ProfissaoEntity entity) {
            if (entity != null) {
                if (this.ProfissaoLista == null) {
                    this.ProfissaoLista = new List<ProfissaoEntity>();
                }

                this.ProfissaoLista.Add(entity);
            }
        }
    }
}
