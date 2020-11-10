using System.ServiceModel;
using System.ServiceModel.Web;
using WcfTrylogycWebsite.ServiceRequests;
using WcfTrylogycWebsite.ServiceResponses;

namespace WcfTrylogycWebsite
{

    /// <summary>
    /// Interface for the Service
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        InvoicePdfResponse GetInvoicePdf(InvoicePdfRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        RegisterResponse Register(RegisterRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        AddRelationResponse AddRelation(AddRelationRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UserAssociatesResponse GetUserAssociates(UserAssociatesAndBalancesRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        UserBalancesResponse GetUserBalances(UserAssociatesAndBalancesRequest request);

    }

}
