using MudBlazor;

namespace ASquaredRonWASM.Themes
{
    public static class ThemeManager
    {
        public static MudTheme PrimaryTheme { get; private set; } =
            new MudTheme()
            {
                Palette = new Palette()
                {
                    Primary = Colors.DeepOrange.Default,
                    Secondary = Colors.Blue.Default,
                    Tertiary = Colors.Green.Default,
                    AppbarBackground = Colors.DeepOrange.Default,

                },
                PaletteDark = new Palette()
                {
                    Primary = Colors.DeepOrange.Default,
                    Secondary = Colors.Blue.Default,
                    Tertiary = Colors.Green.Default,
                    Background = CustomColors.Black.Default,
                    AppbarBackground = CustomColors.Black.Darken,
                    Surface = CustomColors.Black.Lighten,
                    TextPrimary = CustomColors.White.Default,
                    TextSecondary = CustomColors.White.Default
                }
            };
    }
}
