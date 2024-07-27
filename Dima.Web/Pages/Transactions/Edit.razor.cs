using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Transactions
{
    public partial class EditTransactionPage : ComponentBase
    {
        #region Properties

        [Parameter]
        public string Id { get; set; } = string.Empty;

        public bool IsBusy { get; set; } = false;
        public UpdateTransactionRequest InputModel { get; set; } = new();
        public List<Category> Categories { get; set; } = [];

        #endregion Properties

        #region Services

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ITransactionHandler TransactionHandler { get; set; } = null!;

        [Inject]
        public ICategoryHandler CategoryHandler { get; set; } = null!;

        #endregion Services

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            await GetTransactionByIdAsync();
            await GetCategoriesAsync();

            IsBusy = false;
        }

        #endregion Overrides

        #region Private Methods

        public async Task OnValidSubmitAsync() { }

        private async Task GetTransactionByIdAsync()
        {
            GetTransactionByIdRequest request = null;
            try
            {
                request = new GetTransactionByIdRequest { Id = long.Parse(Id) };
            }
            catch
            {
                Snackbar.Add("Paramentro inválido!", Severity.Error);
            }

            if (request is null)
                return;

            IsBusy = true;
            try
            {
                var result = await TransactionHandler.GetByIdAsync(request);
                if (result is { IsSucces: true, Data: not null })
                {
                    InputModel = new UpdateTransactionRequest
                    {
                        CategoryId = result.Data.CategoryId,
                        PaidOrReceivedAt = result.Data.PaidOrReceivedAt,
                        Title = result.Data.Title,
                        Type = result.Data.Type,
                        Amount = result.Data.Amount,
                        Id = result.Data.Id
                    };
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetCategoriesAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCategoriesRequest();
                var result = await CategoryHandler.GetAllAsync(request);
                if (result.IsSucces)
                    Categories = result.Data ?? [];
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion Private Methods
    }
}