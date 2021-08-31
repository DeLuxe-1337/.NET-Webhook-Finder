using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace NETWebhookFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(".NET Webhook finder by DeLuxe");
            Console.Title = ".NET Webhook finder by DeLuxe";
            Console.ResetColor();

            string Path = string.Empty;
            if(args.Length >= 1)
                Path = args[0];
            else
                Path = Console.ReadLine();

            ModuleContext modCtx = ModuleDef.CreateModuleContext();
            ModuleDefMD module = ModuleDefMD.Load(Path.Replace("\"", ""), modCtx);

            Console.WriteLine($"\nModule Name: {module.Name}\n");

            foreach (TypeDef type in module.Types)
            {
                if (type.IsGlobalModuleType || type.Name == "Resources" || type.Name == "Settings")
                    continue;

                foreach (MethodDef method in type.Methods)
                {
                    if (!method.HasBody)
                        continue;

                    method.Body.KeepOldMaxStack = true;

                    foreach(var op in method.Body.Instructions)
                    {
                        if(op.OpCode == OpCodes.Ldstr)
                        {
                            string str = op.Operand.ToString();
                            if (str.Contains("https://discord.com/"))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"Discord webhook found: {str}");
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
