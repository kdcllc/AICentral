﻿using AICentral.Pipelines;
using AICentral.Pipelines.Auth;
using AICentral.Pipelines.Endpoints.AzureOpenAI;
using AICentral.Pipelines.EndpointSelectors;
using AICentral.Pipelines.RateLimiting;
using AICentral.Pipelines.Routes;

namespace AICentralTests;

public class AICentralTestEndpointBuilder
{
    public static AzureOpenAIEndpoint Random() =>
        new AzureOpenAIEndpoint(
            $"https://{Guid.NewGuid().ToString()}",
            Guid.NewGuid().ToString(),
            AzureOpenAIAuthenticationType.ApiKey,
            Guid.NewGuid().ToString());

    public static AICentralPipeline Build(
        IAICentralEndpointSelector endpointSelector,
        string path = "/deployments/test") => new(
        Guid.NewGuid().ToString(),
        new SimplePathMatchRouter(path),
        new NoRateLimitingProvider(),
        new NoClientAuthAuthProvider(),
        new List<IAICentralPipelineStep>(),
        endpointSelector
    );
}