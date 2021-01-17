﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarComponentsWPF.Commands
{
    public sealed class ActionCommand : ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> delegate to wrap.</param>
        public ActionCommand(Action<Object> action) : this(action, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> delegate to wrap.</param>
        /// <param name="predicate">The <see cref="Predicate{Object}"/> that determines whether the action delegate may be invoked.</param>
        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action", "You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public bool CanExecute(object parameter)
        {
            if (predicate == null)
            {
                return true;
            }
            return predicate(parameter);
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            action(parameter);
        }

        /// <summary>
        /// Executes the action delegate without any parameters.
        /// </summary>
        public void Execute()
        {
            Execute(null);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
