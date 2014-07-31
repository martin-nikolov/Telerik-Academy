namespace Flyweight
{
    using System.Collections.Generic;

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    internal class CharacterFactory
    {
        private readonly Dictionary<char, Character> characters = new Dictionary<char, Character>();

        public Character GetCharacter(char key)
        {
            // Uses "lazy initialization"
            Character character = null;
            if (this.characters.ContainsKey(key))
            {
                character = this.characters[key];
            }
            else
            {
                switch (key)
                {
                    case 'A':
                        character = new CharacterA();
                        break;
                    case 'B':
                        character = new CharacterB();
                        break;

                    case 'Z':
                        character = new CharacterZ();
                        break;
                }

                this.characters.Add(key, character);
            }

            return character;
        }
    }
}
