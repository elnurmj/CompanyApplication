

using Domain.Common;

namespace Domain.Models
{
    public class Company:BaseEntity
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
