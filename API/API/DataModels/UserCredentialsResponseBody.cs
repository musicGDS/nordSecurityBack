namespace API.DataModels;

public class UserCredentialsResponseBody
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string TargetUrl { get; set; }
}