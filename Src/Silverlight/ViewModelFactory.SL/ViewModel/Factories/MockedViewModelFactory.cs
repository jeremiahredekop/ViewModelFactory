using GeniusCode.Components.DynamicDuck;
using GeniusCode.Components.Mvvm;

namespace ViewModelFactory.ViewModel.Factories
{
    public class MockedViewModelFactory :
            AbstractViewModelFactory<IViewModelContract>
    {
        protected override IViewModelContract BuildViewModel()
        {
            return ProxyFactory.MockInterface<IViewModelContract>();
        }

        protected override void OnViewModelAcquired(IViewModelContract vm)
        {
            vm.Message = "Hello from :" + vm.GetType().Name;
            vm.ViewCount++;
        }
    }
}
