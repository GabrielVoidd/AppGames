using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalUsuario : ContentPage
    {
        public PrincipalUsuario()
        {
            InitializeComponent();
        }

        private async void Click_ListagemJogos(object sender, EventArgs e)
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