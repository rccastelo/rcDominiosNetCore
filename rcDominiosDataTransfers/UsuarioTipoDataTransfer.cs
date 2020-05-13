using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosDataTransfers
{
    public class UsuarioTipoDataTransfer : DataTransfer
    {
        public UsuarioTipoEntity UsuarioTipo { get; set; }

        public IList<UsuarioTipoEntity> UsuarioTipoLista { get; set; }

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

        public UsuarioTipoDataTransfer() 
            : base()
        {
            this.UsuarioTipo = new UsuarioTipoEntity();
            this.UsuarioTipoLista = new List<UsuarioTipoEntity>();
        }

        public UsuarioTipoDataTransfer(UsuarioTipoDataTransfer usuarioTipoDataTransfer) 
            : base(usuarioTipoDataTransfer)
        {
            if (usuarioTipoDataTransfer != null) {
                this.UsuarioTipo = new UsuarioTipoEntity(usuarioTipoDataTransfer.UsuarioTipo);
                this.UsuarioTipoLista = new List<UsuarioTipoEntity>(usuarioTipoDataTransfer.UsuarioTipoLista);
                this.IdDe = usuarioTipoDataTransfer.IdDe;
                this.IdAte = usuarioTipoDataTransfer.IdAte;
                this.AtivoFiltro = usuarioTipoDataTransfer.AtivoFiltro;
                this.CriacaoDe = usuarioTipoDataTransfer.CriacaoDe;
                this.CriacaoAte = usuarioTipoDataTransfer.CriacaoAte;
                this.AlteracaoDe = usuarioTipoDataTransfer.AlteracaoDe;
                this.AlteracaoAte = usuarioTipoDataTransfer.AlteracaoAte;
            }
        }
    }
}
