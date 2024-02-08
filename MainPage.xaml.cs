namespace Invoice_System;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();
    }

    private void BTN_Clicked(object sender, EventArgs e)
    {
        Output.Text += Input.Text + "\n"; //Text co je v Input bude i v Output
        Input.Text = string.Empty; //Text z Input to smaže -> efekt "přesunu"
    }
}

