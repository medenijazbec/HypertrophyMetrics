using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class StartDateViewModel : INotifyPropertyChanged
    {
        private DateTime dietStartDate;
        public DateTime DietStartDate
        {
            get => dietStartDate;
            set
            {
                dietStartDate = value;
                OnPropertyChanged();
            }
        }

        private string targetWeight;
        public string TargetWeight
        {
            get => targetWeight;
            set
            {
                targetWeight = value;
                OnPropertyChanged();
            }
        }

        private DateTime dietEndDate;
        public DateTime DietEndDate
        {
            get => dietEndDate;
            set
            {
                dietEndDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand ContinueCommand { get; }

        public StartDateViewModel()
        {
            DietStartDate = DateTime.Today;
            DietEndDate = DateTime.Today.AddMonths(1);
            ContinueCommand = new Command(OnContinue);
        }

        private async void OnContinue()
        {
            // Implement continue logic, e.g., save data and navigate to next page
            if (string.IsNullOrWhiteSpace(TargetWeight))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter your target weight.", "OK");
                return;
            }

            // Save the data (implementation depends on your data storage)
            // Example:
            // var userPlan = new UserPlan { StartDate = DietStartDate, EndDate = DietEndDate, TargetWeight = TargetWeight };
            // await Database.SaveUserPlanAsync(userPlan);

            await Application.Current.MainPage.DisplayAlert("Success", "Start date and target weight saved successfully.", "OK");

            // Navigate to next page
            // await Application.Current.MainPage.Navigation.PushAsync(new NextPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
