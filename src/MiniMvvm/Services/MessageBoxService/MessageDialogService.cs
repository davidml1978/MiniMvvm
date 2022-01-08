using System.Windows;

namespace MiniMvvm.Services
{
    /// <summary>
    /// Class that manage MessageBox 
    /// </summary>
    /// <seealso cref="MiniMvvm.Services.IMessageDialogService" />
    public class MessageDialogService : IMessageDialogService
    {
        #region Public Métodos

        /// <summary>
        /// Shows the MessageBox.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <returns>MessageDialogResult</returns>
        public MessageDialogResult Show(string messageText)
        {
            MessageBox.Show(messageText);
            return MessageDialogResult.OK;
        }

        /// <summary>
        /// Shows the MessageBox.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="button">The button.</param>
        /// <returns>MessageDialogResult</returns>
        public MessageDialogResult Show(string messageText, string caption, MessageDialogButton button)
        {
            return MessageBoxToDialogResult(MessageBox.Show(messageText, caption, DialogToMessageBoxButton(button)));
        }

        #endregion Public Métodos

        #region Private Métodos

        private static MessageBoxButton DialogToMessageBoxButton(MessageDialogButton dialogButton)
        {
            return (MessageBoxButton)dialogButton;
        }

        private static MessageDialogResult MessageBoxToDialogResult(MessageBoxResult messageBoxResult)
        {
            return (MessageDialogResult)messageBoxResult;
        }

        #endregion Private Métodos

        /// <summary>
        /// Shows the MessageBox.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <returns>MessageDialogResult</returns>
        public static MessageDialogResult ShowDialog(string messageText)
        {
            MessageBox.Show(messageText);
            return MessageDialogResult.OK;
        }

        /// <summary>
        /// Shows the MessageBox.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <param name="caption">The caption.</param>
        /// <param name="button">The button.</param>
        /// <returns>MessageDialogResult</returns>
        public static MessageDialogResult ShowDialog(string messageText, string caption, MessageDialogButton button)
        {
            return MessageBoxToDialogResult(MessageBox.Show(messageText, caption, DialogToMessageBoxButton(button)));
        }
    }
}