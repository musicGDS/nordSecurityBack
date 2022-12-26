using System.Net;
using API.DataModels;
using RestSharp;
using RestSharp.Authenticators;

namespace API.Actions;

public class APIClient
{
    private RestClient _client;

    public APIClient(RestClient client)
    {
        _client = client;
    }

    public GetUserCredentials GetUserCredentials()
    {
        var _request = new RestRequest($"t/fu807-1554722621/post");
        _request.Method = Method.Get;
        var response = _client.ExecuteAsync<UserCredentialsResponseBody>(_request).Result;
        return new GetUserCredentials()
        {
            UserCredentialsResponseBody = response.Data,
            StatusCode = response.StatusCode
        };
    }

    public PostLogin PostLoginInformation(UserCredentialsResponseBody userCredentials)
    {
        var _request = new RestRequest(userCredentials.TargetUrl);
        //Despite it is obsolete I need this functionality here because I do not know user name and password
        //When I create Rest Client
        _client.Authenticator = new HttpBasicAuthenticator(userCredentials.Username, userCredentials.Password);
        _request.Method = Method.Post;
        var response = _client.ExecuteAsync(_request).Result;
        return new PostLogin()
        {
            StatusCode = response.StatusCode
        };
    }
}