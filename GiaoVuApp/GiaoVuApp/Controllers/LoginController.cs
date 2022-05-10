using System;
using System.Collections.Generic;
using System.Text;

namespace GiaoVuApp.Controllers
{
    public class LoginController: Base
    {
        public object Index()
        {
            return View();
        }
        public object  Index(string user, string pwd)
        {
            var context = new Document
            {
                Url = "account/login",
                Value = new Document
                {
                    UserName = user,
                    Password = pwd,
                }
            };
            var res = context.CallAPI();
            if(res.Code == 0)
            {
                var data = res.ValueContext;
                ProfileDoc.Update(Document.FromObject(data["profile"]));
                return Redirect("home");
            }
            else
            {

            }
            return null;
        }
    }
}
