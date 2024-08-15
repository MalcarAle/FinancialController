using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.PaymentTypeEndpoint
{
    public class UpdatePaymentTypeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPut("/{id}", HandleAsync)
            .WithName("Payment Types Update")
            .WithSummary("Update a  payment type")
            .WithOrder(2)
            .Produces<Response<PaymentType?>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPaymentTypeHandler handler,
            UpdatePaymentTypeRequest request,
            long id)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            request.Id = id;

            var result = await handler.UpdateAsync(request);
            return result.IsSucces
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
