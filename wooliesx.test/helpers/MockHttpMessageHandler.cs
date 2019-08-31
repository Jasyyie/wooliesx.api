using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly string _response;
    private readonly HttpStatusCode _statusCode;

    public string Input { get; private set; }
    public int NumberOfCalls { get; private set; }

    public MockHttpMessageHandler(string response, HttpStatusCode statusCode)
    {
        _response = response;
        _statusCode = statusCode;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        NumberOfCalls++;
        //Input = await request.Content.ReadAsStringAsync();
        return new HttpResponseMessage
        {
            StatusCode = _statusCode,
            Content = new StringContent(_response)
        };
    }


}