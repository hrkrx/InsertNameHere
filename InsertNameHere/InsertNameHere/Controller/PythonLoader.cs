using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace InsertNameHere.Controller
{
    public class PythonLoader
    {
        ScriptEngine engine = Python.CreateEngine();
        public dynamic RunScript(string path, string method, string[] parameters)
        {
            string script = File.ReadAllText(path);
            var scope = engine.CreateScope();
            var source = engine.CreateScriptSourceFromString(script, SourceCodeKind.Statements);
            var compiled = source.Compile();
            var result = compiled.Execute(scope);
            return result;
        }
    }
}
