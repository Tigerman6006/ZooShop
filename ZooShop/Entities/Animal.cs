using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooShop.Entities
{
    public class Animal:Salable
    {
        private int animalCode;
        private string species;
        private string breed;
        private DateTime dateOfBirth;
        private Animal(int animalCode, string name, decimal purchasePrice, decimal sellingPrice, string species, string breed, DateTime dateOfBirth)
        {
            this.name = name;
            this.purchasePrice = purchasePrice;
            this.sellingPrice = sellingPrice;
            this.animalCode = animalCode;
            this.species = species;
            this.breed = breed;
            this.dateOfBirth = dateOfBirth;
        }
        public static Animal CreateAnimal(int animalCode, string name, decimal purchasePrice, decimal sellingPrice, string species, string breed, DateTime dateOfBirth)
        {
            return new Animal(animalCode, name, purchasePrice, sellingPrice, species, breed, dateOfBirth);
        }
        public int AnimalCode
        {
            get {  return animalCode; }
            set { animalCode = value; }
        }
        public string Species
        {
            get { return species; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    species = value;
                }
            }
        }
        public string Breed
        {
            get { return breed; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    breed = value;
                }
            }
        }
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (value < DateTime.Now)
                {
                    dateOfBirth = value;
                }
            }
        }
    }
}
