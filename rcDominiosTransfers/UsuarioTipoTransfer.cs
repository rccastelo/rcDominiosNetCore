using System.Collections.Generic;
using rcDominiosEntities;

namespace rcDominiosTransfers
{
  public class UsuarioTipoTransfer : TransferDominios
    {
        public UsuarioTipoEntity UsuarioTipo { get; set; }

        public IList<UsuarioTipoEntity> Lista { get; set; }

        public object Links { get; set; }

        public void TratarLinks() {
            string id = ((this.UsuarioTipo != null) ? this.UsuarioTipo.Id.ToString() : "0");

            var obj = new object[] {
                new {
                    info = "Listar", 
                    uri = "/rcDominiosNet/UsuarioTipo", 
                    method = "GET"
                },
                new {
                    info = "Consultar por id", 
                    uri = "/rcDominiosNet/UsuarioTipo/" + id, 
                    method = "GET"
                },
                new {
                    info = "Filtrar", 
                    uri = "/rcDominiosNet/UsuarioTipo/lista", 
                    method = "POST"
                },
                new {
                    info = "Incluir", 
                    uri = "/rcDominiosNet/UsuarioTipo", 
                    method = "POST"
                },
                new {
                    info = "Alterar", 
                    uri = "/rcDominiosNet/UsuarioTipo", 
                    method = "PUT"
                },
                new {
                    info = "Excluir por id", 
                    uri = "/rcDominiosNet/UsuarioTipo/" + id,
                    method = "DELETE"
                }
            };
            
            this.Links = obj;
        }

        public UsuarioTipoTransfer() 
            : base()
        {
        }

        public UsuarioTipoTransfer(UsuarioTipoTransfer transfer) 
            : base(transfer)
        {
            if (transfer != null) {
                if (transfer.Lista != null) {
                    this.Lista = new List<UsuarioTipoEntity>(transfer.Lista);
                }
                if (transfer.UsuarioTipo != null) {
                    this.UsuarioTipo = new UsuarioTipoEntity(transfer.UsuarioTipo);
                }
            }
        }

        public void IncluirUsuarioTipo(UsuarioTipoEntity entity) {
            if (entity != null) {
                if (this.Lista == null) {
                    this.Lista = new List<UsuarioTipoEntity>();
                }

                this.Lista.Add(entity);
            }
        }
    }
}
