using Pizzaria.WEB.Services.Interfaces;
using Pizzaria.WEB.Shared.Components;

namespace Pizzaria.WEB.Services.ErrorsServices
{
    public class ErrorHandlerService : IErroHandleService
    {
        private ErrorModal? _modal;

        public void RegisterModal(ErrorModal modal) => _modal = modal;

        public async Task ShowAsync(string title, string message)
        {
            _modal?.Show(message);
            await Task.CompletedTask;
        }

    }
}
