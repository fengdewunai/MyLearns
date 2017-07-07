using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringNetMvc.Models
{
    public class Hello : IHello
    {

        public string HelloWord()
        {
            return "Hello World!";
        }
    }
}