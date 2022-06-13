namespace ASquaredRonWASM.Shared
{
    public partial class MainLayout
    {
        public bool DarkMode { get; private set; } = true;

        protected override void OnInitialized()
        {
            StateHasChanged();
        }

        public void ToggleDarkMode()
        {
            DarkMode = !DarkMode;
        }
    }
}