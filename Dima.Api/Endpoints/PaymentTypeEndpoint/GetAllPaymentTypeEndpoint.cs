using Dima.Api.Common.Api;
using Dima.Core;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.PaymentTypeRequest;
using Dima.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dima.Api.Endpoints.PaymentTypeEndpoint
{
    public class GetAllPaymentTypeEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
         => app.MapGet("/", HandleAsync)
            .WithName("Payment Types Get all")
            .WithSummary("Get payment typeall")
            .WithOrder(5)
            .Produces<PagedResponse<List<PaymentType>?>>();
        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            IPaymentTypeHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllPaymentTypeRequest
            {
                UserId = user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var result = await handler.GetAllAsync(request);
            return result.IsSucces
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
