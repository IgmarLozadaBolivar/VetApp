namespace API.Models;

public class RefreshTokenResponse
{
    public string Token { get; set; }
    public bool Result { get; set; }
    public string Msg { get; set; }
}