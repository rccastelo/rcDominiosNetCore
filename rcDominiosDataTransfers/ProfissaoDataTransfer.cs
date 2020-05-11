using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class ProfissaoDataTransfer : DataTransfer
    {
        public ProfissaoEntity Profissao { get; set; }

        public IList<ProfissaoEntity> ProfissaoLista { get; set; }

        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string AtivoFiltro { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoAte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoAte { get; set; }

        public ProfissaoDataTransfer() 
            : base()
        {
            this.Profissao = new ProfissaoEntity();
            this.ProfissaoLista = new List<ProfissaoEntity>();
        }

        public ProfissaoDataTransfer(ProfissaoDataTransfer profissaoDataTransfer) 
            : base(profissaoDataTransfer)
        {
            if (profissaoDataTransfer != null) {
                this.Profissao = new ProfissaoEntity(profissaoDataTransfer.Profissao);
                this.ProfissaoLista = new List<ProfissaoEntity>(profissaoDataTransfer.ProfissaoLista);
                this.IdDe = profissaoDataTransfer.IdDe;
                this.IdAte = profissaoDataTransfer.IdAte;
                this.AtivoFiltro = profissaoDataTransfer.AtivoFiltro;
                this.CriacaoDe = profissaoDataTransfer.CriacaoDe;
                this.CriacaoAte = profissaoDataTransfer.CriacaoAte;
                this.AlteracaoDe = profissaoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = profissaoDataTransfer.AlteracaoAte;
            }
        }
    }
}
