namespace EasyPTC.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using EasyPTC.Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? ImageId { get; set; }

        public virtual Image Image { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}