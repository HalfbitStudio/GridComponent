using Examples.Models;

namespace Examples.Fixtures;

public static class Fixture
{
    
    public static string CreateRandomWordNumberCombination()
    {
        Random rnd = new Random();
        //Dictionary of strings
        string[] words = { "Bold", "Think", "Friend", "Pony", "Fall", "Easy","Grid", "Testing", "Halfbit" };
        //Random number from - to
        int randomNumber =  rnd.Next(2000, 3000);
        //Create combination of word + number
        string randomString = $"{words[rnd.Next(0, words.Length)]}{randomNumber}";

        return randomString;

    }

    public static List<SampleDataPage> GenerateData(int pageSize, int pages)
    {

        Random rnd = new Random();
        
        var data = new List<SampleDataPage>();

        for (var i = 0; i < pages; i++)
        {
            var page = new SampleDataPage();
            page.Content = new List<SampleData>();
            page.Page = i;
            page.TotalCount = pageSize * pages;
            
            for (var j = 0; j < pageSize; j++)
            {
                page.Content.Add(new SampleData
                {
                    Id = rnd.Next(0,200),
                    Active = rnd.Next(0,1) > 0,
                    Name = CreateRandomWordNumberCombination()
                });
            }

            
            data.Add(page);
        }

        return data;
    }
}