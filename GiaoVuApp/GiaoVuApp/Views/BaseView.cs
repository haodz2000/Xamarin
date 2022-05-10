using System;
using System.Collections.Generic;
using System.Text;
using System.Mvc;
using Xamarin.Forms;

namespace GiaoVuApp.Views
{
    class BaseView<TView, TModel> : IView
        where TView: View, new()
    {
        public TView MainContent { get; set; }
        public TModel Model { get; set; }
        public ViewDataDictionary ViewBag { get ; set; }

        public object Content => CreatePage();

        public virtual Page CreatePage() => new ContentPage { Content = MainContent };

        public void Render(object model)
        {
            MainContent = new TView();
            Model = (TModel)model;
            RenderCore();
        }

        protected virtual void RenderCore()
        {
            
        }
    }
}
