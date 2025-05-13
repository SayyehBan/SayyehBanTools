/// <summary>
/// دسترسی به سیستم
/// </summary>
public static class IPAccess
{
    /// <summary>
    /// بررسی شروع و پایان 
    /// IP
    /// </summary>
    /// <param name="ipAddress"></param>
    /// <param name="rangeStart"></param>
    /// <param name="rangeEnd"></param>
    /// <returns></returns>
    public static bool IsInRange(string ipAddress, string rangeStart, string rangeEnd)
    {
        // Split the IP address and range into parts.
        string[] ipParts = ipAddress.Split('.');
        string[] rangeStartParts = rangeStart.Split('.');
        string[] rangeEndParts = rangeEnd.Split('.');

        // Check each part of the IP address.
        for (int i = 0; i < 4; i++)
        {
            // If the IP part is less than the range start part, the IP is not in range.
            if (int.Parse(ipParts[i]) < int.Parse(rangeStartParts[i]))
            {
                return false;
            }

            // If the IP part is greater than the range end part, the IP is not in range.
            if (int.Parse(ipParts[i]) > int.Parse(rangeEndParts[i]))
            {
                return false;
            }
        }

        // The IP address is in range.
        return true;
    }
}
/*
 طریقه استفاده از دستور
using SayyehBanTools.AccessDenied;
using SayyehBanTools.Converter;

namespace SafeIPList.Models
{
    public class IpRestrictionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _allowedIps;

        public IpRestrictionMiddleware(RequestDelegate next)
        {
            _next = next;

            string filePath = "wwwroot/file/IpIran.txt";
            _allowedIps = File.ReadAllLines(filePath);
        }

        public async Task Invoke(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress.ToString();
            if (_allowedIps.Any(allowedIp => IPAccess.IsInRange(StringExtensions.AnonymousIP(ipAddress), allowedIp.Split(',')[0], allowedIp.Split(',')[1])))
            {
                await _next(context);
            }
            else
            {
                // The IP address is not allowed.
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Access Denied " + ipAddress);
                return;
            }
        }

    }


    public static class IpRestrictionMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpRestrictionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpRestrictionMiddleware>();
        }
    }
}

 */