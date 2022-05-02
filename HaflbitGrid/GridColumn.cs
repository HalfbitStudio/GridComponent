using GridComponent.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridComponent
{
    public class GridColumn<GridItem> : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Field { get; set; }
        [Parameter] public string Width { get; set; }
        [Parameter] public bool DisplayFilter { get; set; }
        [Parameter] public RenderFragment<GridItem> RowTemplate { get; set; }
        [CascadingParameter] public HalfbitGrid<GridItem> ParentGrid { get; set; }

        public string FilterValue { get; set; }

        public RenderFragment Filter { get; set; }

        protected override Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            ParentGrid.Columns.Add(this);
            ParentGrid.UpdateObjectState();
            return Task.CompletedTask;
        }

        protected void OnFilter(ChangeEventArgs args)
        {
            this.FilterValue = args.Value.ToString();
            ParentGrid.OnGridFilter();
        }
    }
}
