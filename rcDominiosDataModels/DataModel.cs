using rcDominiosDatabase;

namespace rcDominiosDataModels
{
    public abstract class DataModel
    {
        protected readonly DominiosDbContext _contexto;

        protected DataModel()
        {
            _contexto = new DominiosDbContext();
        }        
    }
}
