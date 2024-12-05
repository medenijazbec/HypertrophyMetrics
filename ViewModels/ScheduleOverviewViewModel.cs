using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.ViewModels
{
    public class ScheduleOverviewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<WeeklySchedule> WeeklySchedules { get; set; }

        public ScheduleOverviewViewModel()
        {
            WeeklySchedules = new ObservableCollection<WeeklySchedule>
            {
                new WeeklySchedule { Week = "Week 1", Exercises = "Bench Press, Squat, Deadlift" },
                new WeeklySchedule { Week = "Week 2", Exercises = "Incline Press, Leg Press, Pull-Ups" },
                new WeeklySchedule { Week = "Week 3", Exercises = "Chest Fly, Lunges, Bent Over Rows" },
                new WeeklySchedule { Week = "Week 4", Exercises = "Push-Ups, Hamstring Curls, Lat Pulldowns" },
                new WeeklySchedule { Week = "Week 5", Exercises = "Cable Cross, Leg Extensions, Seated Rows" },
                new WeeklySchedule { Week = "Deload", Exercises = "Light Push-Ups, Light Rows" }
                // Dodajte več tednov po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class WeeklySchedule
    {
        public string Week { get; set; }
        public string Exercises { get; set; }
    }
}
