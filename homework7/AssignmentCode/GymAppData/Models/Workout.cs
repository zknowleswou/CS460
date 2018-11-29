namespace GymAppData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkoutId { get; set; }

        public string OwnerId { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? Updated { get; set; }

        public virtual List<Day> Days { get; set; }
    }
}
