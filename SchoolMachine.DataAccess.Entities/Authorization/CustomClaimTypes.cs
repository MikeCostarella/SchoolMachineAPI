namespace SchoolMachine.DataAccess.Entities.Authorization
{
    using System.ComponentModel;

    public enum CustomClaimTypes
    {
        [Description("https://schema.latvianvillage.com/identity/claims/admin")]
        Admin,
        [Description("https://schema.latvianvillage.com/identity/claims/publicuser")]
        PublicUser
    }
}