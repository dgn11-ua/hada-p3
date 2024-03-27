using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _amount;
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private float _price;
        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _category;
        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }
        //------------------METHODS OF CLASS-----------------------
        public ENProduct()
        {

        }

        public ENProduct(string code,string name,int amount, float price, DateTime creationDate)
        {
            Code = code;
            Name = name;
            Amount = amount;
            Price = price;
            CreationDate = creationDate;
        }

        public bool Create()
        {
            CADProduct cadproduct = new CADProduct();

            return cadproduct.Create(this);
        }

        public bool Update()
        {
            CADProduct cadproduct = new CADProduct();

            return cadproduct.Update(this);
        }

        public bool Delete()
        {
            CADProduct cadproduct = new CADProduct();

            return cadproduct.Delete(this);
        }

        public bool Read()
        {
            CADProduct cadproduct = new CADProduct();

            return cadproduct.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct cadproduct = new CADProduct();

            return true;    //CAMBIAR
        }

        public bool ReadNext()
        {
            CADProduct cadproduct = new CADProduct();

            return true; //cadproduct.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct cadproduct = new CADProduct();

            return true; // cadproduct.ReadPrev(this);
        }
    }
}
