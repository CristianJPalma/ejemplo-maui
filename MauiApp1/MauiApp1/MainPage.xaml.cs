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

	public async void CargarHabitos() 
	{
		var list = await _data.GetHabitosAsync();
        myLayout.ItemsSource = list;
    }

    public async void GuardarHabitos(object sender, EventArgs e)
    {
        string texto = input.Text;

        if (string.IsNullOrWhiteSpace(input.Text))
        {
            //await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }
        var habito = new Habito
        {
            Name = texto,
            Count = 0
        };
        await _data.SaveHabitoAsync(habito);
        CargarHabitos();
    }

    public async void OnCounterHabitoClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var habito = (Habito)button.CommandParameter;
        habito.Count++;
        await _data.SaveHabitoAsync(habito);
        CargarHabitos();
    }

    public async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var habito = (Habito)button.CommandParameter;
        await _data.DeleteHabitoAsync(habito);
        CargarHabitos();
    }
}
