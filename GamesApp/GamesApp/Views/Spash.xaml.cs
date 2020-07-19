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
    public partial class Spash : ContentPage
    {
        public Spash()
        {
            InitializeComponent();
            this.Scale();
            this.navegacao();
            
        }

        public async void navegacao()
        {
            await Task.Delay(8000);
            App.Current.MainPage = new NavigationPage(new LoginPage());

        }
        public async void Scale()
        {
            await image.ScaleTo(1.5, 1000);
            await image.ScaleTo(0.5, 5000, Easing.BounceIn);
            await image.ScaleTo(1, 1000, Easing.BounceOut);

        }
    }
}