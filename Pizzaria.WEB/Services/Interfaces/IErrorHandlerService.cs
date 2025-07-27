using Pizzaria.WEB.Shared.Components;

namespace Pizzaria.WEB.Services.Interfaces
{
    public interface IErroHandleService
    {
        /// <summary>
        /// Registra a instância do modal que será exibido globalmente.
        /// </summary>
        void RegisterModal(ErrorModal modal);

        /// <summary>
        /// Exibe o modal de erro com título e mensagem.
        /// </summary>
        Task ShowAsync(string title, string message);
    }
}
