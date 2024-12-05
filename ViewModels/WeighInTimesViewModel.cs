using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class WeighInTimesViewModel : INotifyPropertyChanged
    {
        public ICommand PreviewDietCommand { get; }

        public WeighInTimesViewModel()
        {
            PreviewDietCommand = new Command(OnPreviewDiet);
        }

        private bool isMondayChecked;
        public bool IsMondayChecked
        {
            get => isMondayChecked;
            set
            {
                isMondayChecked = value;
                OnPropertyChanged();
                ValidateSelections();
            }
        }

        private bool isTuesdayChecked;
        public bool IsTuesdayChecked
        {
            get => isTuesdayChecked;
            set
            {
                isTuesdayChecked = value;
                OnPropertyChanged();
                ValidateSelections();
            }
        }

        private bool isWednesdayChecked;
        public bool IsWednesdayChecked
        {
            get => isWednesdayChecked;
            set
            {
                isWednesdayChecked = value;
                OnPropertyChanged();
                ValidateSelections();
            }
        }

        private bool isThursdayChecked;
        public bool IsThursdayChecked
        {
            get => isThursdayChecked;
            set
            {
                isThursdayChecked = value;
                OnPropertyChanged();
                ValidateSelections();
            }
        }

        private bool isFridayChecked;
        public bool IsFridayChecked
        {
            get => isFridayChecked;
            set
            {
                isFridayChecked = value;
                OnPropertyChanged();
                ValidateSelections();
            }
        }

        private string notificationTime;
        public string NotificationTime
        {
            get => notificationTime;
            set
            {
                notificationTime = value;
                OnPropertyChanged();
            }
        }

        private void ValidateSelections()
        {
            // Implement validation logic if needed
            // For example, ensure at least two non-consecutive days are selected
        }

        private async void OnPreviewDiet()
        {
            // Implement preview diet logic
            // For demonstration, we'll display the selected days and notification time

            var selectedDays = GetSelectedDays();
            if (selectedDays.Count < 2)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please select at least two non-consecutive days.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(NotificationTime))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a notification time.", "OK");
                return;
            }

            string days = string.Join(", ", selectedDays);
            await Application.Current.MainPage.DisplayAlert("Diet Preview", $"Weigh-In Days: {days}\nNotification Time: {NotificationTime}", "OK");

            // Proceed to next step, e.g., save settings or navigate to another page
        }

        private ObservableCollection<string> GetSelectedDays()
        {
            var days = new ObservableCollection<string>();
            if (IsMondayChecked) days.Add("Monday");
            if (IsTuesdayChecked) days.Add("Tuesday");
            if (IsWednesdayChecked) days.Add("Wednesday");
            if (IsThursdayChecked) days.Add("Thursday");
            if (IsFridayChecked) days.Add("Friday");
            return days;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
