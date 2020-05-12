using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class ContaBancariaDataTransfer : DataTransfer
    {
        public ContaBancariaEntity ContaBancaria { get; set; }

        public IList<ContaBancariaEntity> ContaBancariaLista { get; set; }

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

        public ContaBancariaDataTransfer() 
            : base()
        {
            this.ContaBancaria = new ContaBancariaEntity();
            this.ContaBancariaLista = new List<ContaBancariaEntity>();
        }

        public ContaBancariaDataTransfer(ContaBancariaDataTransfer contaBancariaDataTransfer) 
            : base(contaBancariaDataTransfer)
        {
            if (contaBancariaDataTransfer != null) {
                this.ContaBancaria = new ContaBancariaEntity(contaBancariaDataTransfer.ContaBancaria);
                this.ContaBancariaLista = new List<ContaBancariaEntity>(contaBancariaDataTransfer.ContaBancariaLista);
                this.IdDe = contaBancariaDataTransfer.IdDe;
                this.IdAte = contaBancariaDataTransfer.IdAte;
                this.AtivoFiltro = contaBancariaDataTransfer.AtivoFiltro;
                this.CriacaoDe = contaBancariaDataTransfer.CriacaoDe;
                this.CriacaoAte = contaBancariaDataTransfer.CriacaoAte;
                this.AlteracaoDe = contaBancariaDataTransfer.AlteracaoDe;
                this.AlteracaoAte = contaBancariaDataTransfer.AlteracaoAte;
            }
        }
    }
}
