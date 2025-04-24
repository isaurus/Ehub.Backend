namespace eHub.Backend.WebApi.Builders
{
    public static class SwaggerBuilder
    {
        public static IApplicationBuilder AddSwaggerApp(this IApplicationBuilder app)
        {
            var enabled = Application.Registration.ConfigurationManager.SwaggerEnabled;

            if (((WebApplication)app).Environment.IsDevelopment() && enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
