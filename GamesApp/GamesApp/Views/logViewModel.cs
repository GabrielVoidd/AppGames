using Microsoft.Azure.WebJobs.Host.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GamesApp.Views
{
    public class logViewModel: Bindable
    {
        public logViewModel()
        {
            this.OnClickLogin = new RelayCommand(ClickLoginAsync);
        }

        public string Error
        {
            get { return this.Get<string>(); }
            set
            {
                this.Set(value);
            }
        }


        public string NickName
        {
            get { return this.Get<string>(); }
            set
            {
                this.Set(value);
            }
        }

        public string Password
        {
            get { return this.Get<string>(); }
            set
            {
                this.Set(value);
            }
        }

        public ICommand OnClickLogin { get; set; }
    
        public async void ClickLoginAsync(object args)
        {

                     

                     
            try
            {
                var users = await App.Database.GetUsuarioAsync();

                var user = users.Where(u => NickName.Equals(u.Nickname) && Password.Equals(u.Senha)).FirstOrDefault();

                if (user != null && user.IsAdmin == true)
                {


                    App.Current.MainPage = new NavigationPage(new PrincipalAdmin());
                }
                else
                {
                    if (user != null)
                    {
               
                        App.Current.MainPage = new NavigationPage(new PrincipalUsuario());

                    }
                    else
                    {
                        Error = "Usuário inválido!";
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                }
    }
}
