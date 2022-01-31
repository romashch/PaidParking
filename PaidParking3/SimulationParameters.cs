using System;
using System.Collections.Generic;
using System.Text;

namespace PaidParking3
{
    class SimulationParameters
    {       
        public const double DayMinPrice = 150;
        public const double DayMaxPrice = 300;
        public const double NightMinPrice = 100;
        public const double NightMaxPrice = 250;
                
        public const double TFIntervalMin = 1;
        public const double TFIntervalMax = 10;
               
        public const double TFMxMin = 1;
        public const double TFMxMax = 10;
        public const double TFDxMin = 0;
        public const double TFDxMax = 0.1;
                            
        public const double TFMinMin = 1;
        public const double TFMinMax = 10;
        public const double TFMaxMin = 1;
        public const double TFMaxMax = 10;
                            
        public const double TFLambdaMin = 0.1;
        public const double TFLambdaMax = 1;

        public const double PTIntervalMin = 10;
        public const double PTIntervalMax = 100;
                            
        public const double PTMxMin = 10;
        public const double PTMxMax = 100;
        public const double PTDxMin = 0;
        public const double PTDxMax = 10;
                            
        public const double PTMinMin = 10;
        public const double PTMinMax = 100;
        public const double PTMaxMin = 10;
        public const double PTMaxMax = 100;
                            
        public const double PTLambdaMin = 0.01;
        public const double PTLambdaMax = 0.1;

        double enteringProbability;
        double trucksPercentage;
        double dayTariffPrice;
        double nightTariffPrice;

        public enum DetRan
        {
            Deterministic,
            Random
        }

        public enum DistributionLaw
        {
            Normal,
            Uniform,
            Exponential
        }

        double interval;
        DistributionLaw law;
        double mx;
        double dx;
        double min;
        double max;
        double lambda;

        DetRan parkingTimeType;
        double interval2;
        DistributionLaw law2;
        double mx2;
        double dx2;
        double min2;
        double max2;
        double lambda2;

        int startHour;
        int startMinute;

        public double EnteringProbability { get; set; }
        public double TrucksPercentage { get; set; }
        public double DayTariffPrice { get; set; }
        public double NightTariffPrice { get; set; }
        public DetRan TrafficFlowType { get; set; }
        public double Interval { get; set; }
        public DistributionLaw Law { get; set; }
        public double Mx { get; set; }
        public double Dx { get; set; }
        public double Min { get; set; }
        public double Max
        {
            get
            {
                return max;
            }
            set
            {
                if (value >= min) max = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double Lambda { get; set; }
        public DetRan ParkingTimeType { get; set; }
        public double Interval2 { get; set; }
        public DistributionLaw Law2 { get; set; }
        public double Mx2 { get; set; }
        public double Dx2 { get; set; }
        public double Min2 { get; set; }
        public double Max2 { get; set; }
        public double Lambda2 { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
    }
}
