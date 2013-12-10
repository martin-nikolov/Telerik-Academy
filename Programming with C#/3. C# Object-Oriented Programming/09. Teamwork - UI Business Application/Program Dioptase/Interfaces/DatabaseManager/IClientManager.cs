using System;
using System.Collections.Generic;
using System.Linq;
using ProgramDioptase.ClientDescription;

namespace ProgramDioptase.Interfaces.DatabaseManager
{
    interface IClientManager
    {
        IList<Client> Clients { get; }
    }
}