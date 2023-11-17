public class Verse
{
  private List<Word> _words = new List<Word>();

  public Verse(string text)
  {
    foreach (string word in text.Split(' '))
    {
      _words.Add(new Word(word.Trim()));
    }
  }

  public bool IsHidden()
  {
    return _words.All(word => word.IsHidden());
  }

  public void HideRandomWords(Random hideLogic, int numberToHide)
  {
    int i = numberToHide;

    do
    {
      foreach (Word word in _words)
      {
        if (hideLogic.Next(2) == 1 && i > 0)
        {
          if (!word.IsHidden())
          {
            word.Hide();
            i--;
          }
        }
      }
    } while (i > 0 && !IsHidden());
  }

  public string GetDisplayText()
  {
    return String.Join(' ', _words.Select(word => word.GetDisplayText()));
  }
}