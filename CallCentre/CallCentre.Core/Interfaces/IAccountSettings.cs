namespace CallCentre.Core.Interfaces
{
    public interface IAccountSettings
    {
        string AccountSid { get; set; }
        string AuthToken { get; set; }
    }
}
