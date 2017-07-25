using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    public class RestTest : IRestTest
    {
        public Student Get(string id)
        {
            Console.WriteLine("RestTest接收到Get请求，参数值为:{0}",id);
            return new Student() { name = "张三", age = 21 };
        }

        public string Add(Student stu)
        {
            Console.WriteLine("RestTest接收到Add请求，参数值为:{0}", stu);
            return "添加成功";
        }
    }
}
