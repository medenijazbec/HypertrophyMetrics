using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypertrophyApp.Models
{
    public class Day
    {
        public string SelectedDayOfWeek { get; set; }
        public ObservableCollection<MuscleGroupSelection> MuscleGroups { get; set; } = new ObservableCollection<MuscleGroupSelection>();
    }

}
