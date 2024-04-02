namespace SayyehBanTools.AccessDenied;

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
