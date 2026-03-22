using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {
        // 1. Atributos privados (tal cual pide el diagrama)
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        // 2. Propiedades públicas
        public string Code { get => _code; set => _code = value; }
        public string Name { get => _name; set => _name = value; }
        public int Amount { get => _amount; set => _amount = value; }
        public float Price { get => _price; set => _price = value; }
        public int Category { get => _category; set => _category = value; }
        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }

        // 3. Constructores
        public ENProduct()
        {
            _code = "";
            _name = "";
            _amount = 0;
            _price = 0.0f;
            _category = 0;
            _creationDate = DateTime.Now;
        }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            _code = code;
            _name = name;
            _amount = amount;
            _price = price;
            _category = category;
            _creationDate = creationDate;
        }

        // 4. Métodos (hacen uso de CADProduct)
        public bool create()
        {
            CADProduct cad = new CADProduct();
            return cad.create(this);
        }

        public bool update()
        {
            CADProduct cad = new CADProduct();
            return cad.update(this);
        }

        public bool delete()
        {
            CADProduct cad = new CADProduct();
            return cad.delete(this);
        }

        public bool read()
        {
            CADProduct cad = new CADProduct();
            return cad.read(this);
        }

        public bool readFirst()
        {
            CADProduct cad = new CADProduct();
            return cad.readFirst(this);
        }

        public bool readNext()
        {
            CADProduct cad = new CADProduct();
            return cad.readNext(this);
        }

        public bool readPrev()
        {
            CADProduct cad = new CADProduct();
            return cad.readPrev(this);
        }
    }
}

