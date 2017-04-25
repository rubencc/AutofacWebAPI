namespace Domain.Repository.Implementation
{
    using System;
    using Infraestructure.Commons;

    public interface IDefaultEntity : IEntity<Guid>
    {
        string Name { get; set; }
    }
}
