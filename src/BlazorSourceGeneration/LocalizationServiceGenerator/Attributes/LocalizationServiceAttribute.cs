﻿namespace BlazorSourceGeneration.LocalizationServiceGenerator.Attributes;

internal static class LocalizationServiceAttribute
{
    public const string Name = "LocalizationServiceAttribute";

    public const string FullyQualifiedName = $"{Constants.Namespace}.{Name}";

    public const string FilePropertyName = "Filename";

    public const string FileCtorArgumentName = "filename";

    public const string SourceHint = $"{Name}.g.cs";

    public const string Source =
        $$"""
        // <auto-generated/>

        #nullable enable
        
        namespace {{Constants.Namespace}};

        [global::System.AttributeUsage(global::System.AttributeTargets.Class)]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("{{Constants.Namespace}}", "1.0.0")]
        internal sealed class {{Name}}(string {{FileCtorArgumentName}}) : global::System.Attribute
        {
            public string {{FilePropertyName}} { get; set; } = {{FileCtorArgumentName}};
        }
        """;
}
