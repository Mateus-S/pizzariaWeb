using Microsoft.AspNetCore.Components;
using Pizzaria.Shared.DTOs.MenuItem;

namespace Pizzaria.WEB.Components.MenuItems
{
    public partial class MenuItemList
    {
        [Parameter] public List<MenuItemDto> Items { get; set; } = new();
        [Parameter] public EventCallback<MenuItemDto> OnEdit { get; set; }
        [Parameter] public EventCallback<MenuItemDto> OnToggleStatus { get; set; }
    }
}