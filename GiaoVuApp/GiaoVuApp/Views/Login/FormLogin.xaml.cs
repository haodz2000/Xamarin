using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoVuApp.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormLogin : ContentView
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            string user = username.Text;
            string pwd = password.Text;
            if(user == string.Empty && pwd == string.Empty)
            {
                return;
            }
            App.Request("login",user,pwd);
        }
    }
    class Index: BaseView<FormLogin, object> { }
}