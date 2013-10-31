using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public interface IObjectProducer
    {
        IEnumerable<GameObject> ProduceObjects();
    }
}