using Microsoft.EntityFrameworkCore; // для DbContext
using TaskManager.Common.Models; // для UserStatus

namespace TaskManager.Api.Models.Data
{
    public class ApplicationContext : DbContext
    {
        // здесь мы пропишем все таблицы которые нам понадобятся
        // указываем наши таблицы 
        public DbSet<User> Users { get; set; } // так мы указываем таблицу
        public DbSet<ProjectAdmin> ProjectAdmins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public ApplicationContext() { } // это можно убрать
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) // передаём именно в базовый класс
        {

            Database.EnsureCreated(); // для того чтобы убедится что база данных создана
            if (this.Users.Any(u => u.Status == UserStatus.Admin) == false) // заполняем админа
            {
                var admin = new User("Alexey","Krapivin","scorpion52003","qwerty212",UserStatus.Admin);
                Users.Add(admin);
                SaveChanges(); // сохранить изменения. относится к DbContext
            }
        }
        // есть два способа для создания баз данных через json файл и через конструкцию представленную ниже
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TaskManager.ApiDB;Trusted_Connection=True;");
        }

    }
}
