using SafeCam.Models.Base;

namespace SafeCam.Models
{
    public class Team:BaseEntity
    {
        public string Fullname { get; set; }
        public string Designation { get; set; }
        public string ImgUrl { get; set; }
    }
}
