﻿using System.Globalization;

namespace ContainerApps.Acmebot.Internal;

public static class Punycode
{
    private static readonly IdnMapping s_idnMapping = new();

    public static string Encode(string unicode) => s_idnMapping.GetAscii(unicode);
}
