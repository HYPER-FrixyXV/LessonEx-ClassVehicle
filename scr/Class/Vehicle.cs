using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BPascal.LessonEx2.ClassDomain
{
    public class Vehicle
    {
        private string _licensePlate;
        private int _id;
        private int _odometerKm;
        private double _dailyRate;
        private double _fuelLvPerc;

        public string LicensePlate
        {
            get => _licensePlate;
            private set
            {
                if(LicensePlate.Length != 7)
                {
                    throw new ArgumentException($"value invalid {nameof(value)}");
                }
                _licensePlate = value;
            }
        }
        
        public int ID { get; private set; }
        public int Odometer
        {
            get { return _odometerKm; }
            private set 
            {
                if(value < 0) {
                    throw new ArgumentException($"value invalid {nameof(value)}");
                }
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
            }
        }

        public Vehicle(string licensePlate): this(licensePlate, 0, 0, 100)
        {
            LicensePlate = licensePlate;
        }

        public Vehicle(string licensePlate, int odometerKm): this(licensePlate)
        {
            Odometer = odometerKm;
        }

        public Vehicle(string licensePlate, int odometerKM,
            double dailyRate, double fuelLvPerc)
        {
            LicensePlate = licensePlate;
            Odometer = odometerKM;
            DailyRate = dailyRate ;
            FuelLvPerc = fuelLvPerc ;
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