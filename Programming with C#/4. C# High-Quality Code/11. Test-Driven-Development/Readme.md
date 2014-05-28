## Test-Driven Development

Finish the `Poker` project given in the Visual Studio Solution "[homework.zip](https://github.com/flextry/Telerik-Academy/blob/master/Programming%20with%20C%23/4.%20C%23%20High-Quality%20Code/11.%20Test-Driven-Development/Test-Driven-Development-Demo-Homework.zip)" using TDD.

1. Write a class `Card` implementing the `ICard` interface. Implement the properties. Write a constructor. Implement the `ToString()` method. Test all cases.
* Write a class `Hand` implementing the `IHand` interface. Implement the properties. Write a constructor. Implement the `ToString()` method. Test all cases.
* Write a class `PokerHandsChecker` (+ tests) and start implementing the `IPokerHandsChecker` interface. Implement the `IsValidHand(IHand)`. A hand is valid when it consists of exactly 5 different cards.
* Implement `IPokerHandsChecker.IsFlush(IHand)` method. Follow the official poker rules from Wikipedia: [List of Poker Hands](http://en.wikipedia.org/wiki/List_of_poker_hands).
* Implement `IsFourOfAKind(IHand)` method. Did you test all the scenarios?
* \* Implement the other check for poker hands: `IsHighCard(IHand hand)`, `IsOnePair(IHand hand)`, `IsTwoPair(IHand hand)`, `IsThreeOfAKind(IHand hand)`, `IsFullHouse(IHand hand)`, `IsStraight(IHand hand)` and `IsStraightFlush(IHand hand)`. Did you test all the scenarios well?