using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class RegainingMuscleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MuscleRegainingExercise> MuscleRegainingExercises { get; set; }

        public RegainingMuscleViewModel()
        {
            MuscleRegainingExercises = new ObservableCollection<MuscleRegainingExercise>
            {
                new MuscleRegainingExercise { ExerciseName = "Dumbbell Curls" },
                new MuscleRegainingExercise { ExerciseName = "Tricep Extensions" },
                new MuscleRegainingExercise { ExerciseName = "Leg Press" },
                // Dodajte več vaj po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MuscleRegainingExercise : INotifyPropertyChanged
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

        public ICommand LogSetCommand { get; }

        public MuscleRegainingExercise()
        {
            LogSetCommand = new Command(OnLogSet);
        }

        private async void OnLogSet()
        {
            // Implement log set logic
            if (string.IsNullOrWhiteSpace(Weight) || string.IsNullOrWhiteSpace(Reps))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter weight and reps.", "OK");
                return;
            }

            // Save the set (implementation depends on your data storage)
            // Example:
            // var set = new ExerciseSet { ExerciseName = ExerciseName, Weight = Weight, Reps = Reps };
            // await Database.SaveExerciseSetAsync(set);

            await Application.Current.MainPage.DisplayAlert("Success", $"Logged {ExerciseName}: {Weight} lbs x {Reps} reps.", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
