namespace rcDominiosEntities
{
    public class Entity
    {
        public int Id { get; set; }

        public Entity() 
        {
        }

        public Entity(int id) 
        {
            this.Id = id;
        }

        public Entity(Entity entidade) 
        {
            if (entidade != null) {
                this.Id = entidade.Id;
            }
        }
    }
}
