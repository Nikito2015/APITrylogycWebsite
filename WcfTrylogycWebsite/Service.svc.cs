using BLLTrylogycWebsite.Enums;
using BLLTrylogycWebsite.Models;
using BLLTrylogycWebsite.Models.Interfaces;
using CommonTrylogycWebsite.DTO.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using WcfTrylogycWebsite.BaseClasses;
using WcfTrylogycWebsite.Models;
using WcfTrylogycWebsite.ServiceRequests;
using WcfTrylogycWebsite.ServiceRequests.Interfaces;
using WcfTrylogycWebsite.ServiceResponses;
using WcfTrylogycWebsite.ServiceResponses.Interfaces;
using WcfTrylogycWebsite.Utilities;

namespace WcfTrylogycWebsite
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.    

    /// <summary>
    /// Service class
    /// </summary>
    /// <seealso cref="WcfPagosMPago.BaseClasses.BaseService" />
    /// <seealso cref="WcfTrylogycWebsite.IService" />
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : BaseService, IService
    {

        #region Private Members
        private string _connString;
        private static string _serviceToken;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            _log.Info("Mobile() Comienzo...");
            try
            {
                _log.Info("Recuperando cadena de conexión.");
                _connString = ConfigurationManager.ConnectionStrings["appConn"].ToString();
                _log.Info("Seteando token de servicio.");
                _serviceToken = (string.IsNullOrEmpty(_serviceToken)) ? Security.GetSessionID(RngCryptoServiceProvider, 8) : _serviceToken;
                _log.Info($"Seteando Token a valor {_serviceToken}.");

            }
            catch (Exception ex)
            {
                _log.Error($"There was an error while initializing the service {ex.Message}");
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns></returns>
        public LoginResponse Login(LoginRequest request)
        {
            _log.Info("Login() Comienzo...");
            var response = new LoginResponse();

            if (!request.IsValid())
                return (LoginResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            try
            {
                IBLLUser bllUser = new BLLUser(_log, _connString);
                var bllResponse = bllUser.Login(request.Email, request.Password, true);
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.User = WcfUser.CreateFromDTO(bllResponse.DTOResult);
                    response.SetSuccessResponse(null);
                    response.Token = _serviceToken;
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }

            }
            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("Login() Fin...");
            }
            return response;
        }

        /// <summary>
        /// Gets the invoice PDF.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public InvoicePdfResponse GetInvoicePdf(InvoicePdfRequest request)
        {
            _log.Info("GetInvoicePdf() Comienzo...");
            var response = new InvoicePdfResponse();

            if (!request.IsValid())
                return (InvoicePdfResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            if (request.Token.Trim() != _serviceToken)
                return (InvoicePdfResponse)response.SetErrorResponse("No autenticado");
            try
            {
                _log.Info("Inicializando BLL User.");
                IBLLUser bllUser = new BLLUser(_log, _connString);
                _log.Info("Recuperando Pdf como array de bytes.");
                var bllResponse = bllUser.GetInvoicePdf(request.AssociateId, request.ConnectionId, request.InvoiceNumber, request.RetrieveFromFTP);
                _log.Info($"Respuesta de la capa de negocios: {bllResponse?.Status.ToString()}. Mensaje {bllResponse?.Message}");
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.InvoicePdf = bllResponse.DTOResult;
                    response.SetSuccessResponse(null);
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }

            }
            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("GetInvoicePdf() Fin...");
            }


            return response;

        }

        /// <summary>
        /// Registers the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RegisterResponse Register(RegisterRequest request)
        {
            _log.Info("GetInvoicePdf() Comienzo...");
            var response = new RegisterResponse();

            if (!request.IsValid())
                return (RegisterResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            try
            {
                _log.Info("Inicializando BLL User.");
                IBLLUser bllUser = new BLLUser(_log, _connString);
                _log.Info($"Registrando usuario {request.Email}.");
                var bllResponse = bllUser.Register(request.Email, request.EmailConfirm, request.Code, request.CGP, request.EmailInvoices);
                _log.Info($"Respuesta de la capa de negocios: {bllResponse?.Status.ToString()}. Mensaje {bllResponse?.Message}");
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.SetSuccessResponse(bllResponse.Message);
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }

            }
            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("Register() Fin...");
            }

            return response;
        }

        /// <summary>
        /// Adds the relation.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AddRelationResponse AddRelation(AddRelationRequest request)
        {
            _log.Info("AddRelation() Comienzo...");
            var response = new AddRelationResponse();

            if (!request.IsValid())
                return (AddRelationResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            if (request.Token != _serviceToken)
                return (AddRelationResponse)response.SetErrorResponse("No autenticado");

            try
            {
                _log.Info("Inicializando BLL User.");
                IBLLUser bllUser = new BLLUser(_log, _connString);
                _log.Info($"Registrando Relación.");
                var bllResponse = bllUser.AddRelation(request.UserId, request.AssociateCode, request.CGP);
                _log.Info($"Respuesta de la capa de negocios: {bllResponse?.Status.ToString()}. Mensaje {bllResponse?.Message}");
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.SetSuccessResponse(bllResponse.Message);
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }
            }

            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("AddRelation() Fin...");
            }

            return response;
        }

        /// <summary>
        /// Gets the user associates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public UserAssociatesResponse GetUserAssociates(UserAssociatesAndBalancesRequest request)
        {
            _log.Info("GetUserAssociates() Comienzo...");
            var response = new UserAssociatesResponse();

            if (!request.IsValid())
                return (UserAssociatesResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            try
            {
                IBLLUser bllUser = new BLLUser(_log, _connString);
                var bllResponse = bllUser.GetUserAssociates(request.UserId);
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.Associates = WcfAssociate.CreateAssociatesCollectionFromDTO(bllResponse.DTOResult);
                    response.SetSuccessResponse(null);
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }

            }
            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("Login() Fin...");
            }
            return response;
        }

        /// <summary>
        /// Gets the user associates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public UserBalancesResponse GetUserBalances(UserAssociatesAndBalancesRequest request)
        {
            _log.Info("GetUserBalances() Comienzo...");
            var response = new UserBalancesResponse();

            if (!request.IsValid())
                return (UserBalancesResponse)response.SetBadRequestResponse("Los datos proporcionados no son válidos.");

            try
            {
                IBLLUser bllUser = new BLLUser(_log, _connString);
                var bllResponse = bllUser.GetUserBalances(request.UserId);
                if (bllResponse.Status.Equals(Status.Success))
                {
                    response.Balances = WcfBalance.CreateBalancesCollectionFromDTO(bllResponse.DTOResult);
                    response.SetSuccessResponse(null);
                }
                else
                {
                    response.SetBadRequestResponse(bllResponse.Message);
                }

            }
            catch (Exception ex)
            {
                _log.Error($"Ocurrieron errores: {ex}");
                response.SetErrorResponse(ex.Message);
            }

            finally
            {
                _log.Info("Login() Fin...");
            }
            return response;
        }

        #endregion
    }
}