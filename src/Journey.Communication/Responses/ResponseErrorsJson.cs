namespace Journey.Communication.Responses
{
    public class ResponseErrorsJson(IList<string> errors)
    {
        public IList<string> Errors { get; set; } = errors;

        
    }
}
