using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GrindingPlanner.Data;

namespace GrindingPlanner.Shared
{
    public class TrainingPlan
    {
        [Key]
        public string TrainingPlanId { get; set; }
        [Required]
        public ApplicationUser UserId { get; set; }
        public ApplicationUser TrainerId { get; set; }
    }
}
