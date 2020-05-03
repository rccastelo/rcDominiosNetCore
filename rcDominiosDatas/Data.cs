using System.Collections.Generic;
using System.Linq;
using rcDominiosDatabase;
using rcDominiosEntities;

namespace rcDominiosDatas
{
    public class Data<EntityType> : IData<EntityType> where EntityType : Entity
    {
        protected readonly DominiosDbContext _contexto;

        public Data(DominiosDbContext contexto)
        {
            _contexto = contexto;
        }

        public EntityType ConsultarPorId(int id)
        {
            return _contexto.Set<EntityType>().SingleOrDefault(et => et.Id == id);
        }

        public void Incluir(EntityType entidade)
        {
            _contexto.Set<EntityType>().Add(entidade);
        }

        public void Alterar(EntityType entidade)
        {
            _contexto.Set<EntityType>().Update(entidade);
        }

        public void Excluir(EntityType entidade)
        {
            _contexto.Set<EntityType>().Remove(entidade);
        }

        public IList<EntityType> Listar()
        {
            return _contexto.Set<EntityType>().ToList();
        }
    }
}
