namespace WcfTrylogycWebsite.ServiceRequests.Interfaces
{
    public interface IUserAssociatesAndBalancesRequest
    {
        int UserId { get; set; }

        bool IsValid();
    }
}