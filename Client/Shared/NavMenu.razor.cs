using System.Globalization;
using Microsoft.JSInterop;

namespace CryptoDashboardBlazor.Client.Shared
{
    public partial class NavMenu
    {
        private readonly CultureInfo[] supportedCultures = new[]
        {
            new CultureInfo("en-GB"),
            new CultureInfo("de-DE"),
        };

        private CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    switch (JSRuntime)
                    {
                        case IJSInProcessRuntime jsClient:
                            jsClient.InvokeVoid("blazorCulture.set", value.Name);
                            Nav.NavigateTo(Nav.Uri, forceLoad: true);
                            break;

                        case IJSRuntime jsServer:
#pragma warning disable CA2012 // Use ValueTasks correctly
                            jsServer.InvokeVoidAsync("blazorCulture.set", value.Name);
#pragma warning restore CA2012 // Use ValueTasks correctly
                            Nav.NavigateTo(Nav.Uri, forceLoad: true);
                            break;

                        default:
                            CultureInfo.CurrentCulture = value;
                            StateHasChanged();
                            break;
                    }
                }
            }
        }
    }
}