using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;
using Pizzaria.WEB.Services.Interfaces;
using System.Net.Http.Json;

namespace Pizzaria.WEB.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly HttpClient _http;
        private readonly IErroHandleService _errorModal;

        public MenuItemService(HttpClient http, IErroHandleService errorModal)
        {
            _http = http;
            _errorModal = errorModal;
        }

        public async Task<List<MenuItemDto>> GetAllAsync()
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<MenuItemDto>>("/api/menuitems");
                return response ?? new List<MenuItemDto>();
            }
            catch (Exception ex)
            {
                await _errorModal.ShowAsync("Erro ao carregar itens", ex.Message);
                return new List<MenuItemDto>();
            }
        }

        public async Task<bool> CreateAsync(CreateMenuItemDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("/api/menuitems", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await _errorModal.ShowAsync("Erro ao criar item", error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await _errorModal.ShowAsync("Erro ao criar item", ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UpdateMenuItemDto dto)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"/api/menuitems/{dto.Id}", dto);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await _errorModal.ShowAsync("Erro ao atualizar item", error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await _errorModal.ShowAsync("Erro ao atualizar item", ex.Message);
                return false;
            }
        }

        public async Task<bool> ToggleStatusAsync(Guid id)
        {
            try
            {
                var response = await _http.PatchAsync($"/api/menuitems/{id}/status", null);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    await _errorModal.ShowAsync("Erro ao alterar status", error);
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await _errorModal.ShowAsync("Erro ao alterar status", ex.Message);
                return false;
            }
        }
    }
}
