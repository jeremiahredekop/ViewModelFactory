using System.ComponentModel;

namespace GeniusCode.Components.Mvvm
{
    internal static class DesignHelpers
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
}
