using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypertrophyApp.Models
{
    public class Exercise
    {
        public string MuscleGroup { get; set; }
        public string ExerciseName { get; set; }
        public string Equipment { get; set; }
        public string Instructions { get; set; }
        public ObservableCollection<ExerciseSet> Sets { get; set; }
    }
}
