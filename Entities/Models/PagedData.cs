using System.Collections;
using System.Collections.Generic;

namespace Entities.Models
{
    public class PagedData<T> : IEnumerable<T>
    {
        public long Total { get; set; }

        public List<T> Items { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
