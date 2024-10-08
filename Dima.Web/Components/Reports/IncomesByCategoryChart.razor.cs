﻿using Dima.Core.Handlers;
using Dima.Core.Requests.Reports;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Dima.Web.Components.Reports
{
    public partial class IncomesByCategoryChartComponent : ComponentBase
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
            await GeIncomesByCategoryAsync();
        }

        private async Task GeIncomesByCategoryAsync()
        {
            var request = new GetIncomesByCategoryRequest();
            var result = await Handler.GetIncomesByCategoryReportAsync(request);
            if (!result.IsSucces || result.Data is null)
            {
                Snackbar.Add("Falha ao obter dados do relatório", Severity.Error);
                return;
            }

            foreach (var item in result.Data)
            {
                Labels.Add($"{item.Category} ({item.Incomes:C})");
                Data.Add((double)item.Incomes);
            }

        }
        #endregion

        #region Methods
        public string SelectedLabel => Index >= 0 && Index < Data.Count ? Labels[Index] : "Selecione uma opção na tela";
        #endregion
    }
}
