
namespace WCFLearn
{
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    [ServiceContract]
    public interface IHomeService
    {
        [OperationContract]
        string GetLength(string name);

        [OperationContract]
        void GetDataContract(DateTest dateTest);

        [OperationContract]
        Message TestMessage(Message message);

        [OperationContract]
        ResponseMessage PostMessageContract(CarMessage msg);

        [OperationContract]
        void UploadFile(Stream fileStream);

        [OperationContract]
        void UploadFileWithMessageContract(TransferFileMessage msg);
    }
}
