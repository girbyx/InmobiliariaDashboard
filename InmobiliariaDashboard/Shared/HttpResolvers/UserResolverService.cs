using Microsoft.AspNetCore.Http;

namespace InmobiliariaDashboard.Shared.HttpResolvers
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetCurrentUserName()
        {
            return _context.HttpContext.User?.Identity?.Name;
        }
    }
}
