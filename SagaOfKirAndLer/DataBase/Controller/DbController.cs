using Microsoft.EntityFrameworkCore;
using SagaOfKirAndLer.DataBase.Context;
using SagaOfKirAndLer.Model;

namespace SagaOfKirAndLer.DataBase.Controller
{
    public class DbController
    {
        DbGameContext _dbGameContext;

        

        public DbController(DbGameContext dbGameContext)=> _dbGameContext=dbGameContext;    

        public List<Scene> GetAllScenesDb()
        {
            _dbGameContext.Database.OpenConnection();
            var Scenes= _dbGameContext.SceneGame.ToList();
            _dbGameContext.Database.CloseConnection();
            return Scenes;
        }

        public Scene GetSceneDb(int id)
        {
            var scene= _dbGameContext.SceneGame.Include(s=>s.Choices).FirstOrDefault(s=>s.Id==id);


            return scene;
        }

        public PlayerProgress GetPlayerIdDb(int Id)
        {
            var player = _dbGameContext.PlayerGame.FirstOrDefault(p => p.Id == Id);
                return player;
        }

        public PlayerProgress GetPlayerNameDb(string name)
        {
            var player = _dbGameContext.PlayerGame.FirstOrDefault(x => x.Login == name);
            return player;
        }

        public void AddPlayerDb(PlayerProgress _player)
        {
            _dbGameContext.PlayerGame.Add(_player);
            _dbGameContext.SaveChanges();
        }

        public void UpdatePlayerDb(PlayerProgress _player)
        {
            _dbGameContext.PlayerGame.Update(_player);
            _dbGameContext.SaveChanges();
        }
        public void DeletePlayerDb(PlayerProgress _player)
        {
            _dbGameContext.PlayerGame.Remove(_player);
        }
    }
}
