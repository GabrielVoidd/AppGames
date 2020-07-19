using GamesApp.Models;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = viewmodel;
            this.AddDefaultUsers();
        }
        logViewModel viewmodel = new logViewModel();

        private async void AddDefaultUsers()
        {

            var users = await App.Database.GetUsuarioAsync();

            var user = users.Where(u => u.Nickname == "Lid" && u.Senha == "111111").FirstOrDefault();

            if(user == null)
            {
                await App.Database.SaveUsuarioAsync(new Usuario
                {
                    Nome = "Lidiane",
                    Nickname = "Lid",
                    Senha = "111111",
                    IsAdmin = true
                });

                await App.Database.SaveUsuarioAsync(new Usuario
                {
                    Nome = "Thalita Mariano",
                    Nickname = "TM",
                    Senha = "222222"
                });

                await App.Database.SaveUsuarioAsync(new Usuario
                {
                    Nome = "Gabriel Souza",
                    Nickname = "GSZ",
                    Senha = "333333"
                });
            }
        }



    }
}