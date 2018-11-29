namespace GymAppData.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }

        public int DayId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public int Order { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Day Day { get; set; }

        public virtual ICollection<Set> Sets { get; set; }
    }
}
