namespace GymAppData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Day
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DayId { get; set; }

        public int WorkoutId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public int Order { get; set; }

        public bool IsRestDay { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Workout Workout { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
