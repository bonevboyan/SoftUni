using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            //Type drinkType = Type.GetType(type);
            //IDrink drink = (IDrink) Activator.CreateInstance(drinkType, name, portion, brand);
            //drinks.Add(drink);
            if (type == "Tea")
            {
                this.drinks.Add(new Tea(name, portion, brand));
            }
            if (type == "Water")
            {
                this.drinks.Add(new Water(name, portion, brand));
            }

            //return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
            return $"Added { name} ({ brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            //Type foodType = Type.GetType(type);
            //IBakedFood food = (IBakedFood) Activator.CreateInstance(foodType, name, price);
            //bakedFoods.Add(food);
            if (type == "Bread")
            {
                this.bakedFoods.Add(new Bread(name, price));
            }
            if (type == "Cake")
            {
                this.bakedFoods.Add(new Cake(name, price));
            }
            return $"Added {name} ({type}) to the menu";
            //return $"Added {food.Name} ({food.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            //Type tableType = Type.GetType(type);
            //ITable table = (ITable) Activator.CreateInstance(tableType, tableNumber, capacity);
            //tables.Add(table);

            //return $"Added table number {table.TableNumber} in the bakery";
            if (type == "InsideTable")
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }
            if (type == "OutsideTable")
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            tables.Where(t => t.IsReserved == false).ToList()
                .ForEach(t => 
                {
                    sb.AppendLine(t.GetFreeTableInfo());
                });
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            table.Clear();
            this.totalIncome += bill;

            return $"Table: {tableNumber}\n" + $"Bill : {bill:F2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }
            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if(table == null)
            {
                return $"Could not find table {tableNumber}";
            }
            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }
            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);
            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
