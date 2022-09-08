using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Brand:Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Model> Models { get; set; }

        public Brand()
        {
        }

        public Brand(int id, string name, bool isActive):this()
        {
            Id = id;
            Name = name;
            IsActive = isActive;

        }


    }
}
