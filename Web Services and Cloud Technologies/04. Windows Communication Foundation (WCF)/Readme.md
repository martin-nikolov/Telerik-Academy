## Windows Communication Foundation (WCF)

1. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string. Test it with the integrated WCF client.
2. Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
3. Create a Web service library which accepts two string as parameters. It should return the number of times the second string contains the first string. Test it with the integrated WCF client.
4. Host the latter service in IIS.
5. Create a console client for the WCF service above. Use the `svcutil.exe` tool to generate the proxy classes.
