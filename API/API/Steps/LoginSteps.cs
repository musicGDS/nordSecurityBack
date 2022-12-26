using System.Net;
using System.Net.Http.Headers;
using API.Actions;
using API.DataModels;
using FluentAssertions;
using RestSharp;

namespace API.Steps;

[Binding]
public class LoginSteps
{
    private UserCredentialsResponseBody _userCredentials;
    private HttpStatusCode _currentStatusCode;
    private APIClient _apiClient;

    public LoginSteps()
    {
        _apiClient = new(new RestClient("http://ptsv2.com/"));
    }
        
    [When(@"User retrieves credentials")]
    public void WhenUserRetrievesCredentials()
    {
        var userCredentials = _apiClient.GetUserCredentials();
        _userCredentials = userCredentials.UserCredentialsResponseBody;
        _currentStatusCode = userCredentials.StatusCode;
    }

    [Then(@"response should contain credentials")]
    public void ThenResponseShouldContainCredentials()
    {
        _userCredentials.Username.Should().NotBeNull();
        _userCredentials.Password.Should().NotBeNull();
        _userCredentials.TargetUrl.Should().NotBeNull();
    }

    [When(@"User tries to login")]
    public void WhenUserTriesToLogin()
    {
        var loginResponse = _apiClient.PostLoginInformation(_userCredentials);
        _currentStatusCode = loginResponse.StatusCode;
    }

    [Then(@"response code should be OK")]
    public void ThenResponseCodeShouldBeOk()
    {
        _currentStatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Given(@"wrong user credentials")]
    public void GivenWrongUserCredentials()
    {
        _userCredentials = new()
        {
            Username = "NonValid",
            Password = "NonValid",
            TargetUrl = "?"
        };
    }

    [Then(@"the response code should be Unautohorized")]
    public void ThenTheResponseCodeShouldBeUnautohorized()
    {
        _currentStatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}