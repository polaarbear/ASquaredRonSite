using Microsoft.AspNetCore.Components;

namespace ASquaredRonWASM.Shared
{
    public partial class NavDrawer
    {
        public bool _IsOpen { get; set; } = false;

        public void ToggleNav()
        {
            _IsOpen = !_IsOpen;
            StateHasChanged();
        }
    }
}
