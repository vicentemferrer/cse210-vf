public class Scripture
{
  private Reference _reference;
  private List<Verse> _verses = new List<Verse>();

  public Scripture(Reference reference, string text)
  {
    _reference = reference;
    foreach (string verse in text.Split('\n'))
    {
      _verses.Add(new Verse(verse.Trim()));
    }
  }

  public void HideRandomWords(Random hideLogic, int numberToHide)
  {
    int quantityToHide = numberToHide / _verses.Count, i = _verses.Count;

    do
    {
      foreach (Verse verse in _verses)
      {
        if (i > 0)
        {
          verse.HideRandomWords(hideLogic, quantityToHide);
          --i;
        }
      }
    } while (i > 0);
  }

  public bool IsCompletelyHidden()
  {
    return _verses.All(verse => verse.IsHidden());
  }

  public string GetDisplayText()
  {
    return $"{_reference.GetDisplayText()} " + String.Join('\n', _verses.Select(verse => verse.GetDisplayText()));
  }
}