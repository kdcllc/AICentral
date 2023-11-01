﻿using System.Net.Http.Headers;
using Azure.Core;
using Azure.Identity;

namespace AICentral.PipelineComponents.Endpoints.OpenAI;

public class EntraAuth : IEndpointAuthorisationHandler
{
    public async Task ApplyAuthorisationToRequest(HttpRequest incomingRequest,
        HttpRequestMessage outgoingRequest)
    {
        var token = (await new DefaultAzureCredential().GetTokenAsync(
            new TokenRequestContext(new[] { "https://cognitiveservices.azure.com" }))).Token;
        outgoingRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public object WriteDebug()
    {
        return new { Type = "Entra (Default Azure Credential)" };
    }
}