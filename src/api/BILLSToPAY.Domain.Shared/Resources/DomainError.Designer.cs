﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BILLSToPAY.Domain.Shared.Resources {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DomainError {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DomainError() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("BILLSToPAY.Domain.Shared.Resources.DomainError", typeof(DomainError).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string NameIsRequired {
            get {
                return ResourceManager.GetString("NameIsRequired", resourceCulture);
            }
        }
        
        public static string MaximumNameSize {
            get {
                return ResourceManager.GetString("MaximumNameSize", resourceCulture);
            }
        }
        
        public static string DueDateIsRequired {
            get {
                return ResourceManager.GetString("DueDateIsRequired", resourceCulture);
            }
        }
        
        public static string OriginalValueIsRequired {
            get {
                return ResourceManager.GetString("OriginalValueIsRequired", resourceCulture);
            }
        }
        
        public static string PaymentDateIsRequired {
            get {
                return ResourceManager.GetString("PaymentDateIsRequired", resourceCulture);
            }
        }
        
        public static string DaysIsRequired {
            get {
                return ResourceManager.GetString("DaysIsRequired", resourceCulture);
            }
        }
        
        public static string TypeIsRequired {
            get {
                return ResourceManager.GetString("TypeIsRequired", resourceCulture);
            }
        }
        
        public static string PenaltyIsRequired {
            get {
                return ResourceManager.GetString("PenaltyIsRequired", resourceCulture);
            }
        }
        
        public static string InterestPerDayIsRequired {
            get {
                return ResourceManager.GetString("InterestPerDayIsRequired", resourceCulture);
            }
        }
        
        public static string RuleNotFound {
            get {
                return ResourceManager.GetString("RuleNotFound", resourceCulture);
            }
        }
    }
}
