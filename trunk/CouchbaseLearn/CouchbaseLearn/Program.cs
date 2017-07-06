using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouchbaseLearn
{
    using Couchbase;

    class Program
    {
        static void Main(string[] args)
        {
            ClusterHelper.Initialize();
            var cluster = ClusterHelper.Get();
            var manager = cluster.CreateManager("administrator", "gaofeng");
            var managerResult = manager.CreateBucket("test",1000U);
            if (!managerResult.Success)
            {
                return;
            }
            using (var bucket = cluster.OpenBucket("test"))
            {
                var result = bucket.Insert("fookey", "foovalue");
                var temp = bucket.Get<string>("fookey");
                Console.WriteLine(temp);
                //result = bucket.Upsert("fookey", "foovalue2");
                //var result1 = bucket.Remove("fookey");
                //Console.WriteLine(result1);
                Console.ReadLine();
            }
        }
    }
}
