using Microsoft.Maui.Controls;
using HypertrophyApp.ViewModels;

namespace HypertrophyApp.Pages
{
    public partial class CreateMesocyclePage : ContentPage
    {
        public CreateMesocyclePage()
        {
            InitializeComponent();
            var viewModel = new CreateMesocycleViewModel();
            BindingContext = viewModel;

            // Subscribe to messages
            MessagingCenter.Subscribe<CreateMesocycleViewModel, string>(this, "ExerciseAdded", async (sender, exerciseName) =>
            {
                await DisplayAlert("Success", $"Exercise '{exerciseName}' has been added.", "OK");
            });

            MessagingCenter.Subscribe<CreateMesocycleViewModel, string>(this, "ExerciseAddFailed", async (sender, message) =>
            {
                await DisplayAlert("Error", message, "OK");
            });
        }


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Unsubscribe to prevent memory leaks
            MessagingCenter.Unsubscribe<CreateMesocycleViewModel, string>(this, "ExerciseAdded");
            MessagingCenter.Unsubscribe<CreateMesocycleViewModel, string>(this, "ExerciseAddFailed");
        }
    }
}
