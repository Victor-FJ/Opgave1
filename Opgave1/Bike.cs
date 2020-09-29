using System;

namespace Opgave1
{
    public class Bike
    {
        private string _color;
        private double _price;
        private int _noOfGears;

        public int Id { get; set; }

        public string Color
        {
            get => _color;
            set
            {
                if (value.Length < 1)
                    throw new ArgumentException();
                _color = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException();
                _price = value;
            }
        }

        public int NoOfGears
        {
            get => _noOfGears;
            set
            {
                if (value < 3 || value > 32)
                    throw new ArgumentOutOfRangeException();
                _noOfGears = value;
            }
        }

        public Bike(int id, string color, double price, int noOfGears)
        {
            Id = id;
            Color = color; 
            Price = price;
            NoOfGears = noOfGears;
        }

        public Bike()
        {
            Color = "Blank";
            Price = 500;
            NoOfGears = 3;
        }
    }
}
