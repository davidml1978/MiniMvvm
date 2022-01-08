namespace MiniMvvm.Services
{
    /// <summary>
    /// IMessageDialogService interface
    /// </summary>
    public interface IMessageDialogService
    {
        #region Public Métodos

        /// <summary>
        /// Shows the specified message text.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <returns></returns>
        MessageDialogResult Show(string messageText);

        /// <summary>
        /// Shows the specified message text.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="button">The button.</param>
        /// <returns></returns>
        MessageDialogResult Show(string messageText, string caption, MessageDialogButton button);

        #endregion Public Métodos
    }
}