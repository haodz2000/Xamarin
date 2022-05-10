using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoVuApp.Controllers
{
    public class HomeController: Base
    {
        public object Index()
        {
            return View(ProfileDoc);
        }
    }
}
