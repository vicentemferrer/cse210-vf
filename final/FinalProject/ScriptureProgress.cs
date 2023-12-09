public class ScriptureProgress
{
  private string[] _volumes;
  private int[] _verses;
  private int[] _versesRead;
  private string[][] _books;

  public ScriptureProgress()
  {
    _volumes = new string[5] { "Old Testament", "New Testament", "Book of Mormon", "Doctrine and Covenants", "Pearl of Great Price" };
    _verses = new int[5] { 27591, 7958, 6577, 3627, 635 };
    _versesRead = new int[5] { 0, 0, 0, 0, 0 };
    _books = new string[][] {
      new string[] { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Solomon's Song", "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi" },
      new string[] { "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation" },
      new string[] { "1 Nephi", "2 Nephi", "Jacob", "Enos", "Jarom", "Omni", "Words of Mormon", "Mosiah", "Alma", "Helaman", "3 Nephi", "4 Nephi", "Mormon", "Ether", "Moroni" },
      new string[] { "Doctrine and Covenants" },
      new string[] { "Moses", "Abraham", "Joseph Smith--Matthew", "Joseph Smith--History", "Articles of Faith"}
    };
  }

  public ScriptureProgress(int[] versesRead)
  {
    _volumes = new string[5] { "Old Testament", "New Testament", "Book of Mormon", "Doctrine and Covenants", "Pearl of Great Price" };
    _verses = new int[5] { 27591, 7958, 6577, 3627, 635 };
    _versesRead = versesRead;
    _books = new string[][] {
      new string[] { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy", "Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther", "Job", "Psalms", "Proverbs", "Ecclesiastes", "Solomon's Song", "Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi" },
      new string[] { "Matthew", "Mark", "Luke", "John", "Acts", "Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon", "Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude", "Revelation" },
      new string[] { "1 Nephi", "2 Nephi", "Jacob", "Enos", "Jarom", "Omni", "Words of Mormon", "Mosiah", "Alma", "Helaman", "3 Nephi", "4 Nephi", "Mormon", "Ether", "Moroni" },
      new string[] { "Doctrine and Covenants" },
      new string[] { "Moses", "Abraham", "Joseph Smith--Matthew", "Joseph Smith--History", "Articles of Faith"}
    };
  }

  public void UpdateProgress(string bookName, int verseAmount)
  {
    int index = MatchVolume(bookName);

    if (index != -1) _versesRead[index] += verseAmount;
  }

  private int MatchVolume(string book)
  {
    for (int i = 0; i < _books.Length; i++)
    {
      foreach (string item in _books[i])
      {
        if (book == item) return i;
      }
    }

    return -1;
  }

  public string GetStringRepresentation()
  {
    string representation = "Progress:";

    foreach (int amount in _versesRead)
    {
      representation += amount != _versesRead[_versesRead.Length - 1] ? $"{amount}," : $"{amount}";
    }

    return representation;
  }
}