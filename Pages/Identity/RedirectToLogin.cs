using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace MudBlazorServerId.Pages.Identity
{

//    @attribute[IgnoreAntiforgeryToken]

    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager navManager { get; set; }
        protected SignInManager<IdentityUser> signInManager { get; set; }

        protected override async void OnInitialized()
        {
            // TODO really should make sure the user is logged out here
//            if (signInManager.IsSignedIn(User))
//            {
                await signInManager.SignOutAsync();
//            }

            navManager.NavigateTo("/login", true);
        }

    }
}
