namespace HelpdeskSystem
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnSubmitTicketClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleInput.Text) || PriorityPicker.SelectedItem == null)
            {
                await DisplayAlert("Validation Error", "Please enter a title and select a priority level.", "OK");
                return;
            }

            var newTicket = new Tickets
            {
                title = TitleInput.Text,
                priority = PriorityPicker.SelectedItem.ToString(),
                status = "Pending"// Defuat status for newly Created Tickets
            }; 

            await _databaseService.SaveTicketAsync(newTicket);

            await DisplayAlert("Success", "Your IT support ticket has been submitted successfully!", "OK");

            ClearForm();
        }

        private void ClearForm()
        {
            TitleInput.Text = string.Empty;
            DescriptionInput.Text = string.Empty;
            PriorityPicker.SelectedItem = null;
        }
    }

}
