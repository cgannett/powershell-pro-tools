﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PowerShellTools.DebugEngine {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PowerShellTools.DebugEngine.ResourceStrings", typeof(ResourceStrings).Assembly);
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
        ///   Looks up a localized string similar to {0} should have at least one element..
        /// </summary>
        internal static string ChoicesCollectionShouldHaveAtLeastOneElement {
            get {
                return ResourceManager.GetString("ChoicesCollectionShouldHaveAtLeastOneElement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PowerShell Debug Engine.
        /// </summary>
        internal static string EngineName {
            get {
                return ResourceManager.GetString("EngineName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PowerShell Debug Port.
        /// </summary>
        internal static string PortName {
            get {
                return ResourceManager.GetString("PortName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PowerShell Debug Port Supplier.
        /// </summary>
        internal static string PortSupplierName {
            get {
                return ResourceManager.GetString("PortSupplierName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} - {1}.
        /// </summary>
        internal static string ProgressBarFormat {
            get {
                return ResourceManager.GetString("ProgressBarFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PowerShell.
        /// </summary>
        internal static string PromptForChoice_DefaultCaption {
            get {
                return ResourceManager.GetString("PromptForChoice_DefaultCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Windows PowerShell Credential Request.
        /// </summary>
        internal static string PromptForCredential_DefaultCaption {
            get {
                return ResourceManager.GetString("PromptForCredential_DefaultCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your credentials..
        /// </summary>
        internal static string PromptForCredential_DefaultMessage {
            get {
                return ResourceManager.GetString("PromptForCredential_DefaultMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your credentials..
        /// </summary>
        internal static string PromptForCredential_DefaultTarget {
            get {
                return ResourceManager.GetString("PromptForCredential_DefaultTarget", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length of the caption should be less than {0}..
        /// </summary>
        internal static string PromptForCredential_InvalidCaption {
            get {
                return ResourceManager.GetString("PromptForCredential_InvalidCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length of the message should be less than {0}..
        /// </summary>
        internal static string PromptForCredential_InvalidMessage {
            get {
                return ResourceManager.GetString("PromptForCredential_InvalidMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length of the UserName should be less than {0}..
        /// </summary>
        internal static string PromptForCredential_InvalidUserName {
            get {
                return ResourceManager.GetString("PromptForCredential_InvalidUserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DEBUG:{0}.
        /// </summary>
        internal static string PS_Debug {
            get {
                return ResourceManager.GetString("PS_Debug", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VERBOSE: {0}.
        /// </summary>
        internal static string PS_Verbose {
            get {
                return ResourceManager.GetString("PS_Verbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to WARNING: {0}.
        /// </summary>
        internal static string PS_Warning {
            get {
                return ResourceManager.GetString("PS_Warning", resourceCulture);
            }
        }
    }
}