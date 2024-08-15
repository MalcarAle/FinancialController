using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.PaymentTypeEndpoint
{
    public class CreatePaymentTypeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapPost("/", HandleAsync)
            .WithName("Payment Types")
            .WithSummary("Create a new payment type")
            .WithOrder(1)
            .Produces<Response<PaymentType?>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPaymentTypeHandler handler,
            CreatePaymentTypeRequest request)
        {
            request.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(request);
            return result.IsSucces
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result);
        }
    }
}
