using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GrindingPlanner.Shared
{
    public class WeekPlan
    {
        public int WeekPlanId { get; set; }

        [ForeignKey("TrainingPlan")]
        public int TrainingPlanId { get; set; }
        public TrainingPlan TrainingPlan { get; set; }

        public DateOnly WeekPlanFrom { get; set; }
        public DateOnly WeekPlanTo { get; set; }

        /*
        public int DayPlanMondayId { get; set; }
        public int DayPlanTuesdayId { get; set; }
        public int DayPlanWednesdayId { get; set; }
        public int DayPlanThursdayId { get; set; }
        public int DayPlanFridayId { get; set; }
        public int DayPlanSaturdayId { get; set; }
        public int DayPlanSundayId { get; set; }*/
    }
}
