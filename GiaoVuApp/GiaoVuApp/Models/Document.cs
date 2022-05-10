using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    partial class Document
    {
        public string UserName { get { return GetString(nameof(UserName)); } set => Push(nameof(UserName), value); }
        public string Password { get { return GetString(nameof(Password)); } set => Push(nameof(Password), value); }
        public string HoTen { get { return GetString(nameof(HoTen)); } set => Push(nameof(HoTen), value); }
    }
    public class ModelView: Document
    {
        public event EventHandler Changed;
        public ModelView Update(Document context)
        {
            context?.Move(this);
            Changed?.Invoke(this, EventArgs.Empty);
            return this;
        }
    }
}
