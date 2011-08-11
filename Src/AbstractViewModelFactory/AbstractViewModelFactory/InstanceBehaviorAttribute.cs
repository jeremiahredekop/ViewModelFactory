using System;

namespace GeniusCode.Components.Mvvm
{
    public enum ShareInstancesMode
    {
        Shared = 1,
        NonShared
    }

    /// <summary>
    /// Designates a behavior to the factory class about whether or not instances should be shared or not
    /// </summary>
    public class InstanceBehaviorAttribute : Attribute
    {
        public InstanceBehaviorAttribute(ShareInstancesMode mode)
        {
            ShareInstances = mode == ShareInstancesMode.Shared;
        }

        public bool ShareInstances { get; set; }
    }
}
