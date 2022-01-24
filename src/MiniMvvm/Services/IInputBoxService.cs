namespace BasicMiniMvvm.Services
{
    /// <summary>
    /// IInputBoxService interface
    /// </summary>
    public interface IInputBoxService
    {
        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="title">The title.</param>
        /// <param name="defaultText">The default text.</param>
        /// <returns></returns>
        string ShowDialog(string prompt, string title = "", string defaultText = "");
    }
}