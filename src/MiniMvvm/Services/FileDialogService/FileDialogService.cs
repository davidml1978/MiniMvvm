using Microsoft.Win32;

namespace MiniMvvm.Services
{
    public abstract class FileDialogService : IFileDialogService
    {
        #region Private Campos

        private FileDialog dlg;

        #endregion Private Campos

        #region Public Construtoras

        public FileDialogService(FileDialog dialog)
        {
            dlg = dialog;
        }

        #endregion Public Construtoras

        #region Public Propriedades

        public bool AddExtension { get => dlg.AddExtension; set => dlg.AddExtension = value; }
        public bool CheckFileExists { get => dlg.CheckFileExists; set => dlg.CheckFileExists = value; }
        public bool CheckPathExists { get => dlg.CheckPathExists; set => dlg.CheckPathExists = value; }
        public string DefaultExt { get => dlg.DefaultExt; set => dlg.DefaultExt = value; }
        public string FileName { get => dlg.FileName; set => dlg.FileName = value; }
        public string Filter { get => dlg.Filter; set => dlg.Filter = value; }
        public int FilterIndex { get => dlg.FilterIndex; set => dlg.FilterIndex = value; }
        public string InitialDirectory { get => dlg.InitialDirectory; set => dlg.InitialDirectory = value; }
        public bool RestoreDirectory { get => dlg.RestoreDirectory; set => dlg.RestoreDirectory = value; }
        public string Title { get => dlg.Title; set => dlg.Title = value; }
        public bool ValidateNames { get => dlg.ValidateNames; set => dlg.ValidateNames = value; }
        public string[] FileNames => dlg.FileNames;
        public string SafeFileName => dlg.SafeFileName;
        public string[] SafeFileNames => dlg.SafeFileNames;

        #endregion Public Propriedades

        #region Public Métodos

        public bool? ShowDialog()
        {
            return dlg.ShowDialog();
        }

        #endregion Public Métodos
    }
}