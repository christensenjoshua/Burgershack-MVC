using Burgershack.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgershack.Data
{
    public static class FakeDb
    {
        public static int BurgerNextId = 4;
        public static List<Burger> Burgers = new List<Burger>() {
            new Burger(){
                Id = 1,
                Name = "Plain Jane",
                Price =  7.99m,
                Description = "Delicious yet lacking somehow"
            },
            new Burger(){
                Id = 2,
                Name = "Plain Jane con Queso",
                Price =  8.99m,
                Description = "Delicioso"
            },
            new Burger(){
                Id = 3,
                Name = "Hawaiian",
                Price =  12.99m,
                Description = "Pineapple YUM!!!"
            },
        };

        public static int DrinkNextId = 4;
        public static List<Drink> Drinks = new List<Drink>() {
            new Drink
            (){
                Id = 1,
                Name = "Apple Juice",
                Price =  1.50m,
                Description = "Applicious"
            },
            new Drink(){
                Id = 2,
                Name = "Soder",
                Price =  1.57m,
                Description = "Bubbly and refreshing"
            },
            new Drink(){
                Id = 3,
                Name = "Shake",
                Price =  5.99m,
                Description = "Chocolate, vanilla and Strawberry all in one YUM!!!"
            },
        };

        public static int SideNextId = 4;
        public static List<Side> Sides = new List<Side>() {
            new Side
            (){
                Id = 1,
                Name = "Apple Juice",
                Price =  1.50m,
                Description = "Applicious"
            },
            new Side(){
                Id = 2,
                Name = "Soder",
                Price =  1.57m,
                Description = "Bubbly and refreshing"
            },
            new Side(){
                Id = 3,
                Name = "Shake",
                Price =  5.99m,
                Description = "Chocolate, vanilla and Strawberry all in one YUM!!!"
            },
        };

    }
}
