namespace FactoryMethod
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChairCreator : FactoryMethod
    {
        public override Product CreateProduct()
        {
            var chair = new Chair("A chair created by the chair creator");
            return chair;
        }
    }
}
