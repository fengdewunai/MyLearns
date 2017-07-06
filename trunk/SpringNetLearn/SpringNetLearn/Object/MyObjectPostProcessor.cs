using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.Object
{
    using Spring.Objects.Factory;
    using Spring.Objects.Factory.Config;

    public class MyObjectPostProcessor : IObjectPostProcessor, IInstantiationAwareObjectPostProcessor, IDestructionAwareObjectPostProcessor, IObjectFactoryAware
    {
        private IObjectFactory objectFactory;
        public object PostProcessAfterInitialization(object instance, string objectName)
        {
            if (objectName == "postInject" || objectName == "postInjectB")
            {
                Console.WriteLine(this.objectFactory.ToString());
                Console.WriteLine("PostProcessAfterInitialization方法，我在初始化方法后执行，instance值为{0},objectName值为{1}", instance, objectName);
            }
            
            return instance;
        }

        public object PostProcessBeforeInitialization(object instance, string name)
        {
            if (name == "postInject" || name == "postInjectB")
            {
                Console.WriteLine("PostProcessBeforeInitialization方法，我在初始化方法前执行，instance值为{0},name值为{1}", instance, name);
            }
            
            return instance;
        }

        public bool PostProcessAfterInstantiation(object objectInstance, string objectName)
        {
            if (objectName == "postInject" || objectName == "postInjectB")
            {
                Console.WriteLine("PostProcessAfterInstantiation方法，我在创建对象后执行，objectInstance值为{0},objectName值为{1}", objectInstance, objectName);
            }
            
            return true;
        }

        public object PostProcessBeforeInstantiation(Type objectType, string objectName)
        {
            if (objectName == "postInject")
            {
                Console.WriteLine("PostProcessBeforeInstantiation方法，我在创建对象前执行，objectType值为{0},objectName值为{1}", objectType, objectName);
                //return this.objectFactory.GetObject<IWrite>("postInjectB");
                return null;
            }
            return null;
        }

        public Spring.Objects.IPropertyValues PostProcessPropertyValues(Spring.Objects.IPropertyValues pvs, IList<System.Reflection.PropertyInfo> pis, object objectInstance, string objectName)
        {
            if (objectName == "postInject" || objectName == "postInjectB")
            {
                Console.WriteLine("PostProcessPropertyValues方法，pvs值为{0},pis值为{1}，objectInstance值为{2},objectName值为{3}", pvs, pis, objectInstance, objectName);
            }
            
            return pvs;
        }

        public void PostProcessBeforeDestruction(object instance, string name)
        {
            if (name == "postInject" || name == "postInjectB")
            {
                Console.WriteLine("PostProcessBeforeDestruction方法，我在销毁前执行，instance值为{0},name值为{1}", instance, name);
            }
            
        }

        public IObjectFactory ObjectFactory
        {
            set
            {
                objectFactory = value;
            }
        }
    }
}
