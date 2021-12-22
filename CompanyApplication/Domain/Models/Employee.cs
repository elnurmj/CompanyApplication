
using Domain.Common;

namespace Domain.Models
{
    public class Employee:BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
