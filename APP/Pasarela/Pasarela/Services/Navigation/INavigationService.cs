using Pasarela.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace Pasarela.Services
{
    public interface INavigationService
    {
		ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();

        Task NavigateBack(bool Animated = false);
    }
}