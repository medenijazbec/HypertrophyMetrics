using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class MuscleGroupViewModel : BindableObject
    {
        private string selectedMuscleGroup;
        public string SelectedMuscleGroup
        {
            get => selectedMuscleGroup;
            set
            {
                if (selectedMuscleGroup != value)
                {
                    selectedMuscleGroup = value;
                    OnPropertyChanged();
                    LoadExercisesForMuscleGroup();
                }
            }
        }

        private string selectedExercise;
        public string SelectedExercise
        {
            get => selectedExercise;
            set
            {
                if (selectedExercise != value)
                {
                    selectedExercise = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<string> Exercises { get; set; } = new ObservableCollection<string>();

        // Add the MuscleGroupsList property here
        public List<string> MuscleGroupsList => ParentViewModel.MuscleGroupsList;

        private CreateMesocycleViewModel ParentViewModel { get; }

        public MuscleGroupViewModel(CreateMesocycleViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        private void LoadExercisesForMuscleGroup()
        {
            Exercises.Clear();

            if (string.IsNullOrEmpty(SelectedMuscleGroup))
                return;

            switch (SelectedMuscleGroup)
            {
                case "Chest":
                    Exercises.Add("Bench Press");
                    Exercises.Add("Incline Dumbbell Press");
                    Exercises.Add("Chest Fly");
                    break;
                case "Back":
                    Exercises.Add("Deadlift");
                    Exercises.Add("Pull-ups");
                    Exercises.Add("Bent Over Row");
                    break;
                case "Triceps":
                    Exercises.Add("Triceps Pushdown");
                    Exercises.Add("Overhead Triceps Extension");
                    Exercises.Add("Close Grip Bench Press");
                    break;
                case "Biceps":
                    Exercises.Add("Barbell Curl");
                    Exercises.Add("Hammer Curl");
                    Exercises.Add("Preacher Curl");
                    break;
                case "Shoulders and Traps":
                    Exercises.Add("Military Press");
                    Exercises.Add("Lateral Raises");
                    Exercises.Add("Shrugs");
                    break;
                case "Quads":
                    Exercises.Add("Squats");
                    Exercises.Add("Leg Press");
                    Exercises.Add("Lunges");
                    break;
                case "Glutes":
                    Exercises.Add("Hip Thrusts");
                    Exercises.Add("Glute Bridges");
                    Exercises.Add("Cable Kickbacks");
                    break;
                case "Hamstrings":
                    Exercises.Add("Romanian Deadlift");
                    Exercises.Add("Leg Curl");
                    Exercises.Add("Good Mornings");
                    break;
                case "Calves":
                    Exercises.Add("Standing Calf Raise");
                    Exercises.Add("Seated Calf Raise");
                    Exercises.Add("Donkey Calf Raise");
                    break;
                case "Traps":
                    Exercises.Add("Barbell Shrugs");
                    Exercises.Add("Dumbbell Shrugs");
                    Exercises.Add("Upright Rows");
                    break;
                case "Forearms":
                    Exercises.Add("Wrist Curls");
                    Exercises.Add("Reverse Wrist Curls");
                    Exercises.Add("Farmer's Walk");
                    break;
                case "Abs":
                    Exercises.Add("Crunches");
                    Exercises.Add("Planks");
                    Exercises.Add("Leg Raises");
                    break;
                default:
                    Exercises.Add("Exercise 1");
                    Exercises.Add("Exercise 2");
                    Exercises.Add("Exercise 3");
                    break;
            }
        }
    }
}
