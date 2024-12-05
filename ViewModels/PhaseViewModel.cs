using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class PhaseViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PhaseExercise> PhaseExercises { get; set; }

        public PhaseViewModel()
        {
            PhaseExercises = new ObservableCollection<PhaseExercise>
            {
                new PhaseExercise { ExerciseName = "Bench Press" },
                new PhaseExercise { ExerciseName = "Deadlift" },
                new PhaseExercise { ExerciseName = "Squat" },
                // Dodajte več vaj po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PhaseExercise : INotifyPropertyChanged
    {
        public string ExerciseName { get; set; }

        private string weight;
        public string Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }

        private string reps;
        public string Reps
        {
            get => reps;
            set
            {
                reps = value;
                OnPropertyChanged();
            }
        }

        public ICommand LogCommand { get; }

        public PhaseExercise()
        {
            LogCommand = new Command(OnLog);
        }

        private async void OnLog()
        {
            // Implement log logic, e.g., save to database or collection
            if (string.IsNullOrWhiteSpace(Weight) || string.IsNullOrWhiteSpace(Reps))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter weight and reps.", "OK");
                return;
            }

            // Save the log (implementation depends on your data storage)
            // Example:
            // var log = new ExerciseLog { Name = ExerciseName, Weight = Weight, Reps = Reps };
            // await Database.SaveExerciseLogAsync(log);

            await Application.Current.MainPage.DisplayAlert("Success", $"Logged {ExerciseName}: {Weight} lbs x {Reps} reps.", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
