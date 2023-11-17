public class Word
{
  private string _text;
  private string _hiddenWord = "";
  private bool _isHidden = false;

  public Word(string word)
  {
    _text = word;

    for (int i = 0; i < word.Length; i++)
      _hiddenWord += '_';
  }

  public void Hide()
  {
    _isHidden = true;
  }

  public void Show()
  {
    _isHidden = false;
  }

  public bool IsHidden()
  {
    return _isHidden;
  }

  public string GetDisplayText()
  {
    return !_isHidden ? _text : _hiddenWord;
  }
}