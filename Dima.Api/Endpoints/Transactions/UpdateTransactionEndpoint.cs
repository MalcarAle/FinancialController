﻿using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Transactions;
using Dima.Core.Responses;
using System.Security.Claims;

namespace Dima.Api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            app.MapPut("/{id}", HandleAsync)
                .WithName("Transaction Update")
                .WithSummary("Update a Transaction")
                .WithDescription("Updates a transaction, with: Id, Title, Description")
                .WithOrder(2)
                .Produces<Response<Transaction?>>();
        }

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ITransactionHandler handler,
            UpdateTransactionRequest request,
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