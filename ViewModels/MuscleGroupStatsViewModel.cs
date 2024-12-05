using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.ViewModels
{
    public class MuscleGroupStatsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MuscleGroupStat> MuscleGroupStats { get; set; }

        public MuscleGroupStatsViewModel()
        {
            MuscleGroupStats = new ObservableCollection<MuscleGroupStat>
            {
                new MuscleGroupStat
                {
                    GroupName = "Chest",
                    Week1 = "Bench Press",
                    Week2 = "Incline Dumbbell Press",
                    Week3 = "Chest Fly",
                    Week4 = "Push-Ups",
                    Week5 = "Cable Cross",
                    Deload = "Light Push-Ups"
                },
                new MuscleGroupStat
                {
                    GroupName = "Back",
                    Week1 = "Pull-Ups",
                    Week2 = "Deadlifts",
                    Week3 = "Bent Over Rows",
                    Week4 = "Lat Pulldowns",
                    Week5 = "Seated Rows",
                    Deload = "Light Rows"
                },
                // Dodajte več mišičnih skupin po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MuscleGroupStat
    {
        public string GroupName { get; set; }
        public string Week1 { get; set; }
        public string Week2 { get; set; }
        public string Week3 { get; set; }
        public string Week4 { get; set; }
        public string Week5 { get; set; }
        public string Deload { get; set; }
    }
}
