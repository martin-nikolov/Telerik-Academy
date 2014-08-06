namespace Computers.Models.Contracts
{
    public interface IMotherboard
    {
        /// <summary>
        /// Takes and returns the last saved integer value from the Ram Memory.
        /// </summary>
        /// <returns>An integer taken from the Ram Memory</returns>
        int LoadRamValue();

        /// <summary>
        /// Save a giver integer value to the Ram Memory as replaced the old one.
        /// </summary>
        /// <param name="value">An integer to save in the Ram Memory</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Respond a request to the video card to draw a given data represented as text.
        /// </summary>
        /// <param name="data">The data represented as text to draw on the video card</param>
        void DrawOnVideoCard(string data);
    }
}