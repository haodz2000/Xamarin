using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoVuApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentView
    {
        public Home()
        {
            InitializeComponent();
            
            Name.SetBinding(Button.TextProperty, new Binding("HoTen"));
        }
    }

    internal class Index : BaseView<Home,Models.Profile>
    {
        protected override void RenderCore()
        {
            base.RenderCore();

            Model.Changed += (s, e) => {

            };

            MainContent.BindingContext = Model;
        }
    }
}