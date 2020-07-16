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
    public partial class CadastroJogo : ContentPage
    {
        public CadastroJogo()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(producerEntry.Text) && !string.IsNullOrWhiteSpace(genreEntry.Text))
            {
                await App.Database.SaveJogoAsync(new Jogo
                {
                    Nome = nameEntry.Text,
                    Produtora = producerEntry.Text,
                    Genero = genreEntry.Text
                });

                nameEntry.Text = producerEntry.Text = genreEntry.Text = string.Empty;
            }
        }
    }
}