using System.Text.Json;

public class ScriptureRequest
{
  private string _url = "https://api.nephi.org/scriptures/";
  private string _options;
  private HttpClient _client = new HttpClient();

  public ScriptureRequest(ScriptureReference reference)
  {
    _options = $"?q={reference.GetStringRepresentation()}";
  }

  public async Task DispatchRequest(ScriptureProgress progress)
  {
    HttpResponseMessage httpResponse = await _client.GetAsync(_url + _options);

    if (httpResponse.IsSuccessStatusCode)
    {
      string response = await httpResponse.Content.ReadAsStringAsync();
      ResponseModel content = JsonSerializer.Deserialize<ResponseModel>(response);
      HandleData(content.scriptures, progress);
    }
  }

  private void HandleData(ScriptureModel[] scriptures, ScriptureProgress progress)
  {
    List<string> bookNames = new List<string>();
    List<int> verseAmounts = new List<int>();

    CalculateVerseAmount(scriptures, bookNames, verseAmounts);

    for (int i = 0; i < bookNames.Count; i++)
    {
      progress.UpdateProgress(bookNames[i], verseAmounts[i]);
    }
  }

  private void CalculateVerseAmount(ScriptureModel[] scriptures, List<string> bookNames, List<int> verseAmounts)
  {
    string currentBookName = scriptures[0].book;
    int verseAmount = 0;
    bool isTheSame;

    foreach (ScriptureModel scripture in scriptures)
    {
      isTheSame = currentBookName == scripture.book;

      if (!isTheSame)
      {
        bookNames.Add(currentBookName);
        verseAmounts.Add(verseAmount);

        currentBookName = scripture.book;
        verseAmount = 0;
      }

      verseAmount += 1;
    }

    bookNames.Add(currentBookName);
    verseAmounts.Add(verseAmount);
  }
}