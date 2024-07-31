using System;
using System.Collections.Generic;
using System.Text;

namespace GrindingPlanner.Shared
{
    public class TrainingPlan
    {
        public required string TrainingPlanId { get; set; }
        public string? TrainingPlanName { get; set; }
        public required string OwnerId { get; set; }
        public string? TrainerId { get; set; }
    }
}
