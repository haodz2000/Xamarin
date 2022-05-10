using System;
using System.Collections.Generic;
using System.Text;
using System.Mvc;

namespace GiaoVuApp.Controllers
{
    public class Base: Controller
    {
        public static Models.Profile _profile;
        public static Models.Profile ProfileDoc
        {
            get
            {
                if (_profile == null)
                {
                    _profile = new Models.Profile();
                }
                return _profile;
            }
        }
        public object Index()
        {
            return View();
        }
    }
}
