﻿using System;
using Abp.Extensions;

namespace Bamanna.DouDian.DouDianClient
{
    public static class DouDianUrlConfig
    {
        private const string DefaultHostUrl = "http://localhost:22742/"; //TODO: Replace with PROD url.

        public static string BaseUrl { get; private set; }

        static DouDianUrlConfig()
        {
            ResetBaseUrl();
        }

        public static void ChangeBaseUrl(string baseUrl)
        {
            BaseUrl = ReplaceLocalhost(NormalizeUrl(baseUrl));
        }

        public static void ResetBaseUrl()
        {
            BaseUrl = ReplaceLocalhost(DefaultHostUrl);
        }

        public static bool IsLocal => DefaultHostUrl.Contains("localhost");

        private static string NormalizeUrl(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var uriResult) || 
                (uriResult.Scheme != "http" && uriResult.Scheme != "https"))
            {
                throw new ArgumentException("Unexpected base URL: " + baseUrl);
            }

            return uriResult.ToString().EnsureEndsWith('/');
        }

        private static string ReplaceLocalhost(string url)
        {
            return url.Replace("localhost", DebugServerIpAddresses.Current);
        }
    }
}