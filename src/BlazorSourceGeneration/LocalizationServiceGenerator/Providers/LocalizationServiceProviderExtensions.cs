﻿using System.Collections.Immutable;
using BlazorSourceGeneration.LocalizationServiceGenerator.Models;
using Microsoft.CodeAnalysis;

namespace BlazorSourceGeneration.LocalizationServiceGenerator.Providers;

internal static class LocalizationServiceProviderExtensions
{
    public static IncrementalValuesProvider<(LocalizationService Service, Resource? Resource)> AddResources(
        this IncrementalValuesProvider<LocalizationService> provider,
        IncrementalValueProvider<ImmutableArray<Resource>> resourceProvider)
        => provider.Combine(resourceProvider)
            .Select((serviceAndResources, cancellationToken) =>
            {
                var (service, resources) = serviceAndResources;

                var resource = resources.FirstOrDefault(
                    f => f.Path.EndsWith(service.ResourceFilename));

                return (service, resource);
            });
}
