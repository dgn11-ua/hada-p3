using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENCategory
    {
        private string _name;
        private string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ENCategory(string name)
        {
            Name = name;
        }

        /*public bool read()
        {
            CADCategory aux = new CADCategory();

            return aux.read(this);
        }*/

    }
}
