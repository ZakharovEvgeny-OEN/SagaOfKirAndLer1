using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SagaOfKirAndLer.Model;

namespace SagaOfKirAndLer.DataBase.Context
{
    public class DbGameContext : DbContext
    {
        public DbSet<Scene> SceneGame { get; set; }

        public DbSet<Choice> ChoiceGame { get; set; }

        public DbSet<PlayerProgress> PlayerGame { get; set; }

        public DbGameContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306; user=root; password=; database=SagaKandL ", new MySqlServerVersion(new Version(8, 2, 12)));
        }
    }
}
