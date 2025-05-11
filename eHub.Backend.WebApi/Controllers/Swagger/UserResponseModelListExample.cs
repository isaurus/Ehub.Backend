using eHub.Backend.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace eHub.Backend.WebApi.Controllers.Swagger
{
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
