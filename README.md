# Blazor Grid Component

This component is only for Blazor Web Assembly.


##  Features
* Server Side/Client Side Pagination
* Server Side/Client Side Sorting
* Server Side/Client Side Filtering
* Support custom column theming
* Support for .NET 6 / .NET 5
## Basic usage

Install from nuget
https://www.nuget.org/packages/GridComponent/

In desired Page/Component

```html

<HalfbitGrid Items="auditList" PageSize="pageSize" PagesTotalCount="numberOfPages" DisplayFilters="true"
             OnPageChanged="OnPageChanged" OnSort="OnGridSort"
             OnFilter="OnGridFilter" CurrentPage="@currPage">
    <GridColumns>
        <GridColumn GridItem="Audit" Title="ID"> //GridItem- Object type
            <RowTemplate>@context.ID</RowTemplate>
        </GridColumn>
        <GridColumnText GridItem="Audit" Title="Nazwa firmy" Field="companyName"> //GridColumnText- allow filtering
            <RowTemplate>@context.CompanyName</RowTemplate>
        </GridColumnText>
        <GridColumnComboBox GridItem="Audit" Title="URL LP" Field="lpId" Value="lpDictionary"> /* GridColumnText- allow,
            Value= Ienumerable of string to comboBox
            filtering via combo box */
            <RowTemplate>@context.LP</RowTemplate>
        </GridColumnComboBox>
        //...
    </GridColumns>
    <GridFooter>
        <PaginationControl CurrentPage="@(auditList.Page + 1)" PagesCount="@numberOfPages"
                           TotalRecords="@auditList.TotalCount"></PaginationControl>
    </GridFooter>
</HalfbitGrid>
```

In page code behind implement:

```c#
        int pageSize = 10;
        int currPage = 0;
        int numberOfPages = 0;
        Dictionary<string, string> gridFilters = new Dictionary<string, string>();
        List<Audit> auditList;
        
        private async Task OnGridFilter(GridFilterEventArgs args)
        {
            // own logic
        }
        
         protected override async Task OnInitializedAsync()
        {
            //load from API auditList
        }
         private async Task OnPageChanged(PageChangedEventArgs eventArgs)
        {
            this.currPage = eventArgs.PageNumber;
        }
        
        private async Task OnGridSort(SortEventArgs eventArgs)
        {
           //own logic
        }
        
```

## Contributors

If you need commercial support please contact us.

* Halfbit Studio Team <contact@halfbitstudio.com>


