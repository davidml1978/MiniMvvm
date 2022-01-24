using System;
using System.Windows.Input;

namespace BasicMiniMvvm.Commands
{
    /// <summary>
    /// Implementation of ICommand interface
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        #region Private Campos

        private Func<bool> targetCanExecuteMethod;
        private Action targetExecuteMethod;

        #endregion Private Campos

        #region Public Construtoras

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="targetExecuteMethod">The target execute method.</param>
        public RelayCommand(Action targetExecuteMethod)
        {
            this.targetExecuteMethod = targetExecuteMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="targetExecuteMethod">The target execute method.</param>
        /// <param name="targetCanExecuteMethod">The target can execute method.</param>
        public RelayCommand(Action targetExecuteMethod, Func<bool> targetCanExecuteMethod) : this(targetExecuteMethod)
        {
            this.targetCanExecuteMethod = targetCanExecuteMethod;
        }

        #endregion Public Construtoras

        #region Public Eventos        
        /// <summary>
        /// Occurs when [can execute changed].
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        #endregion Public Eventos

        #region Public Métodos

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
                return targetCanExecuteMethod();
            if (targetExecuteMethod != null)
                return true;
            return false;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            if (targetExecuteMethod != null)
                targetExecuteMethod();
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #endregion Public Métodos
    }

    /// <summary>
    /// Implementation of ICommand interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand<T> : ICommand
    {
        #region Private Campos

        private Func<T, bool> targetCanExecuteMethod;
        private Action<T> targetExecuteMethod;

        #endregion Private Campos

        #region Public Construtoras

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="targetExecuteMethod">The target execute method.</param>
        public RelayCommand(Action<T> targetExecuteMethod)
        {
            this.targetExecuteMethod = targetExecuteMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
        /// </summary>
        /// <param name="targetExecuteMethod">The target execute method.</param>
        /// <param name="targetCanExecuteMethod">The target can execute method.</param>
        public RelayCommand(Action<T> targetExecuteMethod, Func<T, bool> targetCanExecuteMethod) : this(targetExecuteMethod)
        {
            this.targetCanExecuteMethod = targetCanExecuteMethod;
        }

        #endregion Public Construtoras

        #region Public Eventos

        /// <summary>
        /// Occurs when [can execute changed].
        /// </summary>
        public event EventHandler CanExecuteChanged = delegate { };

        #endregion Public Eventos

        #region Public Métodos

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///   <c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (targetCanExecuteMethod != null)
            {
                T param = (T)parameter;
                return targetCanExecuteMethod(param);
            }
            if (targetExecuteMethod != null)
                return true;
            return false;
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            if (targetExecuteMethod != null)
                targetExecuteMethod((T)parameter)
                    ;
        }

        /// <summary>
        /// Raises the can execute changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #endregion Public Métodos
    }
}
