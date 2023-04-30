using Movye.Domain.Entities.Shared;

namespace Movye.Domain.Entities
{
    public abstract class Content : Entity
    {
        public string Name { get; protected set; }

    }
}
