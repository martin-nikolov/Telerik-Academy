## Control Flow, Conditional Statements and Loops

1. Refactor the following class using best practices for organizing straight-line code:

    ```c#
    public void Cook()
    public class Chef
    {
        private Bowl GetBowl()
        {
            //...
        }
        private Carrot GetCarrot()
        {
            //...
        }
        private void Cut(Vegetable potato)
        {
            //...
        public void Cook()
        {
            Potato potato = GetPotato();
            Carrot carrot = GetCarrot();
            Bowl bowl;
            Peel(potato);

            Peel(carrot);
            bowl = GetBowl();
            Cut(potato);
            Cut(carrot);
            bowl.Add(carrot);

            bowl.Add(potato);
        }
        private Potato GetPotato()
        {
            //...
        }
    }
    ```
* Refactor the following if statements:

    ```c#
    Potato potato;
    //...
    if (potato != null)
        if(!potato.HasNotBeenPeeled && !potato.IsRotten)
            Cook(potato);
    ```

    ```c#
    if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
    {
       VisitCell();
    }
    ```
* Refactor the following loop:

    ```c#
    int i=0;
    for (i = 0; i < 100;)
    {
        if (i % 10 == 0)
        {
        Console.WriteLine(array[i]);
        if ( array[i] == expectedValue )
        {
           i = 666;
        }
        i++;
        }
        else
        {
            Console.WriteLine(array[i]);
        i++;
        }
    }
    // More code here
    if (i == 666)
    {
        Console.WriteLine("Value Found");
    }
    ```
