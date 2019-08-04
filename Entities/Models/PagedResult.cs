using System.Collections.Generic;

namespace Entities.Models
{
    public class PagedResult<TDto> where TDto : class
    {
        public long Total { get; set; }
        public List<TDto> Items { get; set; }
    }
}
