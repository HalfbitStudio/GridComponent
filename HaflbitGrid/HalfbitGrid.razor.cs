using GridComponent.Events;
using GridComponent.Utils;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GridComponent
{
    public partial class HalfbitGrid<GridItem>
    {
        int currPage = 0;
        int NumberOfBreadCrubs = 3;
        private SortOrder sortOrder;
        private string sortBy;

        [Parameter]
        public RenderFragment GridFooter { get; set; }
        [Parameter]
        public IEnumerable<GridItem> Items { get; set; }
        [Parameter]
        public int PageSize { get; set; }
        [Parameter]
        public int PagesTotalCount { get; set; }
        [Parameter]
        public string Class { get; set; }

        [Parameter] 
        public bool DisplayFilters { get; set; }

        [Parameter]
        public int CurrentPage { get { return currPage; } set { SetPage(value); } }

        [Parameter]
        public EventCallback<GridFilterEventArgs> OnFilter { get; set; }

        [Parameter]
        public RenderFragment GridColumns { get; set; }
        internal List<GridColumn<GridItem>> Columns { get; set; } = new List<GridColumn<GridItem>>();


        [Parameter]
        public EventCallback<PageChangedEventArgs> OnPageChanged { get; set; }
        [Parameter]
        public EventCallback<SortEventArgs> OnSort { get; set; }

        private async Task setCurrPage(int pageNr)
        {
            if (pageNr < 0 || pageNr > PagesTotalCount - 1)
                return;

            this.currPage = pageNr;
            await OnPageChanged.InvokeAsync(new PageChangedEventArgs() { PageNumber = this.currPage });
        }

        public void UpdateObjectState()
        {
            StateHasChanged();
        }

        public void SetPage(int pageNumber)
        {
            if (pageNumber < 0 )
                this.currPage = 0;

            if (pageNumber > PagesTotalCount - 1)
                this.currPage = PagesTotalCount > 0 ? PagesTotalCount - 1 : 0;

            this.currPage = pageNumber;
        }

        private async Task SortGrid(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                return;

            if (sortBy == columnName)
                sortOrder = SortUtils.GetNextOrderValue(sortOrder);
            else
                sortOrder = SortOrder.Ascending;

            if (sortOrder == SortOrder.None)
                sortBy = null;
            else
                sortBy = columnName;

            await OnSort.InvokeAsync(new SortEventArgs() { OrderByColumn = sortBy, IsAscending = sortOrder != SortOrder.Descending });
        }

        internal void OnGridFilter(FilterChangedEventArgs args)
        {
            System.Console.WriteLine($"Key: {args.Key}, Value: {args.Value}");
        }

        internal async void OnGridFilter()
        {
            var dict = new Dictionary<string, string>();
            foreach(var column in Columns)
            {
                if (!string.IsNullOrEmpty(column.Field) && !string.IsNullOrEmpty(column.FilterValue))
                    dict.Add(column.Field, column.FilterValue);
            }

            await OnFilter.InvokeAsync(new GridFilterEventArgs() { Filters = dict });
        }
    }
}
