namespace Infraestructure.Repository.Mongo
{
    using System;
    using MongoDB.Driver;

    public interface IMongoContext : IDisposable
    {
        IMongoCollection<T> GetCollection<T>();
    }
}
