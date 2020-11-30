using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MyParts
    {
        private int stockNo, price;
        private string machineType, partDesc, machineNo, quantity;

        public MyParts()
        {
            this.stockNo = 0; this.price = 0;
            this.machineType = ""; this.partDesc = ""; this.machineNo = ""; this.quantity = "";
        }

        public MyParts(int stockNo, int machineNo, string quantity, int price, string machineType, string partDesc)
        {
            this.stockNo = stockNo; this.quantity = quantity; 
            this.machineType = machineType; this.partDesc = partDesc;
        }
        public int PartNo
        {
            get { return stockNo; }
            set { stockNo = value; }
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

        public string PartDesc
        {
            get { return partDesc; }
            set
            {
                if (MyValidation.validLength(value, 4, 40) && MyValidation.validPartDesc(value))
                {
                    partDesc = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Part Description must be 4-40 letters");
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
                    machineNo = MyValidation.firstLetterEachWordToUpper(value);
            }
        }



        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
