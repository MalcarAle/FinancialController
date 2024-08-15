using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.PaymentTypeEndpoint
{
    public class DeletePaymentTypeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapDelete("/{id}", HandleAsync)
            .WithName("Payment Types Delete")
            .WithSummary("Delete a  payment type")
            .WithOrder(3)
            .Produces<Response<PaymentType?>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPaymentTypeHandler handler,
            long id)
        {
            var request = new DeletePaymentTypeRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                Id = id
            };

            var result = await handler.DeleteAsync(request);
            return result.IsSucces
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
