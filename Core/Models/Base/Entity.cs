using System;

namespace Assignment.Core.Models.Base
{
    /// <summary>
    ///     Base entity with Id
    /// </summary>
    /// <typeparam name="TKey">Type of id</typeparam>
    public class Entity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}