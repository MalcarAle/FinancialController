﻿using Dima.Core.Handlers;
using Dima.Core.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Components.Reports
{
    public partial class ExpensesByCategoryChartComponent : ComponentBase
    {
        #region Properties
        public List<double> Data { get; set; } = [];
        public List<string> Labels { get; set; } = [];
        public int Index = -1;
        #endregion

        #region Services
        [Inject]
        public IReportHandler Handler { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        #endregion

        #region Overrides
        protected override async Task OnInitializedAsync()
        {
            await GeExpensesByCategoryAsync();
        }

        private async Task GeExpensesByCategoryAsync()
        {
            var request = new GetExpensesByCategoryRequest();
            var result = await Handler.GetExpensesByCategoryReportAsync(request);
            if (!result.IsSucces || result.Data is null)
            {
                Snackbar.Add("Falha ao obter dados do relatório", Severity.Error);
                return;
            }

            foreach (var item in result.Data)
            {
                Labels.Add($"{item.Category} ({item.Expenses:C})");
                Data.Add(-(double)item.Expenses);
            }

        }
        #endregion

        #region Methods
        public string SelectedLabel => Index >= 0 && Index < Data.Count ? Labels[Index] : "None";
        #endregion
    }
}
