using Dima.Core.Handlers;
using Dima.Core.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Pages.Categories
{
    public partial class EditCategoryPage : ComponentBase
    {
        #region Properties

        public bool IsBusy { get; set; } = false;
        public UpdateCategoryRequest InputModel { get; set; } = new();

        [Parameter]
        public string Id { get; set; } = string.Empty;

        #endregion Properties

        #region Services

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        #endregion Services

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            GetCategoryByIdRequest? request = null;
            try
            {
                request = new GetCategoryByIdRequest
                {
                    Id = long.Parse(Id)
                };
            }
            catch
            {
                Snackbar.Add("Parametro inválido", Severity.Error);
            }

            if (request is null)
                return;
            IsBusy = true;
            try
            {
                var response = await Handler.GetByIdAsync(request);
                if (response is { IsSucces: true, Data: not null })
                    InputModel = new UpdateCategoryRequest
                    {
                        Id = response.Data.Id,
                        Title = response.Data.Title,
                        Description = response.Data.Description
                    };
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

        #endregion Overrides

        #region Methods

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;
            try
            {
                var result = await Handler.UpdateAsync(InputModel);
                if (result.IsSucces)
                {
                    Snackbar.Add("Categoria atualizada!", Severity.Success);
                    NavigationManager.NavigateTo("/categorias/listar");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Success);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion Methods
    }
}