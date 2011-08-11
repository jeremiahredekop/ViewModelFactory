using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusCode.Components.Mvvm
{
    public abstract class AbstractViewModelFactory<TViewModel>
    {

        #region Abstract Members
        protected abstract TViewModel BuildViewModel();
        #endregion

        #region Assets

        private readonly static Dictionary<Type, TViewModel> sharedInstances = new Dictionary<Type, TViewModel>();
        private readonly bool shareInstances;
        #endregion

        #region Constuctors
        public AbstractViewModelFactory()
        {

            var at2 = this.GetType().GetCustomAttributes<InstanceBehaviorAttribute>(true).SingleOrDefault();
            if (at2 != null)
                shareInstances = at2.ShareInstances;

        }
        #endregion

        #region Protected Members

        protected virtual bool DetectDesignMode()
        {
            return DesignHelpers.DesignMode;
        }

        /// <summary>
        /// Fires when ViewModel is created, or returned from the cache
        /// </summary>
        /// <param name="vm"></param>
        protected virtual void OnViewModelAcquired(TViewModel vm) { }

        #endregion

        #region Public Members
        public TViewModel ViewModel
        {
            get
            {
                return GetViewModelInstance();
            }
        }


        #endregion

        #region Helper Methods

        private TViewModel GetViewModelInstance()
        {
            TViewModel viewModel;
            bool wasCreated;

            if (shareInstances)
                viewModel = (TViewModel)sharedInstances.CreateOrGetValue(typeof(TViewModel), () => BuildViewModel(), out wasCreated);
            else
            {
                viewModel = BuildViewModel();
                wasCreated = true;
            }

            OnViewModelAcquired(viewModel);

            return viewModel;
        }

        #endregion

    }
}
