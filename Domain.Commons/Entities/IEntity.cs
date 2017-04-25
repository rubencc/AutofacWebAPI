namespace Domain.Commons
{
    using System;
   
    public interface IEntity<TKey> where TKey : IComparable<TKey>, IComparable
    {
        TKey Id { get; set; }
    }
}
