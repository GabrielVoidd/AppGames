using GamesApp.Models;
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
    public partial class CadastroUsuario : ContentPage
    {
        public CadastroUsuario()
        {
            InitializeComponent();
        }

        async void ButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryNome.Text) && !string.IsNullOrWhiteSpace(entryNickname.Text) && !string.IsNullOrWhiteSpace(entrySenha.Text))
            {
                await App.Database.SaveUsuarioAsync(new Usuario
                {
                    Nome = entryNome.Text,
                    Nickname = entryNickname.Text,
                    Senha = entrySenha.Text
                });

                entryNome.Text = entryNickname.Text = entrySenha.Text = string.Empty;
            }
        }
    }
}