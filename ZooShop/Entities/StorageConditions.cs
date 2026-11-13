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
        private int temperature;
        private int humidity;
        private SpecialRequirements specialRequirements;
        private StorageConditions(int temperature, int humidity, SpecialRequirements specialRequirements)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.specialRequirements = specialRequirements;
        }
        public static StorageConditions CreateBaseConditions(int temperature, int humidity)
        {
            return new StorageConditions(temperature, humidity, SpecialRequirements.None);
        }
        public static StorageConditions CreateAdvancedConditions(int temperature, int humidity, SpecialRequirements specialRequirements)
        {
            return new StorageConditions(temperature, humidity, specialRequirements);
        }
        public int Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public int Humidity
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
