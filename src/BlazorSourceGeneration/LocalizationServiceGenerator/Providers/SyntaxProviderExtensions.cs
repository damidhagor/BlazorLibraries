using BlazorSourceGeneration.LocalizationServiceGenerator.Attributes;
using BlazorSourceGeneration.LocalizationServiceGenerator.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BlazorSourceGeneration.LocalizationServiceGenerator.Providers;

internal static class SyntaxProviderExtensions
{
    public static IncrementalValuesProvider<LocalizationService> GetServices(this SyntaxValueProvider provider)
        => provider
            .ForAttributeWithMetadataName(
                LocalizationServiceAttribute.FullyQualifiedName,
                static (syntaxNode, cancellationToken) =>
                {
                    return syntaxNode is ClassDeclarationSyntax @class
                        && @class.Modifiers.Any(SyntaxKind.PartialKeyword);
                },
                static (syntaxContext, cancellationToken) =>
                {
                    var resourceFilename = syntaxContext
                        .Attributes[0]
                        .ConstructorArguments[0]
                        .Value as string;

                    var @class = syntaxContext.TargetSymbol;

                    var @namespace = @class.ContainingNamespace is not null
                                 && !@class.ContainingNamespace.IsGlobalNamespace
                        ? @class.ContainingNamespace.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted))
                        : null;

                    var name = @class.Name;

                    return new LocalizationService(name, @namespace, resourceFilename);
                });
}
