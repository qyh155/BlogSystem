using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain
{
    public abstract class AppEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; } = default!;
    }
}
