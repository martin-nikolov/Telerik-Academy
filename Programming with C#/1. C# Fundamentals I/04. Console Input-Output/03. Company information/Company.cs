using System;
using System.Linq;

class Company
{
    private CManager manager;

    private string name;
    private string address;
    private string phoneNumber;
    private string faxNumber;
    private string webSite;

    public Company() : this(null)
    {
    }

    public Company(string name) : this(name, null)
    {
    }

    public Company(string name, string address) : this(name, address, null)
    {
    }

    public Company(string name, string address, string phoneNumber) : this(name, address, phoneNumber, null)
    {
    }

    public Company(string name, string address, string phoneNumber, string faxNumber) : this(name, address, phoneNumber, faxNumber, null)
    {
    }

    public Company(string name, string address, string phoneNumber, string faxNumber, string webSite)
    {
        this.Name = name;
        this.Address = address;
        this.PhoneNumber = phoneNumber;
        this.FaxNumber = faxNumber;
        this.WebSite = webSite;
    }

    public CManager Manager
    {
        get { return this.manager; }
        set { this.manager = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public string Address
    {
        get { return this.address; }
        set { this.address = value; }
    }

    public string PhoneNumber
    {
        get { return this.phoneNumber; }
        set { this.phoneNumber = value; }
    }

    public string FaxNumber
    {
        get { return this.faxNumber; }
        set { this.faxNumber = value; }
    }

    public string WebSite
    {
        get { return this.webSite; }
        set { this.webSite = value; }
    }

    public void InputData()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\n\nEnter information about your company:\n");
        Console.ResetColor();

        Console.Write("Company name: ");
        this.Name = Console.ReadLine();

        Console.Write("Adress: ");
        this.Address = Console.ReadLine();

        Console.Write("Phone number: ");
        this.PhoneNumber = Console.ReadLine();

        Console.Write("Fax number: ");
        this.FaxNumber = Console.ReadLine();

        Console.Write("Website: ");
        this.WebSite = Console.ReadLine();
    }

    public void PrintInformation()
    {
        Console.WriteLine("\nInformation about \"{0}\" Company: ", name);
        if (name != null)
            Console.WriteLine("   Company name: {0}", name);
        if (address != null)
            Console.WriteLine("   Adress: {0}", address);
        if (phoneNumber != null)
            Console.WriteLine("   Phone Number: {0}", phoneNumber);
        if (faxNumber != null)
            Console.WriteLine("   Fax Number: {0}", faxNumber);
        if (webSite != null)
            Console.WriteLine("   Website: {0}", webSite);
    }

    public class CManager
    {
        private string firstName;
        private string lastName;
        private byte age;
        private string phoneNumber;

        public CManager() : this(null)
        {
        }

        public CManager(string firstName) : this(firstName, null)
        {
        }

        public CManager(string firstName, string lastName) : this(firstName, lastName, 0)
        {
        }

        public CManager(string firstName, string lastName, byte age) : this(firstName, lastName, 0, null)
        {
        }

        public CManager(string firstName, string lastName, byte age, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.PhoneNumber = phoneNumber;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public void InputData()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\nEnter information about company manager:\n");
            Console.ResetColor();

            Console.Write("First name: ");
            this.FirstName = Console.ReadLine();

            Console.Write("Last name: ");
            this.LastName = Console.ReadLine();

            Console.Write("Age: ");
            this.Age = byte.Parse(Console.ReadLine());

            Console.Write("Phone number: ");
            this.PhoneNumber = Console.ReadLine();
        }

        public void PrintInformation()
        {
            Console.WriteLine("\nInformation about company manager: ", firstName);
            if (this.firstName != null)
                Console.WriteLine("   Name: {0}", firstName, lastName);
            if (this.age != 0)
                Console.WriteLine("   Age: {0}", age);
            if (this.phoneNumber != null)
                Console.WriteLine("   Phone Number: {0}", phoneNumber);
        }
    }
}