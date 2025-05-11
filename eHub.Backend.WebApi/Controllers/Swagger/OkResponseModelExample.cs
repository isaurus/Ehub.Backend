using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    public class OkResponseModelExample : IExamplesProvider<OkResponseModel>
    {
        public OkResponseModel GetExamples()
        {
            return new OkResponseModel
            {
                Id = 32,
                Message = "Operación completada con éxito."
            };
        }
    }
}
