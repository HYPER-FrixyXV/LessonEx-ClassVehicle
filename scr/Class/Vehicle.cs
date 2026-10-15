using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Text;

namespace BPascal.LessonEx2.ClassDomain
{
    public class Vehicle
    {
        private string _licensePlate;
        private int _odometerKm;
        private double _dailyRate;
        private double _fuelLvPerc;

        public string LicensePlate
        {
            get { return _licensePlate; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 7)
                    throw new ArgumentException($"value not allowed {nameof(LicensePlate)}: {value} ");
                if (!char.IsLetter(value[0]) || !char.IsLetter(value[1]) || !char.IsDigit(value[2]) 
                    || !char.IsDigit(value[3]) || !char.IsDigit(value[4]) || !char.IsLetter(value[5]) 
                    || !char.IsLetter(value[6]))
                    throw new ArgumentException($"value not allowed {nameof(LicensePlate)}: {value} ");
                _licensePlate = value;
            }
        }
        public int Odometer
        {
            get { return _odometerKm; }
            private set 
            {
                if(value < 0) {
                    throw new ArgumentException($"value invalid {nameof(value)}");
                }
                _odometerKm = value;
            }
        }
        public double DailyRate
        {
            get { return _dailyRate; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"value invalid {nameof(value)}");
                }
                _dailyRate = value;
            }
        }
        public double FuelLvPerc
        {
            get { return _fuelLvPerc; }
            private set
            {
                if (value < 0 || value >100)
                {
                    throw new ArgumentException($"value invalid {nameof(value)}");
                }
                _fuelLvPerc = value;
            }
        }

        public Vehicle(string licensePlate) : this(licensePlate, 0, 0, 0)
        { }

        public Vehicle(string licensePlate, int odometerKm,
            double dailyRate, double fuelLevelPercentage)
        {
            LicensePlate = licensePlate;
            Odometer = odometerKm;
            DailyRate = dailyRate;
            FuelLvPerc = fuelLevelPercentage;
        }

        public void RegisterData(int consumedKm, double consumedFuel)
        {
            if (consumedKm <= 0) { 
                throw new ArgumentException($"value invalid {nameof(consumedKm)}");
            }
            if (consumedFuel <= 0 || (FuelLvPerc -= consumedFuel)<0)
            {
                throw new ArgumentException($"value invalid {nameof(consumedFuel)}");
            }
            Odometer += consumedKm;
            FuelLvPerc -= consumedFuel;
        }
    }
}