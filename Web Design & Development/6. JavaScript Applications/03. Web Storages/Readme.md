## Web Storages

1. Create a simple number guessing game
    * The computer generates a random number with four different digits
        * The leftmost digit must not be 0 (zero)
        * For simplicity called `abcd`
    * At each turn the player enters a four-digit number
        * For simplicity called `xyzw`
    * When the game ends:
        * Ask the player for a nickname
        * Save the nickname inside the localStorage
    * Implement a high-score list
    * `Sheep` means that a digit from `xyzw` is contained in `abcd`, but not on the same position
        * If two such digits exists, the sheep are 2
    * Ram means that a digit from `xyzw` is contained in `abcd` and it is on the same position
        * If two such digits exists, the rams are 2
    * The game continues until the player guesses the number `abcd`
        * i.e. has 4 rams
