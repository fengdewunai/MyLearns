using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn
{
    using System.Collections;

    public class IndexObject : IWrite
    {
        private ArrayList favoriteNames = new ArrayList();
        private Hashtable properties = new Hashtable();

        public IndexObject()
        {
            this.favoriteNames.Add("aaa");
            this.favoriteNames.Add("bbb");
        }

        public string this[int index]
        {
            get
            {
                return (string)this.favoriteNames[index];
            }
            set
            {
                this.favoriteNames[index] = value;
            }
        }

        public string this[string indexName]
        {
            get
            {
                return (string)this.properties[indexName];
            }
            set
            {
                properties.Add(indexName,value);
            }
        }

        public void Write()
        {
            foreach (var item in favoriteNames)
            {
                Console.WriteLine("favoriteNames值包含：{0}",item);
            }

            foreach (var item in properties.Keys)
            {
                Console.WriteLine("properties中key为{0}，值为：{1}", item,properties[item]);
            }
        }
    }
}
