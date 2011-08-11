using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace WpfApplication1
{
    public class HomeViewModel
    {
            public string FirstName{get;set;}
            public string LastName {get;set;}
    }

    public class HomeViewModelFactory : ViewModelFactory<HomeViewModel>
    {
        protected override void OnViewLocatedAtRuntime(bool newInstance, HomeViewModel vm)
        {
            vm.FirstName = "Jeremiah";
            vm.LastName = "Redekop";
        }

        protected override void OnViewModelLocatedAtDesignTime(HomeViewModel vm)
        {
            vm.FirstName = "Ryan";
            vm.LastName = "Hatch";
        }
    }
}
