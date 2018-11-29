using GymAppData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymAppConsole
{
    public class ZachsWorkout
    {
        public Workout DefineWorkout()
        {
            var Workout = new Workout
            {
                Name = "Zach's Basic Workout",
                Days = new List<Day>
                {
                    new Day
                    {
                        Name = "Day A",
                        Order = 1,
                        Exercises = new List<Exercise>
                        {
                            new Exercise
                            {
                                Name = "Bench Press",
                                Order = 1,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 20
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 20
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 20
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Barbell Row",
                                Order = 2,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 15
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 15
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 15
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Cable Flys",
                                Order = 3,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Close Grip Bench",
                                Order = 4,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 7.5m
                                    },
                                }
                            },
                            new Exercise
                            {
                                Name = "Dumbbell Curls",
                                Order = 5,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 19
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 10
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 10
                                    },
                                }
                            },
                            new Exercise
                            {
                                Name = "Leg Raises",
                                Order = 1,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 9,
                                        Weight = 0
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 7,
                                        Weight = 0
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 5,
                                        Weight = 0
                                    },
                                }
                            },
                        }
                    },
                    new Day
                    {
                        Name = "Day B",
                        Order = 1,
                        Exercises = new List<Exercise>
                        {
                            new Exercise
                            {
                                Name = "Leg Press",
                                Order = 1,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 50
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 50
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 50
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Deadlift",
                                Order = 2,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 20
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 20
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 20
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Sitting Shoulder Press",
                                Order = 3,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 16
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 16
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 16
                                    }
                                }
                            },
                            new Exercise
                            {
                                Name = "Hyperextension",
                                Order = 4,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 16,
                                        Weight = 0
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 16,
                                        Weight = 0
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 16,
                                        Weight = 0
                                    },
                                }
                            },
                            new Exercise
                            {
                                Name = "Dumbbell Curls",
                                Order = 5,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 19
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 10
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 10
                                    },
                                }
                            },
                            new Exercise
                            {
                                Name = "Tricep Rope",
                                Order = 6,
                                Sets = new List<Set>
                                {
                                    new Set
                                    {
                                        Name = "Set 1",
                                        Order = 1,
                                        Repititions = 12,
                                        Weight = 15
                                    },
                                    new Set
                                    {
                                        Name = "Set 2",
                                        Order = 2,
                                        Repititions = 12,
                                        Weight = 15
                                    },
                                    new Set
                                    {
                                        Name = "Set 3",
                                        Order = 3,
                                        Repititions = 12,
                                        Weight = 15
                                    },
                                }
                            },
                        }
                    }
                }
            };
            return Workout;
        } 
    }
}
