using System;
using Assignment.Core.Models.Base;

namespace Assignment.Core.Models
{
    /// <summary>
    ///     Post base class
    /// </summary>
    public class Post : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}