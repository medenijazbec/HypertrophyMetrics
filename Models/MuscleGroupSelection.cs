using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypertrophyApp.Models
{
    public class MuscleGroupSelection
    {
        public string SelectedMuscleGroup { get; set; }
        public List<string> AvailableExercises { get; set; }
        public string SelectedExercise { get; set; }
    }
}
