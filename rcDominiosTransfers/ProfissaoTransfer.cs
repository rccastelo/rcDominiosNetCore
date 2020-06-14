using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class ProfissaoTransfer : TransferDominios
    {
        public ProfissaoEntity Profissao { get; set; }

        public IList<ProfissaoEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.Profissao != null) ? this.Profissao.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/Profissao", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/Profissao/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/Profissao/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/Profissao", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/Profissao", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/Profissao/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public ProfissaoTransfer() 
            : base()
        {
        }

        public ProfissaoTransfer(ProfissaoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<ProfissaoEntity>(transfer.Lista);
                }
                if (transfer.Profissao != null) {
                    this.Profissao = new ProfissaoEntity(transfer.Profissao);
                }
            }
        }

        public void IncluirProfissao(ProfissaoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<ProfissaoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
