using System.Windows.Input;
using TodoList.Models;

namespace TodoList.CustomControl;

public partial class Card : ContentView
{
    public Card()
    {
        InitializeComponent();
        var sync = BindingContext;
    }
    private static BindableProperty TodoProperty = BindableProperty.Create(
        nameof(Todo),
        typeof(TodoItem),
        typeof(Card));
    public TodoItem Todo
    {
        get => (TodoItem)GetValue(TodoProperty);
        set => SetValue(TodoProperty, value);
    }
    private static BindableProperty MarkCommandProperty = BindableProperty.Create(
        nameof(MarkCommand),
        typeof(ICommand),
        typeof(Card));
    public ICommand MarkCommand
    {
        get => (ICommand)GetValue(MarkCommandProperty);
        set => SetValue(MarkCommandProperty, value);
    }
    private static BindableProperty DeleteCommandProperty = BindableProperty.Create(
        nameof(DeleteCommand),
        typeof(ICommand),
        typeof(Card), defaultBindingMode: BindingMode.TwoWay, defaultValue: null);
    public ICommand DeleteCommand
        {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }
    public static BindableProperty EditCommandProperty = BindableProperty.Create(
        nameof(EditCommand),
        typeof(ICommand),
        typeof(Card));
    public ICommand EditCommand
        {
        get => (ICommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }
}