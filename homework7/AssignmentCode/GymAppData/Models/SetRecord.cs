using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GymAppData.Models
{
    public class SetRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SetRecordId { get; set; }
        public int SetId { get; set; }
        public int WorkoutSessionId { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public int Order { get; set; }
        public int GoalRepititions { get; set; }
        public int CompletedRepititions { get; set; }
        public decimal GoalWeight { get; set; }
        public decimal CompletedWeight { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Set Set { get; set; }
        public virtual WorkoutSession WorkoutSession { get; set; }
    }
}
