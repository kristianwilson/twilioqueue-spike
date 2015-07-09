using CallCentre.Core.Interfaces;

namespace CallCentre.Infrastructure
{
    public class AccountSettings : IAccountSettings
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
    }
}
