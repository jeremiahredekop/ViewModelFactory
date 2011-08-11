using GeniusCode.Components.Mvvm;

namespace ViewModelFactory.ViewModel.Factories
{
    [InstanceBehavior(ShareInstancesMode.Shared)]
    public class MainViewwModelFactory :
        AbstractViewModelFactory<MainViewModel>
    {

        protected override void OnViewModelAcquired(MainViewModel vm)
        {
            if (DetectDesignMode())
                vm.Welcome = "Hello at DesignTime from MainViewModel";
            else
                vm.Welcome = "Hello at Runtime from MainViewModel";

            vm.ViewCount++;
        }

        protected override MainViewModel BuildViewModel()
        {
            return new MainViewModel();
        }
    }
}
