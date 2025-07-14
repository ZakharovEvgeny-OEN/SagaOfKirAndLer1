using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SagaOfKirAndLer.Model;
using SagaOfKirAndLer.Service;

namespace SagaOfKirAndLer.Pages.SceneP
{
    public class ScenePageModel : PageModel
    {
        public Scene  CurentScene { get; set; }=new Scene();
        public ServiceGame _serviceGame;

       public PlayerProgress player;

        public ScenePageModel(ServiceGame serviceGame)
        {
            _serviceGame = serviceGame;
        }
        public void  OnGet(int sceneId)
        {
            
            int? playerId = HttpContext.Session.GetInt32("PlayerId");
            if (playerId == null)
            {
                 RedirectToPage("/Registration/RegistrationPage");
            }
            if (sceneId < 0)
            {
                 RedirectToPage("/Registration/RegistrationPage");
            }

            CurentScene = _serviceGame.GetSceneById(sceneId);
            if (CurentScene == null)
            {
                 NotFound(); // или другая страница
            }
            player = _serviceGame.GetPlayerById(playerId.Value);
            if (player == null)
            {
                 RedirectToPage("/Registration/RegistrationPage");
            }
            player.SaveSceneId = sceneId;
            _serviceGame.UpdatePlayer(player);
            

        }

       
    }
}
