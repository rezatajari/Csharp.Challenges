using System;
using System.Linq;

namespace BirdWatcher
{
    internal class BirdCount
    {
        private int[] birdsPerDay;

        public BirdCount(int[] birds)
        {
            birdsPerDay = birds;
        }

        public int Today()
        {
            return birdsPerDay[birdsPerDay.Length - 1];
        }
        public void IncrementTodaysCount()
        {
            birdsPerDay[birdsPerDay.Length - 1]++;
        }
        public bool HasDayWithoutBirds()
        {
            return birdsPerDay.Contains(0);
        }
        public int CountForFirstDays(int days)
        {
            int sum = 0;
            for (int i = 0; i < days; i++)
            {
                sum += birdsPerDay[i];
            }
            return sum;
        }
        public int BusyDays()
        {
            int count = 0;
            foreach (var birds in birdsPerDay)
            {
                if (birds >= 5)
                    count++;
            }
            return count;
        }
        public static int[] LastWeek()
        {
            return new int[] { 0, 2, 5, 3, 7, 8, 4 };
        }
    }
}
