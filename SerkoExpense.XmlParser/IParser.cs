namespace SerkoExpense.Parser
{
    /// <summary>
    /// Interface: IParser
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the specified text content.
        /// </summary>
        /// <param name="textContent">Content of the text.</param>
        /// <returns>ParserResponse</returns>
        ParserResponse Parse(string textContent);
    }
}
