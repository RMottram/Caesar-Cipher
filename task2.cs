using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{

  class Program
  {

    // defining the characters for encrypting and deciphering
    public static char cipher(char ch, int key)

    {

      if (!char.IsLetter(ch)) //categorises to unicode letters a-z

      {
        return ch;
      }

      char d = char.IsUpper(ch) ? 'A' : 'a'; // turns any uppercase characters to lower case to avoid breaking the program
      return (char)((((ch + key) - d) % 26) + d);

    }

    // encrypting class
    public static string Encipher(string input, int key)
    {

      string output = string.Empty;
      foreach(char ch in input)
      output += cipher(ch, key);

      return output;

    }

    // deciphering class
    public static string Decipher(string input, int key)
    {
      return Encipher(input, 26 - key);
    }

    // start of the main ciphering program
    static void Main(string[] args)
    {

      int key = 7;
      string plainText = "we attack at dawn";
      string encryptedText = "fn jan anjmh oxa hxda xamnab";

      // encryption process
      Console.WriteLine("\nEncryption Key = 7");
			Console.WriteLine("Plain Text: {0}", plainText);
      string cipherText = Encipher(plainText, key);
      Console.WriteLine("Encrypted Text: {0}", cipherText);
      Console.Write("\n");

      // decryption process, decryption key taken from encryption key + 2
      Console.WriteLine("Decryption Key = 9");
		  Console.WriteLine("Encrypted Text: {0}", encryptedText);
      string t = Decipher(encryptedText, key + 2);
      Console.WriteLine(t);

      // stretch exercise

      string cipherPara = "Mu husudjbo iqm, veh jxu vyhij jycu, jxu huikbj ev q iefxyijysqjut hqdiecmqhu qjjqsa, qdt jxu uvvusji jxqj yj xqt ed jxu Dqjyedqb Xuqbjx Iuhlysu, ydsbktydw qcrkbqdsui ruydw jkhdut qmqo qdt fqjyudji xqlydw jxuyh efuhqjyedi sqdsubbut mxybij fhufqhydw je we yd je jxuqjhu. Jxu MqddqSho lyhki, qi yj rusqcu ademd, xqt vekdt q auo lkbduhqrybyjo, qdt yj xqt q tulqijqjydw ycfqsj qi edu xeifyjqb qvjuh qdejxuh hufehjut jxqj yj xqt ruud qvvusjut; duqhbo vyvjo yd jejqb. Yd jxu yccutyqju qvjuhcqjx, unfuhji qdt ydiytuhi qbyau mudj ed je dumi ekjbuji qdt ed je iesyqb cutyq, myjx jxuyh unfbqdqjyedi eh xem jxyi sekbt xqlu xqffudut. Mxqj yi sbuqh yi jxqj iecujxydw duutut je ru tedu je udikhu jxqj iksx qd qjjqsa mybb duluh xqlu jxu iqcu ycfqsj ed jxu Dqjyedqb Xuqb Iuhlysu yd jxu vkjkhu.";

      Console.WriteLine("\nText to decipher for stretch exercise: \n{0}\n", cipherPara);

      int charCount = 0;

      // "q" appears several times on its own in cipher text, could be "a" or "i" in plain text.

      // counts how many times "q" appears in cipher text to determine if it could be an 'a' or an 'i'.
      foreach (char letter in cipherPara)
      {
        if (letter == 'q')
        {
          charCount++;
        }
      }

      // decrypt the letter 'q' to see if it actually is 'a'

      Console.WriteLine("Through frequency analysis, the letter 'q' appears {0} times\n", charCount);
      Console.WriteLine("'q' could decrypt to 'a' in plain text making the shift key 16\n");
      /* 'q' appears 71 times. 'q' is 16 shifts from 'a' and 'i' is 16 shifts from 's' but 's' does not appear on its own in the English language so 's' is ruled out making 'q' an 'a' in plain text.

      With this is mind trying the shift of -16 for the first two letters of the first word would be:
      'M' = 'W' and 'u' = 'e' making the first word 'We'. Because this is a perfect plain text word you could establish that the shift key is -16 for the encrypted text. */


      // decryption process for extension task
      Console.WriteLine("decryption of stretch exercise with 16 as the shift key: \n");
      Console.WriteLine("Decryption Key = 16\n");
      string x = Decipher(cipherPara, key + 9);
      Console.WriteLine(x);
      Console.WriteLine("\n");

    }
  }
}
