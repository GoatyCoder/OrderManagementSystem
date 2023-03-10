using OrderManagementSystem.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OrderManagementSystem.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IUnitOfWork unitOfWork;
        public ViewModelBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;
            storage = value;

            this.OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
