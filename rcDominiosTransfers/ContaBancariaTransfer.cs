using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
    public class ContaBancariaTransfer : TransferDominios
    {
        public ContaBancariaEntity ContaBancaria { get; set; }

        public IList<ContaBancariaEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.ContaBancaria != null) ? this.ContaBancaria.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/ContaBancaria", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/ContaBancaria/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/ContaBancaria/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/ContaBancaria", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/ContaBancaria", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/ContaBancaria/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public ContaBancariaTransfer() 
            : base()
        {
        }

        public ContaBancariaTransfer(ContaBancariaTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<ContaBancariaEntity>(transfer.Lista);
                }
                if (transfer.ContaBancaria != null) {
                    this.ContaBancaria = new ContaBancariaEntity(transfer.ContaBancaria);
                }
            }
        }

        public void IncluirContaBancaria(ContaBancariaEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<ContaBancariaEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
