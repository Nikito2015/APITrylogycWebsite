using log4net;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Web;

namespace WcfTrylogycWebsite.BaseClasses
{

    /// <summary>
    /// Base Service Class
    /// </summary>
    public class BaseService
    {

        #region Private Members
        public static HttpContext _httpContext;
        public static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        public BaseService()
        {
            _log.Info("BaseService Comienzo...");
            _httpContext = HttpContext.Current;
            RngCryptoServiceProvider = (RNGCryptoServiceProvider)_httpContext.Application["RNGCSP"];
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the RNG crypto service provider.
        /// </summary>
        /// <value>
        /// The RNG crypto service provider.
        /// </value>
        protected RNGCryptoServiceProvider RngCryptoServiceProvider { get; private set; }

        #endregion

    }
}