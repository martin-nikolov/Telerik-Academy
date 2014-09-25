## Building a Server Application with WebAPI

1. Finish the GameResult to determine the winner (unit test it well)
2. Create two more services by your choice - it may be some leaderboards, game options, game passwords, etc.
3. Write a client by your choice providing you the Tic Tac Toe game for two players - it may be JavaScript, Console, Mobile, etc.

### Run the projects in the following order:
  1. TicTacToe.ConsoleClient - create database + seed data in the database
  2. TicTacToe.Web - Web API Services - runs on port 4444
  3. TicTacToe.WebClient - Web API Services consumer - runs on port 5555

__Change the Connection string -> TicTacToe.Common -> ConnectionStrings.cs__