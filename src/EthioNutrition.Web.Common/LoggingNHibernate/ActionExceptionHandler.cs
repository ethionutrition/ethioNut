using EthioNutrition.Common;
using log4net;
using System;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;

namespace EthioNutrition.Web.Common.LoggingNHibernate
{
    public class ActionExceptionHandler: IActionExceptionHandler
    {
        public const int MaxStatusDescriptionLength = 512;
        private readonly ILog _logger;
        private readonly IExceptionMessageFormatter _exceptionMessageFormatter;

        public bool ExceptionHandled { get; private set; }

        public ActionExceptionHandler(ILog logger, IExceptionMessageFormatter exceptionMessageFormatter)
        {
            _logger = logger;
            _exceptionMessageFormatter = exceptionMessageFormatter;
        }

        /************** Handling the exception ********************/
        public void HandleException(HttpActionExecutedContext filterContext)
        {
            var exception = filterContext.Exception;
            if (exception == null) return;
            
            ExceptionHandled = true;

            _logger.Error("Exception occured: ", exception);

            var reasonPhrase = _exceptionMessageFormatter.GetEntireExceptionStack(exception);
            if(reasonPhrase.Length > MaxStatusDescriptionLength)
            {
                reasonPhrase = reasonPhrase.Substring(0, MaxStatusDescriptionLength);
            }
            
            reasonPhrase = reasonPhrase.Replace(Environment.NewLine, " ");

            filterContext.Response = new HttpResponseMessage
            {
                StatusCode= HttpStatusCode.InternalServerError,
                ReasonPhrase= reasonPhrase
            };
        }
    }
}
