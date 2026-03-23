using System;
using System.Collections.Generic;

namespace library
{
    public class ENCategory
    {
        // Atributos privados
        private int _id;
        private string _name;

        // Propiedades públicas
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        // Constructores
        public ENCategory()
        {
            _id = 0;
            _name = "";
        }

        public ENCategory(int id, string name)
        {
            _id = id;
            _name = name;
        }

        // Métodos de la lógica de negocio que llaman al CAD
        public bool read()
        {
            CADCategory cad = new CADCategory();
            return cad.read(this);
        }

        public List<ENCategory> readAll()
        {
            CADCategory cad = new CADCategory();
            return cad.readAll();
        }
    }
}