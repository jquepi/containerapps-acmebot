﻿using System;
using System.Collections.Generic;

using Azure.ResourceManager;

namespace ContainerApps.Acmebot.Internal;

public class AzureEnvironment
{
    public Uri ActiveDirectory { get; init; }
    public ArmEnvironment ResourceManager { get; init; }

    public static AzureEnvironment Get(string name) => s_environments[name];

    private static readonly Dictionary<string, AzureEnvironment> s_environments = new()
    {
        {
            "AzureCloud",
            new AzureEnvironment
            {
                ActiveDirectory = new Uri("https://login.microsoftonline.com"),
                ResourceManager = ArmEnvironment.AzurePublicCloud
            }
        },
        {
            "AzureChinaCloud",
            new AzureEnvironment
            {
                ActiveDirectory = new Uri("https://login.chinacloudapi.cn"),
                ResourceManager = ArmEnvironment.AzureChina
            }
        },
        {
            "AzureUSGovernment",
            new AzureEnvironment
            {
                ActiveDirectory = new Uri("https://login.microsoftonline.us"),
                ResourceManager = ArmEnvironment.AzureGovernment
            }
        }
    };
}
