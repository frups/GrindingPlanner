using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GrindingPlanner.Data;

namespace GrindingPlanner.Shared
{
    public class TrainingPlan
    {
        public int TrainingPlanId { get; set; }
        public string? TrainingPlanName { get; set; } = String.Empty;
        public string? OwnerId { get; set; }
        public string? TrainerId { get; set; } = String.Empty;
    }
}