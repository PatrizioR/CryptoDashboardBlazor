using Microsoft.AspNetCore.Components;

namespace CryptoDashboardBlazor.Client.Components.SvgAnimations
{
    public partial class AuthenticateUSelf
    {
        [Parameter]
        public string Class { get; set; } = null!;

        [Parameter]
        public string Id { get; set; } = null!;
    }
}