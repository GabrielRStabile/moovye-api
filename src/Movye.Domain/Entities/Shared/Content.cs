using Movye.Domain.Entities.Shared;

namespace Movye.Domain.Entities
{
    public abstract class Content : Entity
    {
        protected Content(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

    }
}
