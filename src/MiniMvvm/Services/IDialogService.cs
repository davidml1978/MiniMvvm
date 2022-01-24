namespace BasicMiniMvvm.Services
{
    /// <summary>
    /// IDialogService interface
    /// </summary>
    /// <seealso cref="MiniMvvm.Services.IUserControlService" />
    public interface IDialogService : IUserControlService
    {
        #region Public Propriedades

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>
        /// The dialog result.
        /// </value>
        bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        string Title { get; set; }

        #endregion Public Propriedades

        #region Public Métodos

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();

        /// <summary>
        /// Shows this instance.
        /// </summary>
        void Show();

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns></returns>
        bool? ShowDialog();

        #endregion Public Métodos
    }
}