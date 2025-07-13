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
                _error = "����� � ������ �� ������ ���� �������.";
                return Page();
            }
            var result = _serviceGame.GetPlayerByName(player.Login);

            if (result != null)
            {
                _error = "������������ � ����� ������� ��� ����������.";
                

                return Page();
            }
            else
            {
                player.SaveSceneId = 1;
                _serviceGame.AddPlayer(player);

            }
            _error = "����� ��������������� ������� ������ ������ � �������- �����!";
            return Page();
           


        }
        public IActionResult OnPostEntrance()
        {
            
            if (string.IsNullOrWhiteSpace(player.Login) || string.IsNullOrWhiteSpace(player.Password))
            {
                _error = "����� � ������ �� ������ ���� �������.";
                return Page();
            }
            var result = _serviceGame.GetPlayerByName(player.Login);
            if (result == null)
            {
                _error = "������������ � ����� ������� �� ����������.";

                return Page();
            }
          
            
                HttpContext.Session.SetInt32("PlayerId", result.Id);
                return RedirectToPage("/SceneP/ScenePage", new { sceneId = result.SaveSceneId });
            

        }
        public IActionResult OnPostDelete() 
        {
            if (player.Login == null)
            {
                _error = "���� �����  �� ������ ���� ������.";

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
                _error = "������������ � ����� ������� �� ����������.";
                return Page();
            }
        }

    }
}
