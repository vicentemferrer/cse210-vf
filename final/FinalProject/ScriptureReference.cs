public class ScriptureReference
{
  private string _book;
  private int _chapter;
  private int _verse;
  private int? _endVerse;

  public ScriptureReference()
  { }

  public ScriptureReference(string book, int chapter, int verse)
  {
    _book = book;
    _chapter = chapter;
    _verse = verse;
  }

  public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
  {
    _book = book;
    _chapter = chapter;
    _verse = startVerse;
    _endVerse = endVerse;
  }

  public void ResetReference()
  {
    _book = "";
    _chapter = 0;
    _verse = 0;
    _endVerse = 0;
  }

  public void UpdateReference(string book, int chapter, int startVerse, int endVerse)
  {
    _book = book;
    _chapter = chapter;
    _verse = startVerse;
    _endVerse = endVerse != startVerse ? endVerse : null;
  }

  public string GetStringRepresentation()
  {
    string append = _endVerse != null ? $"-{_endVerse}" : "";
    return $"{_book} {_chapter}:{_verse}" + append;
  }
}