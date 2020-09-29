using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opgave1Tests
{
    [TestClass()]
    public class BikeTests
    {
        //Some legal values
        private const int Id = 3;
        private const string Color = "Rød";
        private const double Price = 845.50;
        private const int NoOfGears = 5;

        private Bike _bike;

        [TestInitialize]
        public void ArrangeBike()
        {
            _bike = new Bike(Id, Color, Price, NoOfGears);
        }

        [TestMethod]
        public void BikeTest()
        {
            //Testing that legal values do make a bike object and the values are put into the properties
            Assert.AreEqual(Id, _bike.Id);
            Assert.AreEqual(Color, _bike.Color);
            Assert.AreEqual(Price, _bike.Price);
            Assert.AreEqual(NoOfGears, _bike.NoOfGears);
        }

        [TestMethod]
        public void IdTest()
        {
            //Testing assigning
            const int newId = 5;
            _bike.Id = newId;
            Assert.AreEqual(newId, _bike.Id);
        }

        [TestMethod]
        public void ColorTestV1()
        {
            //Testing legal value
            const string newColor = "Blue";
            _bike.Color = newColor;
            Assert.AreEqual(newColor, _bike.Color);
        }

        [TestMethod]
        public void ColorTestV2()
        {
            //Testing illegal values
            Assert.ThrowsException<ArgumentException>(() => _bike.Color = "");
            Assert.ThrowsException<NullReferenceException>(() => _bike.Color = null);
            //Testing that original value still remain
            Assert.AreEqual(Price, _bike.Price);
        }

        [TestMethod]
        public void PriceTestV1()
        {
            //Testing legal value
            const double newPrice = 1045;
            _bike.Price = newPrice;
            Assert.AreEqual(newPrice, _bike.Price);
        }

        [TestMethod]
        public void PriceTestV2()
        {
            //Testing illegal values
            Assert.ThrowsException<ArgumentException>(() => _bike.Price = 0);
            Assert.ThrowsException<ArgumentException>(() => _bike.Price = -1045);
            //Testing that original value still remain
            Assert.AreEqual(Price, _bike.Price);
        }

        [TestMethod]
        public void NoOfGearsTest()
        {
            for (int i = 0; i < 40; i++)
            {
                int ia = i;
                //Rule for gears: Gear, 3 <= gear<= 32
                if (3 <= ia && ia <= 32)
                {
                    _bike.NoOfGears = ia;
                    Assert.AreEqual(ia, _bike.NoOfGears);
                }
                else
                {
                    Assert.ThrowsException<ArgumentOutOfRangeException>(() => _bike.NoOfGears = ia);
                }
            }
        }

        [TestMethod]
        public void BikeTestV2()
        {
            //Testing that illegal values are also illegal when used in the constructor
            Bike bike;

            Assert.ThrowsException<ArgumentException>(() => bike = new Bike(Id, "", Price, NoOfGears));
            Assert.ThrowsException<ArgumentException>(() => bike = new Bike(Id, Color, -1045, NoOfGears));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bike = new Bike(Id, Color, Price, 0));
        }

        [TestMethod]
        public void BikeTestV3()
        {
            //Testing that default constructor does make legal values
            Bike bike = new Bike();

            bike.Color = bike.Color;
            bike.Price = bike.Price;
            bike.NoOfGears = bike.NoOfGears;
        }
    }
}