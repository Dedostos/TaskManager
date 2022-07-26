using TaskManager.Common.Models;

namespace TaskManager.Api.Models
{
    public class User
    {
        // Создаём нужные свойства

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; } // когда в последний раз логинелся пользователь 
        public byte[] Photo { get; set; } // для хранения фото пользователя мы будем использовать массив байтов
        // создадим список проектов. это будет связь многие ко многим, тк у пользователя может быть множество обектов проджекта
        // так и у проджекта множество пользователей
        public List<Project> Projects { get; set; } = new List<Project>(); // entity framework отношения
        public List<Desk> Desks { get; set; } = new List<Desk>(); // entity framework отношения
        public List<Task> Tasks { get; set; } = new List<Task>(); // entity framework отношения
        public UserStatus Status { get; set; }
        // также мы хотим знать на какой стадии находится проект
        public User() { }
        public User(string fname, string lname, string email, string password, 
            UserStatus status = UserStatus.User, string phone=null,byte[] photo = null) // указываем значение параметров по умолчанию
        {
            FirstName = fname;
            LastName = lname;
            Email = email;
            Password = password;
            Phone = phone;
            Photo = photo;
            RegistrationDate = DateTime.Now;
            Status = status;
        }
        public UserModel ToDto() // передача данных между подсистемами
        {
            return new UserModel()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Password = this.Password,
                Phone = this.Phone,
                Photo = this.Photo,
                RegistrationDate = this.RegistrationDate,
                Status = this.Status
        };
        }
    }
}
