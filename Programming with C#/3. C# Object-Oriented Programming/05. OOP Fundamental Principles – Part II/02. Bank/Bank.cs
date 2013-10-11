using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Bank
{
    private readonly List<Account> accounts = new List<Account>();

    public Bank(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }

    public Bank AddAccount(params Account[] accounts)
    {
        foreach (var account in accounts)
            this.accounts.Add(account);

        return this;
    }

    public Bank RemoveAccount(Account account)
    {
        this.accounts.Remove(account);

        return this;
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(string.Format("Bank: {0}\n", this.Name));

        foreach (Account account in this.accounts)
            info.AppendLine(account.ToString());

        return info.ToString();
    }
}