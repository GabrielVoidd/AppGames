using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalAdmin : ContentPage
    {
        public PrincipalAdmin()
        {
            InitializeComponent();
        }

        private async void Click_CadastrarUsuario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroUsuario());
        }

        private async void Click_ListarUsuario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListagemUsuarios());

        }

        private async void Click_CadastrarJogo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroJogo());
        }

        private async void Click_ListarJogo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListagemJogos());
        }


        private async void Click_Sobre(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }

        private async void Click_Logout(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}