using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace InsertNameHere.Controller
{
    public class PythonLoader
    {
        private ScriptEngine engine;
        private ScriptScope scope;
        private ScriptSource source;
        private CompiledCode compiled;
        private object pythonClass;

        public PythonLoader(string code, string className = "PyClass")
        {
            //creating engine and stuff
            engine = Python.CreateEngine();
            scope = engine.CreateScope();

            //loading and compiling code
            source = engine.CreateScriptSourceFromString(code, Microsoft.Scripting.SourceCodeKind.Statements);
            compiled = source.Compile();
        }

        public void SetVariable(string variable, dynamic value)
        {
            scope.SetVariable(variable, value);
        }

        public dynamic GetVariable(string variable)
        {
            return scope.GetVariable(variable);
        }

        public void CallMethod(string method, params dynamic[] arguments)
        {
            engine.Operations.InvokeMember(pythonClass, method, arguments);
        }

        public dynamic CallFunction(string method, params dynamic[] arguments)
        {
            return engine.Operations.InvokeMember(pythonClass, method, arguments);
        }

        public dynamic Execute(Dictionary<string, dynamic> parameters = null)
        {
            Logger.Shoot("Start Executing PythonScript");
            if (parameters != null)
            {
                foreach (var item in parameters.Keys)
                {
                    Logger.Shoot("Variable " + item + " set to " + parameters[item].ToString());
                    scope.SetVariable(item, parameters[item]);
                }
            }
            DateTime dt = DateTime.Now;
            dynamic res = compiled.Execute(scope);
            long ms = (DateTime.Now.Ticks - dt.Ticks) / 1000;
            Logger.Shoot("Finished Executing Python (" + ms + "ms)");
            return res;
        }
    }
}
