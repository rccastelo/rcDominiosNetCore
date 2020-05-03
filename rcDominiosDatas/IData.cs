using System.Collections.Generic;

namespace rcDominiosDatas
{
    public interface IData<EntityType>
    {
        EntityType ConsultarPorId(int id);

        void Incluir(EntityType entidade);

        void Alterar(EntityType entidade);

        void Excluir(EntityType entidade);

        IList<EntityType> Listar();
    }
}
