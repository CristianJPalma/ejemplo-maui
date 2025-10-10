using MauiApp1.SQLite;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	private readonly HabitosDataBase _data;


	public MainPage(HabitosDataBase data)
	{
		InitializeComponent();
		_data = data;
		CargarHabitos();
	}

	async void CargarHabitos() 
	{
		var list = await _data.GetHabitosAsync();
        //myLayout.ItemsSource = list;
    }

	async void OnCounterClicked(object sender, EventArgs e)
	{
		string texto = input.Text;
        if (string.IsNullOrWhiteSpace(input.Text))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }
        var habito = new Habito
        {
            Name = texto,
            Count = 0
        };
        await _data.SaveHabitoAsync(habito);
        CargarHabitos();

        //var newLabel = new Label { Text = $"{texto}" };
        //myLayout.Children.Add(newLabel);
    }
}
