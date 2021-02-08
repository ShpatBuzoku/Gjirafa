using System;
using System.Collections;
using System.Collections.Generic;

namespace LeagueScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            int num_teams = 16;
            int num_weeks = 15;

            Console.WriteLine(" -----CS-GO League Scheduler -----");
            Console.WriteLine(" ");

            SchedulerFunction(num_teams, num_weeks);
        }

        public static void SchedulerFunction(int num_teams, int num_weeks)
        {
            if (num_teams % 2 != 0)
            {
                num_teams++;
            }

            var n2 = num_teams / 2;

            //List<int> teams = new ArrayList();
            int[] teams = new int[num_teams];

            for (int i = 0; i < num_teams; i++)
            {
                teams[i] = i + 1;
            }

            int first_team = 0;
            int second_team = 0;

            for (int current_week = 1; current_week <= num_weeks; current_week++)
            {
                if (current_week >= 6)
                {

                    Console.WriteLine("      WEEK - " + current_week + " - ");

                    for (int j = 0; j < n2; j++)
                    {
                        first_team = teams[n2 - j - 1];
                        second_team = teams[n2 + j];

                        Console.WriteLine("      " + first_team + " : " + second_team);
                    }

                    Console.WriteLine(" ");
                }

                var temp = teams[1];
                for (int k = 1; k < teams.Length - 1; k++)
                {
                    teams[k] = teams[k+1];
                }
                teams[teams.Length - 1] = temp;
            }
        }
    }
}
