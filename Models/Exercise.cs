using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.Models
{
    public class Exercise : INotifyPropertyChanged
    {
        private string muscleGroup;
        public string MuscleGroup
        {
            get => muscleGroup;
            set
            {
                if (muscleGroup != value)
                {
                    muscleGroup = value;
                    OnPropertyChanged();
                }
            }
        }

        private string exerciseName;
        public string ExerciseName
        {
            get => exerciseName;
            set
            {
                if (exerciseName != value)
                {
                    exerciseName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string equipment;
        public string Equipment
        {
            get => equipment;
            set
            {
                if (equipment != value)
                {
                    equipment = value;
                    OnPropertyChanged();
                }
            }
        }

        private string youTubeVideoId;
        public string YouTubeVideoId
        {
            get => youTubeVideoId;
            set
            {
                if (youTubeVideoId != value)
                {
                    youTubeVideoId = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<ExerciseSet> Sets { get; set; } = new ObservableCollection<ExerciseSet>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
