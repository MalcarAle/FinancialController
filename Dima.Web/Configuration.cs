using MudBlazor.Utilities;
using MudBlazor;

namespace Dima.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "ControlFinance";
        public static string BackendUrl { get; set; } = "http://localhost:5105";

        public static MudTheme Theme = new()
        {
            Typography = new Typography
            {
                Default = new Default()
                {
                    FontFamily = ["Raleway", "sans-serif"]
                }
            },
            Palette = new PaletteLight
            {
                Primary = "#2687e9",
                Secondary = Colors.LightBlue.Darken3,
                Background = Colors.Grey.Lighten4,
                AppbarBackground = new MudColor("#2687e9"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                PrimaryContrastText = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = Colors.LightBlue.Lighten4

            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.LightBlue.Accent3,
                Secondary = Colors.LightBlue.Darken3,
                AppbarBackground = Colors.LightBlue.Accent3,
                AppbarText = Colors.Shades.Black
            }
        };
    }
}
