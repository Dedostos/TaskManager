namespace TaskManager.Api.Models
{

    public class Project : CommonObject
    {
        public int Id { get; set; }
        // ставим вопрос на случай если пользователя удалят
        public int? AdminId { get; set; } // тут будет связь один ко многим. есть только 1 админ у которого может быть множество проектов
        public ProjectAdmin Admin { get; set; }
        public List<User> AllUsers { get; set; } = new List<User>();
        // доска будет автоматически пренадлежать к проекту, она будет создаваться на основе проекта
        public List<Desk> AllDesks { get; set; } = new List<Desk>();
        public ProjectStatus Status { get; set; }

    }
}
