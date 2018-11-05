using SerkoExpense.Common;

namespace SerkoExpense.Business
{
    /// <summary>
    /// interface: IService
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Imports the data.
        /// </summary>
        /// <param name="textInput">The text input.</param>
        /// <returns>ImportResponse</returns>
        ImportResponse ImportData(string textInput);
    }
}
