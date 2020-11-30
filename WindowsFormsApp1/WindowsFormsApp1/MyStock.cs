using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MyStock
    {
        private int stockNo, price, machineNo;
        private string machineType, machineName, quantity;

        public MyStock()
        {
            this.stockNo = 0;  this.price = 0; this.machineNo = 0;
            this.machineType = ""; this.machineName = ""; ; this.quantity = "";
        }

        public MyStock(int stockNo, int machineNo, string quantity, int price, string machineType, string machineName)
        {
            this.stockNo = stockNo;  this.quantity = quantity; this.price = price;
            this.machineType = machineType; this.machineName = machineName; 
        }
        public int StockNo
        {
            get { return stockNo; }
            set { stockNo = value; }
        }
        public int MachineNo
        {
            get { return machineNo; }
            set { machineNo = value; }
        }

        public string MachineType
        {
            get { return machineType; }
            set
            {
                if ((value.ToUpper() != "BIKE") && (value.ToUpper() != "TREDMILL") &&
                   (value.ToUpper() != "MUTLIRACK") && (value.ToUpper() != "STAIRS") && (value.ToUpper() != "WONDERCORE") && (value.ToUpper() != "OTHER"))
                    throw new MyException("Title must be Bike, Tredmill, Multirack, Stairs, Wondercore or Other.");
                else
                    MachineType = MyValidation.firstLetterEachWordToUpper(value);
            }
        }

        public string MachineName
        {
            get { return machineName; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validMachineName(value))
                {
                    machineName = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Machine Name must be 4-20 letters");
            }
        }

        public string Quantity
        {
            get { return quantity; }
            set
            {
                if ((value.ToUpper() != "ONE") && (value.ToUpper() != "TWO") &&
                   (value.ToUpper() != "THREE") && (value.ToUpper() != "FOUR") &&
                   (value.ToUpper() != "FIVE") && (value.ToUpper() != "SIX"))
                    throw new MyException("Quantity must be 1,2,3,4,5 or 6");
                else
                    quantity = MyValidation.firstLetterEachWordToUpper(value);
            }
        }



        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}

