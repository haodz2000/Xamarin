using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiaoVuApp
{
    public partial class App : Application
    {
        public static void Request(string url, params object[] args)
        {
            System.Mvc.Engine.Execute(url, args);
        }
        public App()
        {
            InitializeComponent();
            System.Mvc.Engine.Register(this, res =>
            {
                var view = res.View;
                var page = (Page)view.Content;
                if (page != null)
                {
                    MainPage = page;
                }
            });
            //MainPage = new MainPage();
            Request("/login");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
