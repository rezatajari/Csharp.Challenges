using System;

namespace Lucian_sLusciousLasagna
{
    internal class Lasagna
    {
        public int ExpectedMinutesInOven()
        {
            return 40;
        }

        public int RemainingMinutesInOven(int actualMinutes)
        {
            return ExpectedMinutesInOven() - actualMinutes;
        }

        public int PreparationTimeInMinutes(int numberOfLayers)
        {
            return numberOfLayers * 2;
        }

        public int ElapsedTimeInMinutes(int numberOfLayers, int actualMinutes)
        {
            int timeLayers = PreparationTimeInMinutes(numberOfLayers);
            return timeLayers + actualMinutes;
        }
    }
}
