using System.Diagnostics.CodeAnalysis;
using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class UserResponseModelListExample : IExamplesProvider<IEnumerable<UserResponseModel>>
    {
        public IEnumerable<UserResponseModel> GetExamples()
        {
            return new List<UserResponseModel>
            {
                new UserResponseModelExample().GetExamples()
            };
        }
    }
}
