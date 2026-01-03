using Microsoft.AspNetCore.Components;

namespace Pizzaria.WEB.Shared.Components
{
    public partial class ErrorModal
    {
        [Parameter] public string ErrorMessage { get; set; } = "Algo deu errado.";
        [Parameter] public EventCallback OnClose { get; set; }

        private bool IsVisible { get; set; }

        public void Show(string message)
        {
            ErrorMessage = message;
            IsVisible = true;
            StateHasChanged();
        }

        public void Hide()
        {
            IsVisible = false;
            OnClose.InvokeAsync();
        }
    }
}