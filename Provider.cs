using System;
using System.Collections.Generic;
using System.Text;

namespace HttpRequest
{
    class Provider
    {

        public int id { get; set; }
        public string name { get; set; }
        public Object avatar_id { get; set; }
        public string email { get; set; }

        public static explicit operator Provider(string v)
        {
            throw new NotImplementedException();
        }
    }
}
