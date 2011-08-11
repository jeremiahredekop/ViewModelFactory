using GeniusCode.Components.Mvvm;

// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace WpfApplication1
{
    public class HomeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class HomeViewModelFactory : AbstractViewModelFactory<HomeViewModel>
    {
        protected override HomeViewModel BuildViewModel()
        {
            var vm = new HomeViewModel();

            if (DetectDesignMode())
            {
                vm.FirstName = "Jeremiah";
                vm.LastName = "Redekop";
            }
            else
            {
                vm.FirstName = "Ryan";
                vm.LastName = "Hatch";
            }

            return vm;
        }


    }
}
