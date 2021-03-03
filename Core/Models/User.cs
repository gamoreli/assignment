using System;
using Assignment.Core.Models.Base;

namespace Assignment.Core.Models
{
    /// <summary>
    ///     User base class
    /// </summary>
    public class User : Entity<Guid>
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Role { get; set; }
    }
}