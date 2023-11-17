using System.Text.Json;

public class ScriptureRequest
{
  private string _url = "https://api.nephi.org/scriptures/";
  private string _options;
  private List<ScriptureModel> _scriptures = new List<ScriptureModel>();
  private HttpClient _client = new HttpClient();

  public ScriptureRequest(Reference reference)
  {
    _options = $"?q={reference.GetDisplayText()}";
  }

  private void HandleData(ScriptureModel[] scriptures)
  {
    foreach (ScriptureModel scripture in scriptures)
    {
      _scriptures.Add(scripture);
    }
  }

  public async Task Request()
  {
    HttpResponseMessage httpResponse = await _client.GetAsync(_url + _options);

    if (httpResponse.IsSuccessStatusCode)
    {
      string response = await httpResponse.Content.ReadAsStringAsync();
      ResponseModel content = JsonSerializer.Deserialize<ResponseModel>(response);
      HandleData(content.scriptures);
    }
  }

  public string GetScriptureText()
  {
    return String.Join("\n", _scriptures.Select(scripture => scripture.text));
  }

}