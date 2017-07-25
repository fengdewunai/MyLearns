using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFLearn
{
    using System.ServiceModel.Description;

    public class MyEndPointBehavior : IEndpointBehavior  
    {

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            return;
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            // 植入“偷听器”客户端  
            clientRuntime.ClientMessageInspectors.Add(new MyMessageInspector());  
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            // 植入“偷听器” 服务器端  
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MyMessageInspector());  
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            return;  
        }
    }
}
