using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.PaymentTypeEndpoint
{
    public class GetPaymentTypeByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/{id}", HandleAsync)
            .WithName("Payment Types Get by Id")
            .WithSummary("Get payment type by id")
            .WithOrder(4)
            .Produces<Response<PaymentType?>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPaymentTypeHandler handler,
            long id)
        {
            var request = new GetPaymentTypeByIdRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.GetByIdAsync(request);
            return result.IsSucces
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
