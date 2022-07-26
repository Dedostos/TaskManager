namespace TaskManager.Api.Models
{
    public class Task : CommonObject
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] file { get; set; } // массив байтов для сохранения файла
        public int DeskId { get; set; }
        public Desk Desk { get; set; }
        public string Column { get; set; }
        public int? CreatorId { get; set; } // фреймворк видя ? понимает что значение может не быть (null)
        public User Creator { get; set; }
        // знак вопроса означает что в ExecutorId может быть null
        public int? ExecutorId { get; set; } // айди исполнителя
    }
}
