using Microsoft.AspNetCore.Components;
using Pizzaria.Shared.DTOs.Product;
using Pizzaria.WEB.Services.Interfaces;

namespace Pizzaria.WEB.Components.MenuItems
{
    public class MenuItemFormBase : ComponentBase
    {
        [Parameter] public bool IsEditMode { get; set; }

        [Parameter] public CreateMenuItemDto? CreateModel { get; set; }
        [Parameter] public UpdateMenuItemDto? UpdateModel { get; set; }

        [Parameter] public EventCallback OnSaved { get; set; }
        [Parameter] public EventCallback OnCancel { get; set; }

        [Inject] protected IMenuItemService MenuItemService { get; set; } = default!;

        protected async Task HandleValidSubmit()
        {
            if (IsEditMode && UpdateModel is not null)
            {
                await MenuItemService.UpdateAsync(UpdateModel);
            }
            else if (!IsEditMode && CreateModel is not null)
            {
                await MenuItemService.CreateAsync(CreateModel);
            }

            await OnSaved.InvokeAsync();
        }
    }
}
