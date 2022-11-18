using System.Text;

namespace CifraCesar.Facades
{
    public class CifraCesarFacade
    {
        private readonly Dictionary<char,int> _charToIntDict = new Dictionary<char, int>
            {
                {'a', 1 }, {'b', 2 }, {'c', 3 }, {'d', 4 }, {'e', 5 }, {'f', 6 }, {'g', 7 }, {'h', 8 }, {'i', 9 }, {'j', 10 }, {'k', 11 },
                {'l', 12 }, {'m', 13 }, {'n', 14 }, {'o', 15 }, {'p', 16 }, {'q', 17 }, {'r', 18 }, {'s', 19 }, {'t', 20 }, {'u', 21 },
                {'v', 22 }, {'w', 23 }, {'x', 24 }, {'y', 25 }, {'z', 26 }, {'.', 27 }, {',', 28 }, {' ', 29 }
            };

        private readonly Dictionary<int, char> _intToCharDict = new Dictionary<int, char>
            {
                {1, 'a' }, { 2, 'b' }, { 3, 'c' }, { 4, 'd' }, { 5, 'e' }, { 6, 'f' }, { 7, 'g' }, { 8, 'h' }, { 9, 'i' }, { 10, 'j' }, { 11, 'k' },
                { 12, 'l' }, { 13, 'm' }, { 14, 'n' }, { 15, 'o' }, { 16, 'p' }, { 17, 'q' }, { 18, 'r' }, { 19, 's' }, { 20, 't' }, { 21, 'u' },
                { 22, 'v' }, { 23, 'w' }, { 24, 'x' }, { 25, 'y' }, { 26, 'z' }, { 27, '.' }, { 28, ',' }, { 29, ' ' }
            };

        public string Codificar(string word)
        {
            //primeiro passo: transformar as palavras em números da tabela
            var tableLength = _charToIntDict.Count();

            var charArrayInt = new int[word.Length];

            for(var i = 0; i < word.Length; i++)
            {
                charArrayInt[i] = _charToIntDict[word[i]];
            }

            //segundo passo: encripitar usando a função f(x) = 5x + 4 (mod 29)

            for(var i = 0; i < charArrayInt.Length; i++)
            {
                var encryptedChar = charArrayInt[i];

                encryptedChar = ((5 * encryptedChar) + 4);

                if(encryptedChar > tableLength)
                {
                    encryptedChar = encryptedChar % tableLength;
                }

                charArrayInt[i] = encryptedChar;
            }

            //terceiro passo: atribuir letras aos números encriptados

            var charArray = new char[word.Length];

            for (var i = 0; i < word.Length; i++)
            {
                charArray[i] = _intToCharDict[charArrayInt[i]];
            }

            //quarto passo: retornar a nova string encriptada
            var stringBuilder = new StringBuilder();

            foreach (char c in charArray)
            {
                stringBuilder.Append($"{c}");
            }

            return stringBuilder.ToString();
        }

        public string Decodificar(string word)
        {
            //primeiro passo: transformar letras em números da tabela
            var tableLength = _charToIntDict.Count();

            var charArrayInt = new int[word.Length];

            for (var i = 0; i < word.Length; i++)
            {
                charArrayInt[i] = _charToIntDict[word[i]];
            }

            //segundo passo: desencriptar usando a função inversa de f(x) = 5x + 4 (mod 29) que é f-¹(x) = 6x + 5
            for (var i = 0; i < charArrayInt.Length; i++)
            {
                var decryptedChar = charArrayInt[i];

                decryptedChar = ((6 * decryptedChar) + 5);

                if (decryptedChar > tableLength)
                {
                    decryptedChar = decryptedChar % tableLength;
                }

                charArrayInt[i] = decryptedChar;
            }

            //terceiro passo: atribuir letras aos números desencriptados
            var charArray = new char[word.Length];

            for (var i = 0; i < word.Length; i++)
            {
                charArray[i] = _intToCharDict[charArrayInt[i]];
            }

            //quarto passo: retornar a nova string desencriptada
            var stringBuilder = new StringBuilder();

            foreach (char c in charArray)
            {
                stringBuilder.Append($"{c}");
            }

            return stringBuilder.ToString();
        }
    }
}
