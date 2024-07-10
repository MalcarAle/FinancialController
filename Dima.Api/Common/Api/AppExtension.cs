﻿namespace Dima.Api.Common.Api
{
    public static class AppExtension
    {
        public static void ConfigureDevEnvironment(
            this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void UserSecurity(
            this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}