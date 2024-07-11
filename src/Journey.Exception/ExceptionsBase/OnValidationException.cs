using System.Net;

namespace Journey.Exception.ExceptionsBase
{
    public class OnValidationException(IList<string> errors) : JourneyException(string.Empty)
    {
        private IList<string> _errors = errors;
        public override IList<string> GetErrorMessages()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
