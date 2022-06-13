using Microsoft.AspNetCore.Components;

namespace ASquaredRonWASM.Shared
{
    public partial class HeaderBar
    {
        [Parameter]
        public EventCallback ToggleNavDrawer { get; set; }

        [Parameter]
        public EventCallback ToggleDarkMode { get; set; }

        private void NavDrawerToggle()
        {
            ToggleNavDrawer.InvokeAsync();
        }

        private void DarkModeToggle()
        {
            ToggleDarkMode.InvokeAsync();
        }
    }
}
