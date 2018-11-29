using GymAppData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppConsole
{
    public class AlexsWorkout
    {
        public Workout DefineWorkout()
        {
            return new Workout
            {
                //WorkoutId = 0,
                Name = "Alex's Workout",
                Days = new List<Day>
                    {
                        new Day
                        {
                            Name = "Day A",
                            Order = 1,
                            //WorkoutId = 0,
                            Exercises = new List<Exercise>
                            {
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 1,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "10 Minutes",
                                            Repititions = 10,
                                            Weight = 5m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Leg Curl Machine",
                                    Order = 2,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Pulldown",
                                    Order = 3,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 20m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 4,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "5 Minutes",
                                            Repititions = 5,
                                            Weight = 10m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Bench Press",
                                    Order = 5,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 2.5m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 2.5m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 2.5m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Squat",
                                    Order = 6,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 10m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 10m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 10m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 7,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "5 Minutes",
                                            Order = 1,
                                            Repititions = 5,
                                            Weight = 10m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Hyperextensions",
                                    Order = 8,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 5m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 5m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 5m
                                        },

                                    }
                                },new Exercise
                                {
                                    Name = "Glute Kick Back",
                                    Order = 9,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 3m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 3m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 3m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 10,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "8 Minutes",
                                            Order = 1,
                                            Repititions = 8,
                                            Weight = 5m
                                        }
                                    }
                                },
                            }
                        },
                        new Day
                        {
                            Name = "Day B",
                            Order = 1,
                            //WorkoutId = 0,
                            Exercises = new List<Exercise>
                            {
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 1,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "10 Minutes",
                                            Order = 1,
                                            Repititions = 10,
                                            Weight = 5m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Walking Lunge",
                                    Order = 2,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Standing Barbell Shoulder Press",
                                    Order = 3,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 0m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Rowing Machine",
                                    Order = 4,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Level 10 - 300m",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 20m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Deadlift",
                                    Order = 5,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 30m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 30m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 30m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Dumbbell Row",
                                    Order = 6,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 6m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Rowing Machine",
                                    Order = 7,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Level 10 - 300m",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 20m
                                        }
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Knee Tucks",
                                    Order = 8,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 12,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 12,
                                            Weight = 0m
                                        },

                                    }
                                },new Exercise
                                {
                                    Name = "Plank",
                                    Order = 9,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 1",
                                            Order = 1,
                                            Repititions = 60,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 2",
                                            Order = 2,
                                            Repititions = 60,
                                            Weight = 0m
                                        },
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "Set 3",
                                            Order = 3,
                                            Repititions = 60,
                                            Weight = 0m
                                        },
                                    }
                                },
                                new Exercise
                                {
                                    Name = "Treadmill",
                                    Order = 10,
                                    //DayId = 0,
                                    Sets = new List<Set>
                                    {
                                        new Set
                                        {
                                            //ExerciseId = 0,
                                            Name = "8 Minutes",
                                            Order = 1,
                                            Repititions = 12,
                                            Weight = 20m
                                        }
                                    }
                                },
                            }
                        },
                    }
            };
        }
    }
}
