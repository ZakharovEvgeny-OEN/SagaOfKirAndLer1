using SagaOfKirAndLer.DataBase.Controller;
using SagaOfKirAndLer.Model;

namespace SagaOfKirAndLer.Service
{
    public class ServiceGame
    {
        DbController _dbController;

       

        public ServiceGame(DbController dbController) => _dbController=dbController;

        // Метод для инициализации Singleton (один раз)
       
        // Свойство для получения экземпляра
       

        public List<Scene> GetAll()
        {
            var scenes= _dbController.GetAllScenesDb();
            return scenes;
        }

        public Scene GetSceneById(int id)
        {
            var scene= _dbController.GetSceneDb(id);
            return scene;
        }
        public PlayerProgress GetPlayerById(int id)
        {
            var player= _dbController.GetPlayerIdDb(id);
            return player;
        }


        public PlayerProgress GetPlayerByName(string name)
        {
            var player= _dbController.GetPlayerNameDb(name);
            return player;
        }

        public void AddPlayer(PlayerProgress player)
        {
            _dbController.AddPlayerDb(player);

        }

        public void UpdatePlayer(PlayerProgress player)
        {
            _dbController.UpdatePlayerDb(player);
        }

        public void DeletePlayer(PlayerProgress _player)
        {
            _dbController.DeletePlayerDb(_player);
           
        }


    }
    }

