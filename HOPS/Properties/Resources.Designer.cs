﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HOPS.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HOPS.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Color_logo_with_background {
            get {
                object obj = ResourceManager.GetObject("Color_logo_with_background", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Root&gt;
        ///	&lt;main text=&quot;Internals&quot;&gt;
        ///		&lt;sub text=&quot;Internal feeder numbering GRN&quot; conv=&quot;XXXX_Internal_feeder_GRN&quot; taken=&quot;Yes&quot;/&gt;
        ///		&lt;sub text=&quot;Internal feeder numbering Link&quot; conv=&quot;XXXX_Internal_feeder_numbeing_Link&quot; taken=&quot;Yes&quot;/&gt;
        ///		&lt;sub text=&quot;Internal feeder numbering XPOL&quot; conv=&quot;XXXX_Internal_feeder_Numbering_XPOL&quot; taken=&quot;Yes&quot;/&gt;
        ///		&lt;sub text=&quot;Lightning Surge Arrestor&quot; conv=&quot;XXXX_LSA_XPOL&quot; taken=&quot;Yes&quot;/&gt;
        ///		&lt;sub text=&quot;Lightning Surge Arrestor&quot; conv=&quot;XXXX_LSA_XPOL_P25&quot; ta [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string sub {
            get {
                return ResourceManager.GetString("sub", resourceCulture);
            }
        }
    }
}
