using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class UsuarioDataTransfer : DataTransfer
    {
        public UsuarioEntity Usuario { get; set; }

        public IList<UsuarioEntity> UsuarioLista { get; set; }

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

        public UsuarioDataTransfer() 
            : base()
        {
            this.Usuario = new UsuarioEntity();
            this.UsuarioLista = new List<UsuarioEntity>();
        }

        public UsuarioDataTransfer(UsuarioDataTransfer usuarioDataTransfer) 
            : base(usuarioDataTransfer)
        {
            if (usuarioDataTransfer != null) {
                this.Usuario = new UsuarioEntity(usuarioDataTransfer.Usuario);
                this.UsuarioLista = new List<UsuarioEntity>(usuarioDataTransfer.UsuarioLista);
                this.IdDe = usuarioDataTransfer.IdDe;
                this.IdAte = usuarioDataTransfer.IdAte;
                this.AtivoFiltro = usuarioDataTransfer.AtivoFiltro;
                this.CriacaoDe = usuarioDataTransfer.CriacaoDe;
                this.CriacaoAte = usuarioDataTransfer.CriacaoAte;
                this.AlteracaoDe = usuarioDataTransfer.AlteracaoDe;
                this.AlteracaoAte = usuarioDataTransfer.AlteracaoAte;
            }
        }
    }
}
