using Microsoft.AspNetCore.Components;

namespace ASquaredRonWASM.Shared
{
    public partial class HeaderBar
    {
        [Parameter]
        public EventCallback ToggleDarkMode { get; set; }

        private void DarkModeToggle()
        {
            ToggleDarkMode.InvokeAsync();
        }
    }
}
