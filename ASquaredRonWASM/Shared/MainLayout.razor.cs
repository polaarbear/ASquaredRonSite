namespace ASquaredRonWASM.Shared
{
    public partial class MainLayout
    {
        private NavDrawer? _NavDrawer { get; set; }
        private bool DarkMode { get; set; } = true;

        public void ToggleNavDrawer()
        {
            _NavDrawer!.ToggleNav();
        }

        public void ToggleDarkMode()
        {
            DarkMode = !DarkMode;
        }
    }
}