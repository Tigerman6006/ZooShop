using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooShop.Enums;

namespace ZooShop.Entities
{
    public class StorageConditions
    {
        private double temperature;
        private double humidity;
        private SpecialRequirements specialRequirements;
        private StorageConditions(double temperature, double humidity, SpecialRequirements specialRequirements)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.specialRequirements = specialRequirements;
        }
        public static StorageConditions CreateConditions(double temperature, double humidity)
        {
            return new StorageConditions(temperature, humidity, SpecialRequirements.None);
        }
        public static StorageConditions CreateConditions(double temperature, double humidity, SpecialRequirements specialRequirements)
        {
            return new StorageConditions(temperature, humidity, specialRequirements);
        }
        public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public double Humidity
        {
            get => humidity;
            set { humidity = value; }
        }
        public SpecialRequirements SpecialRequirements
        {
            get { return specialRequirements; }
            set { specialRequirements = value; }
        }
    }
}
