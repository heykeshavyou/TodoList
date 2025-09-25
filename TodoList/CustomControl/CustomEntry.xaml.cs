namespace TodoList.CustomControl;

public partial class CustomEntry : ContentView
{
    public CustomEntry()
    {
        InitializeComponent();
    }
    public static readonly BindableProperty EntryTextProperty =
        BindableProperty.Create(nameof(EntryText), typeof(string), typeof(CustomEntry), string.Empty, BindingMode.TwoWay);

    public static readonly BindableProperty LabelTextProperty =
        BindableProperty.Create(nameof(LabelText), typeof(string), typeof(CustomEntry), string.Empty, BindingMode.TwoWay);
    public string EntryText
    {
        get => (string)GetValue(EntryTextProperty);
        set => SetValue(EntryTextProperty, value);
    }
    public string LabelText
    {
        get => (string)GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        EntryField.Focus();
    }
}