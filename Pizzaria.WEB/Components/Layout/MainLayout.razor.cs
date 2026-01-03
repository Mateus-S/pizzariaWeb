using Microsoft.AspNetCore.Components;
using Pizzaria.WEB.Services.Interfaces;
using Pizzaria.WEB.Shared.Components;

namespace Pizzaria.WEB.Components.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        private ErrorModal? _errorModal;

        [Inject]
        private IErroHandleService ErrorHandler { get; set; } = default!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender && _errorModal is not null)
            {
                ErrorHandler.RegisterModal(_errorModal);
                StateHasChanged(); // opcional
            }
        }
    }
}
