using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        // Expose DaysOfWeek from the ParentViewModel
        public List<string> DaysOfWeek => ParentViewModel.DaysOfWeek;

        public ObservableCollection<MuscleGroupViewModel> MuscleGroups { get; set; } = new ObservableCollection<MuscleGroupViewModel>();

        public ICommand AddMuscleGroupCommand { get; }

        private CreateMesocycleViewModel ParentViewModel { get; }

        public DayViewModel(CreateMesocycleViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
            AddMuscleGroupCommand = new Command(OnAddMuscleGroup);

            // Initialize with at least one Muscle Group
            OnAddMuscleGroup();
        }

        private void OnAddMuscleGroup()
        {
            MuscleGroups.Add(new MuscleGroupViewModel(ParentViewModel));
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
