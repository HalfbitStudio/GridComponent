using Examples.Fixtures;
using Examples.Models;
using GridComponent.Events;

namespace Examples.Pages;

public partial class Index
{
    static int pageSize = 10;
    int currPage = 0;
    static int numberOfPages = 10;
    Dictionary<string, string> gridFilters = new Dictionary<string, string>();

    private  List<SampleDataPage> pages;
    private SampleDataPage GridData;
        
    private async Task OnGridFilter(GridFilterEventArgs args)
    {
        // own logic
    }
        
    protected override async Task OnInitializedAsync()
    {
        pages = Fixture.GenerateData(pageSize, numberOfPages);
        GridData = pages.FirstOrDefault();
    }
    private async Task OnPageChanged(PageChangedEventArgs eventArgs)
    {
        this.currPage = eventArgs.PageNumber;
        this.GridData = this.pages[eventArgs.PageNumber-1];
    }
        
    private async Task OnGridSort(SortEventArgs eventArgs)
    {
        //own logic
    }
}