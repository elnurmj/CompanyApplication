

using Domain.Common;

namespace Domain.Models
{
    public class Company:BaseEntity
    {
        public int RoomCount { get; set; }
        public string Name { get; set; }
    }
}
