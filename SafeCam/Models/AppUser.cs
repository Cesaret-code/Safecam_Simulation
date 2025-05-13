using SafeCam.Models.Base;

namespace SafeCam.Models
{
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
