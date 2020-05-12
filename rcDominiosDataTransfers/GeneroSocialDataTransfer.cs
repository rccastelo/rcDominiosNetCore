using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class GeneroSocialDataTransfer : DataTransfer
    {
        public GeneroSocialEntity GeneroSocial { get; set; }

        public IList<GeneroSocialEntity> GeneroSocialLista { get; set; }

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

        public GeneroSocialDataTransfer() 
            : base()
        {
            this.GeneroSocial = new GeneroSocialEntity();
            this.GeneroSocialLista = new List<GeneroSocialEntity>();
        }

        public GeneroSocialDataTransfer(GeneroSocialDataTransfer generoSocialDataTransfer) 
            : base(generoSocialDataTransfer)
        {
            if (generoSocialDataTransfer != null) {
                this.GeneroSocial = new GeneroSocialEntity(generoSocialDataTransfer.GeneroSocial);
                this.GeneroSocialLista = new List<GeneroSocialEntity>(generoSocialDataTransfer.GeneroSocialLista);
                this.IdDe = generoSocialDataTransfer.IdDe;
                this.IdAte = generoSocialDataTransfer.IdAte;
                this.AtivoFiltro = generoSocialDataTransfer.AtivoFiltro;
                this.CriacaoDe = generoSocialDataTransfer.CriacaoDe;
                this.CriacaoAte = generoSocialDataTransfer.CriacaoAte;
                this.AlteracaoDe = generoSocialDataTransfer.AlteracaoDe;
                this.AlteracaoAte = generoSocialDataTransfer.AlteracaoAte;
            }
        }
    }
}
