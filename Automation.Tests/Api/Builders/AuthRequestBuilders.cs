using Automation.Tests.Api.Models;

namespace Automation.Tests.Api.Builders;

public class AuthRequestBuilder
{
    private string _username = "admin";
    private string _password = "password123";

    public AuthRequestBuilder WithInvalidUsername()
    {
        _username = "superadmin";
        return this;
    }

    public AuthRequestBuilder WithInvalidPassword()
    {
        _password = "wrong-pass";
        return this;
    }

    public AuthRequest Build()
    {
        return new AuthRequest { Username = _username, Password = _password };
    }
}
