using ResumeProject.Entities;

namespace ResumeProject.Models
{
    public class CVViewModel
    {
        public About About { get; set; }
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Service> Services { get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
