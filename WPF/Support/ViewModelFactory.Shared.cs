using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;


// This code is property of GeniusCode, LLC
// Licensed under MS-PL

namespace WpfApplication1
{

    public static class DesignHelpers
    {
        private static bool? _isInDesignMode;
        public static bool DesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
#if !SILVERLIGHT
                    _isInDesignMode = new bool?(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()));
#else
                _isInDesignMode = new bool?(DesignerProperties.IsInDesignTool);
#endif

                }
                return _isInDesignMode.Value;
            }
        }
    }

	public class ViewModelFactory<TViewModel>
		where TViewModel : new()
	{

		private bool shareInstances = false;
		public ViewModelFactory ()
	{

			var at2 = this.GetType().GetCustomAttributes<InstanceBehaviorAttribute>(true).SingleOrDefault();
			if (at2 != null)
				shareInstances = at2.ShareInstances;

	}


		private static Dictionary<Type,TViewModel> sharedInstances = new Dictionary<Type,TViewModel>();


        #region Protected Members

        protected virtual bool DetectDesignMode()
        {
            return DesignHelpers.DesignMode;
        }

        protected virtual void OnViewModelInitialized(TViewModel newInstance) {}

        
        protected virtual void OnViewLocatedAtRuntime(bool newInstance, TViewModel vm) {}
        protected virtual void OnViewModelLocatedAtDesignTime(TViewModel vm)
        {
        
        }
        #endregion

        public TViewModel ViewModel
        {
            get 
            {
                TViewModel viewModel;
                bool wasCreated;

                if (shareInstances)
                    viewModel = (TViewModel)sharedInstances.CreateOrGetValue(typeof(TViewModel),() => new TViewModel(), out wasCreated);
                else
                {
                    viewModel = new TViewModel();
                    wasCreated = true;
                }

                bool designMode = DetectDesignMode();

                if (designMode)                 
                       OnViewModelLocatedAtDesignTime(viewModel);
                else
                    OnViewLocatedAtRuntime(wasCreated,viewModel);


                OnViewModelInitialized(viewModel);

                return viewModel;
            }
        }

	}


}
