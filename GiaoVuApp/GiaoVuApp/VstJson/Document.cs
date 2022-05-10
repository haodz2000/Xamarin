﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace System
{

    public partial class Document
    {
        #region Request
        public string Url { get { return GetString("#url"); } set => Push("#url", value); }
        public string ClientId { get { return GetString("#cid"); } set => Push("#cid", value); }
        public string Token { get { return GetString("#token"); } set => Push("#token", value); }
        public string Action { get { return GetString("#action"); } set => Push("#action", value); }
        #endregion

        #region Response
        public object Value { get { return GetValueCore("value", false); } set => Push("value", value); }
        public int Code { get { return GetValue<int>("code"); } set => Push("code", value); }
        public string Message { get { return GetString("message"); } set => Push("message", value); }
        #endregion

        #region VALUES
        Document _valueContext;
        public Document ValueContext
        {
            get
            {
                if (_valueContext == null)
                {
                    object value = Value;
                    _valueContext = (value == null ? new Document() : FromObject(value));
                }
                return _valueContext;
            }
        }
        public T GetValue<T>() => (T)Convert.ChangeType(Value, typeof(T));
        #endregion

        #region CONVERT
        public string Join(string seperator, params string[] names)
        {
            string s = string.Empty;
            foreach (string name in names)
            {
                object v;
                if (this.TryGetValue(name, out v))
                {
                    if (s.Length > 0) { s += seperator; }
                    s += v.ToString();
                }
            }
            return s;
        }
        public static implicit operator Document(string s)
        {
            return Parse<Document>(s);
        }
        public static implicit operator Document(byte[] bytes)
        {
            return Parse<Document>(bytes.UTF8());
        }
        public static explicit operator byte[](Document context)
        {
            return context.ToString().UTF8();
        }
        #endregion

        #region API
        public Document CallAPI(string url, Func<string, Document> parse)
        {
            var request = WebRequest.Create(url);
            try
            {
                request.Method = "POST";
                request.ContentType = "application/json";


                using (var sw = new System.IO.StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(this.ToString());
                }

                var response = request.GetResponse() as HttpWebResponse;
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
                    {
                        var content = reader.ReadToEnd();
                        if (parse != null)
                        {
                            return parse(content);
                        }
                        return Parse<Document>(content);
                    }
                }
            }
            catch (Exception e)
            {
                return new Document { Code = 400, Message = e.Message };
            }
        }
        #endregion

        public Document CallAPI(string url)
        {
            return CallAPI(url, null);
        }
        public Document CallAPI()
        {
            return CallAPI("http://vst.edu.vn/api/common", null);
        }
    }
}
