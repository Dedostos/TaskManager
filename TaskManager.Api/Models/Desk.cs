namespace TaskManager.Api.Models
{
    public class Desk : CommonObject
    {
        public int Id { get; set; }
        public bool IsPrivate { get; set; } // пользователь сможет создавать как публичные так и приватные доски
        public string Columns { get; set; } // будет хранится в json формате
        public int AdminId { get; set; }
        public User Admin { get; set; } // администратор (будет создавать доску)
        public int ProjectId { get; set; } // система сразу поймёт что именно это свойство является ссылкой на нижнее свойство
        public Project Project { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>(); // таск пренадлежит какойто доске и поэтому мы на неё ссылаемся
    }
}
