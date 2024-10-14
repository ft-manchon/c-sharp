namespace encryption;

class Program
{
    static void CaesarCipher(string original, int num)
    {
        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        string[] encryptedAlphab = new string[alphabet.Length];
        string[] encryptedChars = new string[original.Length];

        for (var i = 0; i < alphabet.Length; i++)
        {
            encryptedAlphab[i] = alphabet[(i + num) % alphabet.Length];
        }

        for (var i = 0; i < original.Length; i++)
        {
            if (original[i].ToString() == " ")
            {
                encryptedChars[i] = " ";
                continue;
            }

            for (var j = 0; j < encryptedAlphab.Length; j++)
            {
                if (original[i].ToString().ToUpper() == alphabet[j])
                {
                    if (Char.IsLower(original[i]))
                    {
                        encryptedChars[i] = encryptedAlphab[j].ToLower();
                    }
                    else
                    {
                        encryptedChars[i] = encryptedAlphab[j];
                    }
                }
            }
        }

        string result = String.Join("", encryptedChars);
        Console.WriteLine(result);
    }

    static void Main(string[] args)
    {
        string original = "Cifra de Cesar";
        CaesarCipher(original, 3);
    }
}
