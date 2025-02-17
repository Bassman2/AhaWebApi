namespace AVMHomeAutomationTest;

public class ExpectedHttpRequestExceptionAttribute : ExpectedExceptionBaseAttribute
{
    public HttpStatusCode? StatusCode { get; }

    public ExpectedHttpRequestExceptionAttribute(HttpStatusCode statusCode)
    {
        this.StatusCode = statusCode;
    }

    //public Type ExceptionType { get; }

    protected override void Verify(Exception ex)
    {
        if (ex is AggregateException && ex.InnerException is not null)
        {
            ex = ex.InnerException;
        }
        if (ex is HttpRequestException exception && exception.StatusCode == this.StatusCode)
        {
            return;
        }

        RethrowIfAssertException(ex);
        throw new Exception($"Test method threw exception {ex.GetType().FullName} {(ex as HttpRequestException)?.StatusCode}, but exception System.Net.Http.HttpRequestException with StatusCode {StatusCode} was expected. Exception message: {ex.Message}.");
    }
}
