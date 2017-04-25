namespace Domain.Repository.Implementation
{
    using System;
    using Domain.Commons;

    public interface IDefaultEntity : IEntity<Guid>
    {
        string Name { get; set; }
    }
}
