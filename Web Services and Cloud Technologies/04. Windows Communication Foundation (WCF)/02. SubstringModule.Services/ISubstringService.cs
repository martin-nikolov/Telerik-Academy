namespace SubstringModule.Services
{
    using System;
    using System.Linq;
    using System.ServiceModel;

    [ServiceContract]
    public interface ISubstringService
    {
        [OperationContract]
        int GetNumberOfSubstrings(string text, string substring);
    }
}