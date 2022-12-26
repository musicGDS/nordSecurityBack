using System.Net;

namespace API.DataModels;

public class GetUserCredentials
{
    public UserCredentialsResponseBody UserCredentialsResponseBody { get; set; }
    public HttpStatusCode StatusCode { get; set; }
}