using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class GeneroSocialTransfer : TransferDominios
    {
        public GeneroSocialEntity GeneroSocial { get; set; }

        public IList<GeneroSocialEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.GeneroSocial != null) ? this.GeneroSocial.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/GeneroSocial", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/GeneroSocial/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/GeneroSocial/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/GeneroSocial", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/GeneroSocial", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/GeneroSocial/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public GeneroSocialTransfer() 
            : base()
        {
        }

        public GeneroSocialTransfer(GeneroSocialTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<GeneroSocialEntity>(transfer.Lista);
                }
                if (transfer.GeneroSocial != null) {
                    this.GeneroSocial = new GeneroSocialEntity(transfer.GeneroSocial);
                }
            }
        }

        public void IncluirGeneroSocial(GeneroSocialEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<GeneroSocialEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
