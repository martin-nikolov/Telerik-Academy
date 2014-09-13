using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class LinkedOut
{
    private static readonly IDictionary<string, User> users = new Dictionary<string, User>();
    private static readonly StringBuilder output = new StringBuilder();

    internal static void Main()
    {
        var rootUser = GetOrCreateUser(Console.ReadLine());
        ConnectUsers();
        InitializeConnectivityLevelsBfs(rootUser);
        GetConnectivityLevels();
        Console.WriteLine(output.ToString());
    }
 
    private static void ConnectUsers()
    {
        var numberOfConnections = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfConnections; i++)
        {
            var tuple = Console.ReadLine().Split(' ').ToArray();
            var firstUser = GetOrCreateUser(tuple[0]);
            var secondUser = GetOrCreateUser(tuple[1]);

            // Two-way connection
            firstUser.Successors.Add(secondUser);
            secondUser.Successors.Add(firstUser);
        }
    }
 
    private static void InitializeConnectivityLevelsBfs(User rootUser)
    {
        var visitedUsers = new HashSet<string>();
        var queue = new Queue<User>();
        queue.Enqueue(rootUser);

        while (queue.Count > 0)
        {
            var currentUser = queue.Dequeue();
            visitedUsers.Add(currentUser.Name);

            foreach (var child in currentUser.Successors)
            {
                if (visitedUsers.Contains(child.Name))
                {
                    continue;
                }

                child.ConnectivityLevel = currentUser.ConnectivityLevel + 1;
                visitedUsers.Add(child.Name);
                queue.Enqueue(child);
            }
        }
    }

    private static void GetConnectivityLevels()
    {
        var numberOfConnectivityToCheck = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfConnectivityToCheck; i++)
        {
            var username = Console.ReadLine();
            var user = GetOrCreateUser(username);
            if (user.ConnectivityLevel == 0)
            {
                output.AppendLine("-1");
            }
            else
            {
                output.AppendLine(user.ConnectivityLevel.ToString());
            }
        }
    }

    private static User GetOrCreateUser(string name)
    {
        User user;
        users.TryGetValue(name, out user);

        if (user == null)
        {
            user = new User(name);
            users[name] = user;
        }

        return user;
    }
}

public class User
{
    public User(string name)
    {
        this.Name = name;
        this.Successors = new HashSet<User>();
    }

    public string Name { get; set; }

    public int ConnectivityLevel { get; set; }

    public ICollection<User> Successors { get; set; }
}