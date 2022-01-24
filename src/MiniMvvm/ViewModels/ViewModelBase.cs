using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BasicMiniMvvm.ViewModels
{
    /// <summary>
    /// ModelViewBase
    /// </summary>
    [Serializable]
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Eventos

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Public Eventos

        #region Protected Métodos

        /// <summary>
        /// RaisePropertyChanged
        /// </summary>
        /// <param name="propertyName">propertyName</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// SetField
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                RaisePropertyChanged(propertyName);
                return true;
            }
            return false;
        }

        #endregion Protected Métodos
    }
}