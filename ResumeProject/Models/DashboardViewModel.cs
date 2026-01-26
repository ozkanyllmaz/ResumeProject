using ResumeProject.Entities;

namespace ResumeProject.Models
{
    public class DashboardViewModel
    {
        //istatistik kartlari için
        public int TotalMessageCount { get; set; }
        public int TotalProjectCount { get; set; }
        public int TotalExperienceCount { get; set; }
        public int TotalServiceCount { get; set; }

        //hakkimda kismi
        public About AboutInfo { get; set; }

        //son gelen mesajlar listesi (son 3 mesaj)
        public List<Message> lastMessages { get; set; }

        //son eklenen proje listesi (son 3)
        public List<Portfolio> lastPortfolio { get; set; }
    }
}
