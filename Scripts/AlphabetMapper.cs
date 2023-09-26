using Godot;
using System.Collections.Generic;

/*
 * ToDo:
 * This wont be static in the future and will be instanciated at starting a New Game.
 * 
 * ToDo:
 * Modify the atlas to include fixed special characters?
 * 
 * ToDo:
 * Add learnt character to the algorithm.
 */
public static class AlphabetMapper
{
    public const string LettersAndSpecialChars = "abcdefghijklmnopqrstuvwxyz.,-:;!?";
    public const int xMaxAtlas = 20;
    public const int yMaxAtlas = 20;

    private static Dictionary<char, Vector2I> _mapping = new Dictionary<char, Vector2I>(LettersAndSpecialChars.Length);

    static AlphabetMapper()
    {
        var r = new RandomNumberGenerator();

        /* 
         * ToDo:
         * Seed will be provided by user.
         *   r.Seed = userInput;
         *   
         */

        var duplicationChecker = new HashSet<Vector2I>(LettersAndSpecialChars.Length);

        foreach (var i in LettersAndSpecialChars)
        {
            Vector2I vector;
            do
            {
                vector = new Vector2I(r.RandiRange(0, xMaxAtlas - 1), r.RandiRange(0, yMaxAtlas - 1));
            }
            while (duplicationChecker.Contains(vector));

            duplicationChecker.Add(vector);
            _mapping.Add(i, vector);
        }
    }

    public static Vector2I? GetVector(char c)
    {
        var lowerChar = char.ToLowerInvariant(c);
        return _mapping.ContainsKey(lowerChar) ? _mapping[lowerChar] : null;
    }
}
