using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HypertrophyApp.ViewModels
{
    public class WeekPlanViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DailyPlan> DailyPlans { get; set; }

        public WeekPlanViewModel()
        {
            DailyPlans = new ObservableCollection<DailyPlan>
            {
                new DailyPlan { Day = "Monday", Exercises = "Bench Press, Squats, Deadlift" },
                new DailyPlan { Day = "Tuesday", Exercises = "Incline Press, Leg Press, Pull-Ups" },
                new DailyPlan { Day = "Wednesday", Exercises = "Chest Fly, Lunges, Bent Over Rows" },
                new DailyPlan { Day = "Thursday", Exercises = "Push-Ups, Hamstring Curls, Lat Pulldowns" },
                new DailyPlan { Day = "Friday", Exercises = "Cable Cross, Leg Extensions, Seated Rows" },
                new DailyPlan { Day = "Saturday", Exercises = "Rest or Light Activity" },
                new DailyPlan { Day = "Sunday", Exercises = "Rest or Light Activity" }
                // Dodajte več dni po potrebi
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DailyPlan
    {
        public string Day { get; set; }
        public string Exercises { get; set; }
    }
}
