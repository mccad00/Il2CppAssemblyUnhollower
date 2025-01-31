using System.IO;
using System.Linq;
using AssemblyUnhollower.Contexts;
using AssemblyUnhollower.Utils;
using Mono.Cecil;
using UnhollowerBaseLib;

namespace AssemblyUnhollower.Passes
{
    public static class Pass80UnstripFields
    {
        public static void DoPass(RewriteGlobalContext context)
        {
            int fieldsUnstripped = 0;
            int fieldsIgnored = 0;
            
            foreach (var unityAssembly in context.UnityAssemblies.Assemblies)
            {
                var processedAssembly = context.TryGetAssemblyByName(unityAssembly.Name.Name);
                if (processedAssembly == null) continue;
                var imports = processedAssembly.Imports;
                
                foreach (var unityType in unityAssembly.MainModule.Types)
                {
                    var processedType = processedAssembly.TryGetTypeByName(unityType.FullName);
                    if (processedType == null) continue;

                    if (!unityType.IsValueType || unityType.IsEnum)
                        continue;

                    foreach (var unityField in unityType.Fields)
                    {
                        if (unityField.IsStatic && !unityField.HasConstant) continue;
                        if (processedType.NewType.IsExplicitLayout && !unityField.IsStatic) continue;

                        var processedField = processedType.TryGetFieldByUnityAssemblyField(unityField);
                        if (processedField != null) continue;

                        var fieldType = Pass80UnstripMethods.ResolveTypeInNewAssemblies(context, unityField.FieldType, imports);
                        if (fieldType == null)
                        {
                            LogSupport.Trace($"Field {unityField} on type {unityType.FullName} has unsupported type {unityField.FieldType}, the type will be unusable");
                            fieldsIgnored++;
                            continue;
                        }

                        var newField = new FieldDefinition(unityField.Name, unityField.Attributes & ~FieldAttributes.FieldAccessMask | FieldAttributes.Public, fieldType);

                        if (unityField.HasConstant)
                        {
                            newField.Constant = unityField.Constant;
                        }

                        processedType.NewType.Fields.Add(newField);

                        fieldsUnstripped++;
                    }
                }
            }
            
            LogSupport.Info(""); // finish the progress line
            LogSupport.Info($"{fieldsUnstripped} fields restored");
            LogSupport.Info($"{fieldsIgnored} fields failed to restore");
        }
    }
}