using Microsoft.AspNetCore.Components;
using Pizzaria.Shared.DTOs.MenuItem;

namespace Pizzaria.WEB.Components.MenuItems
{
    public partial class MenuItemRow
    {
        [Parameter] public MenuItemDto Item { get; set; } = default!;
        [Parameter] public EventCallback<MenuItemDto> OnEdit { get; set; }
        [Parameter] public EventCallback<MenuItemDto> OnToggleStatus { get; set; }
    }
}