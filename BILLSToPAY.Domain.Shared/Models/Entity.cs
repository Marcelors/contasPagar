using System;

namespace BILLSToPAY.Domain.Shared.Models
{
    public class Entity
    {
        public Guid Id { get; protected set; }

        public void NewId()
        {
            Id = Guid.NewGuid();
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
