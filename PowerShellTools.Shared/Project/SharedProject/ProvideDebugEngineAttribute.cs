﻿// Visual Studio Shared Project
// Copyright(c) Microsoft Corporation
// All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the License); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED ON AN  *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY
// IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
//
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

using System;
using System.IO;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudioTools {
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class ProvideDebugEngineAttribute : RegistrationAttribute {
        private readonly string _id, _name;
        private readonly bool _setNextStatement, _hitCountBp, _justMyCodeStepping;
        private readonly Type _programProvider, _debugEngine;

        public ProvideDebugEngineAttribute(string name, Type programProvider, Type debugEngine, string id, bool setNextStatement = true, bool hitCountBp = false, bool justMyCodeStepping = true) {
            _name = name;
            _programProvider = programProvider;
            _debugEngine = debugEngine;
            _id = id;
            _setNextStatement = setNextStatement;
            _hitCountBp = hitCountBp;
            _justMyCodeStepping = justMyCodeStepping;
        }

        public override void Register(RegistrationContext context) {
            var engineKey = context.CreateKey("AD7Metrics\\Engine\\" + _id);
            engineKey.SetValue("Name", _name);

            engineKey.SetValue("CLSID", _debugEngine.GUID.ToString("B"));
            engineKey.SetValue("ProgramProvider", _programProvider.GUID.ToString("B"));
            engineKey.SetValue("PortSupplier", "{708C1ECA-FF48-11D2-904F-00C04FA302A1}"); // {708C1ECA-FF48-11D2-904F-00C04FA302A1}

            engineKey.SetValue("Attach", 1);
            engineKey.SetValue("AddressBP", 0);
            engineKey.SetValue("AutoSelectPriority", 6);
            engineKey.SetValue("CallstackBP", 1);
            engineKey.SetValue("ConditionalBP", 1);
            engineKey.SetValue("Exceptions", 1);
            engineKey.SetValue("SetNextStatement", _setNextStatement ? 1 : 0);
            engineKey.SetValue("RemoteDebugging", 1);
            engineKey.SetValue("HitCountBP", _hitCountBp ? 1 : 0);
            engineKey.SetValue("JustMyCodeStepping", _justMyCodeStepping ? 1 : 0);
            //engineKey.SetValue("FunctionBP", 1); // TODO: Implement PythonLanguageInfo.ResolveName

            // provide class / assembly so we can be created remotely from the GAC w/o registering a CLSID 
            engineKey.SetValue("EngineClass", _debugEngine.FullName);
            engineKey.SetValue("EngineAssembly", _debugEngine.Assembly.FullName);

            // load locally so we don't need to create MSVSMon which would need to know how to
            // get at our provider type.  See AD7ProgramProvider.GetProviderProcessData for more info
            engineKey.SetValue("LoadProgramProviderUnderWOW64", 1);
            engineKey.SetValue("AlwaysLoadProgramProviderLocal", 1);
            engineKey.SetValue("LoadUnderWOW64", 1);

            using (var incompatKey = engineKey.CreateSubkey("IncompatibleList")) {
                // In VS 2013, mixed-mode debugging is supported with any engine that does not exclude us specifically
                // (everyone should be using the new debugging APIs that permit arbitrary mixing), except for the legacy
                // .NET 2.0/3.0/3.5 engine.
                //
                // In VS 2012, only native/Python mixing is supported - other stock engines are not updated yet, and
                // in particular throwing managed into the mix will cause the old native engine to be used.
                //
                // In VS 2010, mixed-mode debugging is not supported at all.
                incompatKey.SetValue("guidCOMPlusOnlyEng2", "{5FFF7536-0C87-462D-8FD2-7971D948E6DC}");
            }

            using (var autoSelectIncompatKey = engineKey.CreateSubkey("AutoSelectIncompatibleList")) {
                autoSelectIncompatKey.SetValue("guidNativeOnlyEng", "{3B476D35-A401-11D2-AAD4-00C04F990171}");
            }

            var clsidKey = context.CreateKey("CLSID");
            var clsidGuidKey = clsidKey.CreateSubkey(_debugEngine.GUID.ToString("B"));
            clsidGuidKey.SetValue("Assembly", _debugEngine.Assembly.FullName);
            clsidGuidKey.SetValue("Class", _debugEngine.FullName);
            clsidGuidKey.SetValue("InprocServer32", context.InprocServerPath);
            clsidGuidKey.SetValue("CodeBase", Path.Combine(context.ComponentPath, _debugEngine.Module.Name));
            clsidGuidKey.SetValue("ThreadingModel", "Free");

            clsidGuidKey = clsidKey.CreateSubkey(_programProvider.GUID.ToString("B"));
            clsidGuidKey.SetValue("Assembly", _programProvider.Assembly.FullName);
            clsidGuidKey.SetValue("Class", _programProvider.FullName);
            clsidGuidKey.SetValue("InprocServer32", context.InprocServerPath);
            clsidGuidKey.SetValue("CodeBase", Path.Combine(context.ComponentPath, _debugEngine.Module.Name));
            clsidGuidKey.SetValue("ThreadingModel", "Free");

            using (var exceptionAssistantKey = context.CreateKey("ExceptionAssistant\\KnownEngines\\" + _id)) {
                exceptionAssistantKey.SetValue("", _name);
            }
        }

        public override void Unregister(RegistrationContext context) {
        }
    }
}
