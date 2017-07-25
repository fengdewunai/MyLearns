using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface IRestTest
    {
        [OperationContract]
        [WebGet(UriTemplate = "Get/{id}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Student Get(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Add", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Add(Student stu);
    }
}
