﻿using System.Collections.Generic;
using System.Threading.Tasks;

using Azure.ResourceManager.Dns;
using Azure.ResourceManager.Resources;

namespace ContainerApps.Acmebot.Internal;

internal static class AzureSdkExtensions
{
    public static async Task<IReadOnlyList<DnsZoneResource>> ListAllDnsZonesAsync(this SubscriptionResource subscription)
    {
        var dnsZones = new List<DnsZoneResource>();

        var result = subscription.GetDnsZonesByDnszoneAsync();

        await foreach (var dnsZone in result)
        {
            dnsZones.Add(dnsZone);
        }

        return dnsZones;
    }
}
