using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class UsuarioTransfer : Transfer
    {
        public UsuarioEntity Usuario { get; set; }

        public IList<UsuarioEntity> Lista { get; set; }

        public TransferPaginacao Paginacao { get; set; }

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

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Usuario != null) ? this.Usuario.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/Usuario", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/Usuario/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/Usuario/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/Usuario", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/Usuario", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/Usuario/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public UsuarioTransfer() 
            : base()
        {
            this.Paginacao = new TransferPaginacao();
        }

        public UsuarioTransfer(UsuarioTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<UsuarioEntity>(transfer.Lista);
                }
                if (transfer.Usuario != null) {
                    this.Usuario = new UsuarioEntity(transfer.Usuario);
                }
                if (transfer.Paginacao != null) {
                    this.Paginacao = new TransferPaginacao(transfer.Paginacao);
                }
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
                if (this.Lista == null) {
                    this.Lista = new List<UsuarioEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}