namespace GymAppData.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Set
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SetId { get; set; }

        public int ExerciseId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public int Order { get; set; }

        public int Repititions { get; set; }
        public decimal Weight { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
