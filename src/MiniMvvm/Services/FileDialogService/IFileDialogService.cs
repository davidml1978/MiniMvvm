namespace MiniMvvm.Services
{
    public interface IFileDialogService
    {
        #region Public Propriedades

        bool AddExtension { get; set; }
        bool CheckFileExists { get; set; }
        bool CheckPathExists { get; set; }
        string DefaultExt { get; set; }
        string FileName { get; set; }
        string[] FileNames { get; }
        string Filter { get; set; }
        int FilterIndex { get; set; }
        string InitialDirectory { get; set; }
        bool RestoreDirectory { get; set; }
        string SafeFileName { get; }
        string[] SafeFileNames { get; }
        string Title { get; set; }
        bool ValidateNames { get; set; }

        #endregion Public Propriedades

        #region Public Métodos

        bool? ShowDialog();

        #endregion Public Métodos
    }
}