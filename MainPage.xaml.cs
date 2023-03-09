using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{

    bool isRandom = false;
    private string hexValue;
    public MainPage()
    {
        InitializeComponent();
    }


    private void Sld_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRandom)
        {
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColor(color);
        }

    }


    private void SetColor(Color color)
    {
        Container.BackgroundColor = color;
        btnRandom.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
    }
    private void Random_OnClicked(object sender, EventArgs e)
    {
        isRandom = true;
        Random random = new Random();
        var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 255));
        sldRed.Value = color.Red;
        sldGreen.Value = color.Green;
        sldBlue.Value = color.Blue;
        SetColor(color);
        isRandom = false;
    }

    private async void ImageButton_OnClicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color Copy", CommunityToolkit.Maui.Core.ToastDuration.Short, 13);
        await toast.Show();
    }
}

