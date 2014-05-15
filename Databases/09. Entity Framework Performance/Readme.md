## Entity Framework Performance

1. Using Entity Framework write a SQL query to select all employees from the Telerik Academy database and later print their name, department and town. Try the both variants: with and without .Include(…). Compare the number of executed SQL statements and the performance.
* Using Entity Framework write a query that selects all employees from the Telerik Academy database, then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their towns, then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same in more optimized way and compare the performance.
