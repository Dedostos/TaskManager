namespace TaskManager.Api.Models
{
    public class ProjectAdmin
    {
        // ProjektAdmin нужен для того чтобы пользователь создавший конкретный проект был админом этого проекта
        // юзер может быть как пользователем так и админом
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Project> Projects { get; set; } = new List<Project>();
        public ProjectAdmin() { } // для создания базы данных нужен пкстой конструктор
        public ProjectAdmin(User user)
        {
            UserId = user.Id;
            User = user;
        }
    }
}
