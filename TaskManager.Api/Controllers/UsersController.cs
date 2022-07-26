using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Models.Data;
using TaskManager.Common.Models;

namespace TaskManager.Api.Controllers
{
    // Этот атрибут позволяет указать как мы будем обращаться с фронтэнда к бэкэнду
    // В скобках указано как мы будем обращаться 
    // т.е мы будем писать api/Users   слово  Controller нам писать не нужно будет, только первую часть Users
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _db; // _ в начале нужно просто для того чтобы потом не писать this.db 
        public UsersController(ApplicationContext db)
        {
            Console.WriteLine("+++++++++++");
            _db = db;
            
        }
        // Зделаем пишем асинхронный вызов (можно сделать синхронный)

        // чтобы зарегистрировать наш запрос записываем атрибут
        // [HttpPost] - для записи данных
        // записываем в скобках create чтобы с фронтэнда мы могли обращаться api.Users/create


        // для того чтобы получить из тела запроса необходимые данные записываем следующие элементы в скобках ниже
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserModel userModel) // будет некоторая модель пользователя  IActionResult
        {
            if (userModel != null) // проверка чтобы избежать исключений
            {
                // создаём пользователя
                User newUser = new User(userModel.FirstName, userModel.LastName, userModel.Email,
                    userModel.Password, userModel.Status, userModel.Phone, userModel.Photo);

                //  вносим в БД
                // обращаемся к базе данных(_db) вызываем таблицу Users  и  дабавляем элементы
                //_db.Users.Add(newUser);// ЗАМЕТЬ МЫ НЕ ПРИСВАЕВАЕ ID ЭТО ЗА НАС СДЕЛАЕТ БАЗА ДАННЫХ
                //_db.SaveChanges(); // сохраняем изменения
                // и возврашаем метод Ok 
                return Ok(); //
            }
            return BadRequest(); // если предыдущий ретёрн не отработает вылетит исключение с этого
           
        }
        [HttpGet("test")] // атрибут для записи
        public IActionResult TestApi()
        {
           return Ok("Привет");
        }
    }
}
