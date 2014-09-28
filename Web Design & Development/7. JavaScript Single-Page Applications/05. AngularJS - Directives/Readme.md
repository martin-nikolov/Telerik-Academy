## Directives

1. Create AngularJS SPA client for the `Tic-Tac-Toe Web API project` used in the "Web Services and Cloud" course in lecture "Web API Architecture"
 * Use routing – for every single page
 * Use controllers – games, users, playing, etc.
 * Use services – restful usage, game logic, etc.
 * Use filters – for visualization of the bindings
 * Use directives – for domain specific parts of the HTML

### Run the projects in the following order:
  1. TicTacToe.ConsoleClient - create database + seed data in the database
  2. TicTacToe.Web - Web API Services - runs on port 4444
  3. TicTacToe.WebClient - Web API Services consumer - runs on port 5555

If the ports are different, change the url in TicTacToe.WebClient/scripts/services/ticTacToeData.js

__Change the Connection string -> TicTacToe.Common -> ConnectionStrings.cs__