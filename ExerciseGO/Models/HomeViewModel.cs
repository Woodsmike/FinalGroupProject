using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExerciseGO.Models
{
    public class HomeViewModel
    {
        public Video Video { get; set; }
        public Game Game { get; set; }
        public ActivityLog ActivityLog { get; set; }
        public Emoji Emoji { get; set; }
        public TargetArea TargetArea { get; set; }
        public Stage Stage { get; set; }
    }
}