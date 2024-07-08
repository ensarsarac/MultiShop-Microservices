namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IClientCredentialsTokenService
    {
        Task<string> GetToken();

    }
}
