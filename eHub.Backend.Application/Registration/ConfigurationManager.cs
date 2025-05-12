using Microsoft.Extensions.Configuration;

namespace eHub.Backend.Application.Registration
{
    public class ConfigurationManager
    {
        public static IConfiguration? Configuration { get; set; }

        #region Swagger
        public static bool SwaggerEnabled
        {
            get
            {
                if (Configuration != null && bool.TryParse(Configuration["Swagger:Enabled"], out bool enabled))
                {
                    return enabled;
                }
                return false;
            }
        }
        #endregion Swagger

        #region ConnectionStrings

        public static string? LocalDB
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:LocalDB"] : string.Empty;
            }
        }

        public static string? RemoteDockerSQLServer
        {
            get
            {
                return Configuration != null ? Configuration["ConnectionStrings:RemoteDockerSQLServer"] : string.Empty;
            }
        }

    }
    #endregion ConnectionStrings

}