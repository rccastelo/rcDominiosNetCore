using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class UsuarioTransfer : Transfer
    {
        public UsuarioEntity Usuario { get; set; }

        public IList<UsuarioEntity> UsuarioLista { get; set; }

        public int PaginaAtual { get; set; }

        public int PaginaInicial { get; set; }

        public int PaginaFinal { get; set; }

        public int RegistrosPorPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public int IdDe { get; set; }

        public int IdAte { get; set; }

        public string Apelido { get; set; }

        public string Senha { get; set; }

        public string NomeApresentacao { get; set; }

        public string NomeCompleto { get; set; }

        public string Ativo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CriacaoAte { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoDe { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AlteracaoAte { get; set; }

        public UsuarioTransfer() 
            : base()
        {
        }

        public UsuarioTransfer(UsuarioTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.UsuarioLista != null) {
                    this.UsuarioLista = new List<UsuarioEntity>(transfer.UsuarioLista);
                }
                if (transfer.Usuario != null) {
                    this.Usuario = new UsuarioEntity(transfer.Usuario);
                }
                this.PaginaAtual = transfer.PaginaAtual;
                this.PaginaInicial = transfer.PaginaInicial;
                this.PaginaFinal = transfer.PaginaFinal;
                this.RegistrosPorPagina = transfer.RegistrosPorPagina;
                this.TotalRegistros = transfer.TotalRegistros;
                this.TotalPaginas = transfer.TotalPaginas;
                this.IdDe = transfer.IdDe;
                this.IdAte = transfer.IdAte;
                this.Apelido = transfer.Apelido;
                this.Senha = transfer.Senha;
                this.NomeApresentacao = transfer.NomeApresentacao;
                this.NomeCompleto = transfer.NomeCompleto;
                this.Ativo = transfer.Ativo;
                this.CriacaoDe = transfer.CriacaoDe;
                this.CriacaoAte = transfer.CriacaoAte;
                this.AlteracaoDe = transfer.AlteracaoDe;
                this.AlteracaoAte = transfer.AlteracaoAte;
            }
        }

        public void IncluirUsuario(UsuarioEntity entity) {
            if (entity != null) {
                if (this.UsuarioLista == null) {
                    this.UsuarioLista = new List<UsuarioEntity>();
                }

                this.UsuarioLista.Add(entity);
            }
        }
    }
}
