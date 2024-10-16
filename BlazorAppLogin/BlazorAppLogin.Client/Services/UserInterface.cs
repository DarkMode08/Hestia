using BlazorApp.Share;

namespace BlazorAppLogin.Client.Services
{
    public interface UserInterface
    {
        Task<List<_UserViewModels>> _List();
    }
}
