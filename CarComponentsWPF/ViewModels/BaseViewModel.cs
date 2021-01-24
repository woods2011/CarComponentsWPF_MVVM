using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarComponentsWPF.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        protected BaseViewModel()
        {
            ErrorCollection = new Dictionary<string, string>();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify a property change
        /// </summary>
        /// <param name="propertyName">Name of property to update</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notify a property change that uses CallerMemberName attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingField">Backing field of property</param>
        /// <param name="value">Value to give backing field</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }



        #region Валидация

        public virtual bool IsValid
        {
            get => Validator.TryValidateObject(this, new ValidationContext(this), null, true);
        }

        public Dictionary<string, string> ErrorCollection { get; private set; }

        public virtual string Error
        {
            get
            {
                String result = String.Empty;

                foreach (var el in ErrorCollection)
                {
                    if (el.Value != null)
                        result += $"{el.Key} - {el.Value} \r\n";
                }

                if (result == String.Empty)
                    return null;

                return result;
            }
        }

        public virtual String this[string columnName]
        {
            get
            {
                //Console.WriteLine("Я тут");

                String result = null;
                var validationResults = new List<ValidationResult>();
                var property = GetType().GetProperty(columnName);
                var isValid = Validator.TryValidateProperty(property.GetValue(this), new ValidationContext(this) { MemberName = columnName }, validationResults);

                if (!isValid)
                    result = validationResults.First().ErrorMessage;

                if (ErrorCollection.ContainsKey(columnName))
                {
                    if (ErrorCollection[columnName] != result)
                    {
                        ErrorCollection[columnName] = result;
                        OnPropertyChanged("ErrorCollection");
                        OnPropertyChanged("Error");
                    }
                }
                else if (result != null)
                {
                    ErrorCollection.Add(columnName, result);
                    OnPropertyChanged("ErrorCollection");
                    OnPropertyChanged("Error");
                }

                return result;
            }
        }

        #endregion
    }
}
