using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SagaOfKirAndLer.DataBase.Context;
using SagaOfKirAndLer.Model;
using SagaOfKirAndLer.Service;

namespace SagaOfKirAndLer.Pages.Registration
{
    public class RegistrationPageModel : PageModel
    {
        [BindProperty]
        public PlayerProgress player { get; set; } 

        public ServiceGame _serviceGame;

        public string _error="";
        public RegistrationPageModel( ServiceGame serviceGame)
        {
            _serviceGame = serviceGame;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostSave()
        {
            if (string.IsNullOrWhiteSpace(player.Login) || string.IsNullOrWhiteSpace(player.Password))
            {
                _error = "Логин и пароль не должны быть пустыми.";
                return Page();
            }
            var result = _serviceGame.GetPlayerByName(player.Login);

            if (result != null)
            {
                _error = "Пользователь с таким логином уже существует.";
                

                return Page();
            }
            else
            {
                player.SaveSceneId = 1;
                _serviceGame.AddPlayer(player);

            }
            _error = "Игрок Зарегистрирован введите Логини Пароль и нажмите- ВОЙТИ!";
            return Page();
           


        }
        public IActionResult OnPostEntrance()
        {
            
            if (string.IsNullOrWhiteSpace(player.Login) || string.IsNullOrWhiteSpace(player.Password))
            {
                _error = "Логин и пароль не должны быть пустыми.";
                return Page();
            }
            var result = _serviceGame.GetPlayerByName(player.Login);
            if (result == null)
            {
                _error = "Пользователь с таким логином не существует.";

                return Page();
            }
          
            
                HttpContext.Session.SetInt32("PlayerId", result.Id);
                return RedirectToPage("/SceneP/ScenePage", new { sceneId = result.SaveSceneId });
            

        }
        public IActionResult OnPostDelete() 
        {
            if (player.Login == null)
            {
                _error = "Поле логин  не должно быть пустым.";

                return Page();
            }
            var rezult = _serviceGame.GetPlayerByName(player.Login);
            if( rezult != null)
            {
                _serviceGame.DeletePlayer(rezult);
                return Page();
            }
            else
            {
                _error = "Пользователь с таким логином не существует.";
                return Page();
            }
        }

    }
}
