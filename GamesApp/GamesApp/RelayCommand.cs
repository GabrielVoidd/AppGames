using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GamesApp
{
    public class RelayCommand : ICommand
    {
        private readonly Action action;
        private readonly Action<object> genericAction;
        private readonly Func<bool> canExecute;
        private Action<object, object> messageError;

        /// <summary>
        /// Raised when RaiseCanExecuteChanged is called.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        public RelayCommand()
        {

        }
        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="action">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action action, Func<bool> canExecute)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.action = action;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object> action, Func<bool> canExecute)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.genericAction = action;
            this.canExecute = canExecute;
        }

        public RelayCommand(Action<object, object> messageError)
        {
            this.messageError = messageError;
        }

        /// <summary>
        /// Determines whether this <see cref="RelayCommand"/> can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null ? true : this.canExecute();
        }

        /// <summary>
        /// Executes the <see cref="RelayCommand"/> on the current command target.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. If the command does not require data to be passed, this object can be set to null.
        /// </param>
        public virtual void Execute(object parameter)
        {
            if (this.genericAction != null)
            {
                this.genericAction(parameter);
            }
            else
            {
                this.action();
            }
        }

        /// <summary>
        /// Method used to raise the <see cref="CanExecuteChanged"/> event
        /// to indicate that the return value of the <see cref="CanExecute"/>
        /// method has changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
