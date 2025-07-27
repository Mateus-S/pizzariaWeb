using Microsoft.AspNetCore.Components;
using Pizzaria.Shared.DTOs.MenuItem;
using Pizzaria.Shared.DTOs.Product;
using Pizzaria.WEB.Services.Interfaces;

namespace Pizzaria.WEB.Pages.Admin
{
    public partial class MenuItemManager
    {
        [Inject]
        public IMenuItemService? MenuItemService { get; set; }

        private List<MenuItemDto> menuItems = new();
        private bool isLoading = true;
        private bool showForm = false;
        private bool isEditMode = false;

        private CreateMenuItemDto? createModel;
        private UpdateMenuItemDto? updateModel;

        protected override async Task OnInitializedAsync()
        {
            await LoadMenuItemsAsync();
        }

        private async Task LoadMenuItemsAsync()
        {
            isLoading = true;
            menuItems = await MenuItemService!.GetAllAsync();
            isLoading = false;
        }

        private void CreateNewItem()
        {
            createModel = new CreateMenuItemDto();
            updateModel = null;
            isEditMode = false;
            showForm = true;
        }

        private void OpenEditForm(MenuItemDto item)
        {
            updateModel = new UpdateMenuItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Category = item.CategoryName
            };

            createModel = null;
            isEditMode = true;
            showForm = true;
        }

        private async Task ToggleItemStatus(MenuItemDto item)
        {
            await MenuItemService!.ToggleStatusAsync(item.Id);
            await LoadMenuItemsAsync();
        }

        private async Task OnSaved()
        {
            showForm = false;
            await LoadMenuItemsAsync();
        }

        private Task OnCancel()
        {
            showForm = false;
            return Task.CompletedTask;
        }
    }
}