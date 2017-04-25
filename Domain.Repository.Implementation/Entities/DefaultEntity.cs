namespace Domain.Repository.Implementation
{
    using System;

    public class DefaultEntity : IDefaultEntity

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
