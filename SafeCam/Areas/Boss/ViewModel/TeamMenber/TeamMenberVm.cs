using System.ComponentModel.DataAnnotations.Schema;

namespace SafeCam.Areas.Boss.ViewModel.TeamMenber
{
    public class TeamMenberVm
    {
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
