using System;
using System.Linq;
using System.Reflection;

namespace MvvmNext.Helpers
{
    /// <summary>
    /// Helper class for platform detection.
    /// </summary>
    internal static class DesignerLibrary
    {
        internal static DesignerPlatformLibrary DetectedDesignerLibrary
        {
            get
            {
                if(_detectedDesignerPlatformLibrary == null)
                {
                    _detectedDesignerPlatformLibrary = GetCurrentPlatform();
                }
                return _detectedDesignerPlatformLibrary.Value;
            }
        }

        private static DesignerPlatformLibrary GetCurrentPlatform()
        {
            // Check .NET 
            var cmdm = Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            if (cmdm != null) // loaded the assembly, could be .net 
            {
                return DesignerPlatformLibrary.Net;
            }

            return DesignerPlatformLibrary.Other;
        }


        private static DesignerPlatformLibrary? _detectedDesignerPlatformLibrary;

        private static bool? _isInDesignMode;

        public static bool IsInDesignMode
        {
            get
            {
                if (!_isInDesignMode.HasValue)
                {
                    var prop = System.ComponentModel.DesignerProperties.IsInDesignModeProperty;
                    _isInDesignMode
                        = (bool)System.ComponentModel.DependencyPropertyDescriptor
                                        .FromProperty(prop, typeof(System.Windows.FrameworkElement))
                                        .Metadata.DefaultValue;
                }

                return _isInDesignMode.Value;
            }
        }
    }

    internal enum DesignerPlatformLibrary
    {
        Unknown,
        Net,
        Other
    }
}
