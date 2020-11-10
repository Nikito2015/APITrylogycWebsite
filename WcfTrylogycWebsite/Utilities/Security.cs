using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WcfTrylogycWebsite.Utilities
{

    /// <summary>
    /// Utility static class for security concerns
    /// </summary>
    public static class Security
    {

        /// <summary>
        /// Gets the session identifier.
        /// </summary>
        /// <param name="rngCsp">The RNG CSP.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string GetSessionID(RNGCryptoServiceProvider rngCsp, int length)
        {
            Byte[] sessionID = new Byte[length];
            rngCsp.GetBytes(sessionID);
            return HttpUtility.UrlEncode(Convert.ToBase64String(sessionID));
        }

    }
}