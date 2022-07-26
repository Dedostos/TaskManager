namespace TaskManager.Api.Models   // тут ещё будет стоять .Abstraction его можно убрать
{
    public class CommonObject // общий объект
    {
        public string Name { get; set; }
        public string Description { get; set; } // описание
        public DateTime CrearionDate { get; set; }
        public byte[] Photo { get; set; }
        public CommonObject()
        {
            CrearionDate = DateTime.Now;
        }
    }
}
