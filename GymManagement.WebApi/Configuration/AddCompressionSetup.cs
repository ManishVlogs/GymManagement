﻿using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace GymManagement.WebApi.Configuration
{
    public static class CompressionSetup
    {
        public static IServiceCollection AddCompressionSetup(this IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                //options.EnableForHttps = true;
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
                options.Level = CompressionLevel.Fastest
            );

            services.Configure<GzipCompressionProviderOptions>(options =>
                options.Level = CompressionLevel.Fastest
            );

            return services;
        }
    }
}
