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

        //double enteringProbability = 0.5;
        //double trucksPercentage = 20;
        //double dayTariffPrice = DayMinPrice;
        //double nightTariffPrice = NightMinPrice;

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

        //DetRan trafficFlowType = DetRan.Random;
        //double interval = TFIntervalMin;
        //DistributionLaw law = DistributionLaw.Normal;
        //double mx = TFMxMin;
        //double dx = TFDxMax;
        //double lambda = TFLambdaMax;

        //DetRan parkingTimeType = DetRan.Random;
        //double interval2 = PTIntervalMin;
        //DistributionLaw law2 = DistributionLaw.Normal;
        //double mx2 = PTMxMin;
        //double dx2 = PTDxMax;
        //double lambda2 = PTLambdaMax;

        //int startHour = 5;
        //int startMinute = 0;

        public double EnteringProbability { get; set; } = 0.5;
        public double TrucksPercentage { get; set; } = 20;
        public double DayTariffPrice { get; set; } = DayMinPrice;
        public double NightTariffPrice { get; set; } = NightMinPrice;
        public DetRan TrafficFlowType { get; set; } = DetRan.Random;
        public double Interval { get; set; } = TFIntervalMin;
        public DistributionLaw Law { get; set; } = DistributionLaw.Normal;
        public double Mx { get; set; } = TFMxMin;
        public double Dx { get; set; } = TFDxMax;
        double min = TFMinMin;
        public double Min
        {
            get
            {
                return min;
            }
            set
            {
                if (value <= max) min = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        double max = TFMaxMax;
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
        public double Lambda { get; set; } = TFLambdaMax;
        public DetRan ParkingTimeType { get; set; } = DetRan.Random;
        public double Interval2 { get; set; } = PTIntervalMin;
        public DistributionLaw Law2 { get; set; } = DistributionLaw.Normal;
        public double Mx2 { get; set; } = PTMxMin;
        public double Dx2 { get; set; } = PTDxMax;
        double min2 = TFMinMin;
        public double Min2
        {
            get
            {
                return min2;
            }
            set
            {
                if (value <= max2) min2 = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        double max2 = TFMaxMax;
        public double Max2
        {
            get
            {
                return max2;
            }
            set
            {
                if (value >= min2) max2 = value;
                else throw new ArgumentOutOfRangeException();
            }
        }
        public double Lambda2 { get; set; } = PTLambdaMax;
        public int StartHour { get; set; } = 5;
        public int StartMinute { get; set; } = 0;
    }
}
