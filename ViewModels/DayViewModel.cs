using System.Collections.Generic; // Add this if not already present
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace HypertrophyApp.ViewModels
{
    public class DayViewModel : BindableObject
    {
        private string selectedDayOfWeek;
        public string SelectedDayOfWeek
        {
            get => selectedDayOfWeek;
            set
            {
                if (selectedDayOfWeek != value)
                {
                    selectedDayOfWeek = value;
                    OnPropertyChanged();
                }
            }
        }

        // Add the DaysOfWeek property here
        public List<string> DaysOfWeek => ParentViewModel.DaysOfWeek;

        public ObservableCollection<MuscleGroupViewModel> MuscleGroups { get; set; } = new ObservableCollection<MuscleGroupViewModel>();

        public ICommand AddMuscleGroupCommand { get; }

        private CreateMesocycleViewModel ParentViewModel { get; }

        public DayViewModel(CreateMesocycleViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
            AddMuscleGroupCommand = new Command(OnAddMuscleGroup);
        }

        private void OnAddMuscleGroup()
        {
            MuscleGroups.Add(new MuscleGroupViewModel(ParentViewModel));
        }
    }
}
