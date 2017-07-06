
namespace WCFLearn
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        string GetLength(string name);

        [OperationContract]
        Message TestMessage(Message message);
    }
}
