using System.Threading.Tasks;

namespace HelpdeskSystem;

public partial class TicketListPage : ContentPage
{
    private readonly DatabaseService _databaseService;

    public TicketListPage()
	{
		InitializeComponent();
		_databaseService = new DatabaseService();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await LoadTicketsFromDatabase();
	}

	private async void OnRefreshClicked(object sender, EventArgs e)
	{
		await LoadTicketsFromDatabase();
    }

	private async Task LoadTicketsFromDatabase()
	{
		var ticketList = await _databaseService.GetTicketsAsync();
		TicketsListView.ItemsSource = ticketList;
	}
}