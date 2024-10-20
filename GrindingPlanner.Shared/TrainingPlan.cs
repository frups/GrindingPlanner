using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GrindingPlanner;

namespace GrindingPlanner.Shared
{
    public class TrainingPlan
    {
        public int TrainingPlanId { get; set; }
        public string? TrainingPlanName { get; set; } = String.Empty;
        public string? OwnerId { get; set; }
        public string? TrainerId { get; set; } = String.Empty;

        public List<WeekPlan> WeekPlans { get; set; }
    }
}