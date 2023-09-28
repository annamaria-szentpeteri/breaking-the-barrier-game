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
    private const string _lettersAndSpecialChars = "abcdefghijklmnopqrstuvwxyz.:;,?!-()";
    private const int _xMaxAtlas = 20;
    private const int _yMaxAtlas = 20;

    private static Dictionary<char, Vector2I> _mapping = new Dictionary<char, Vector2I>(_lettersAndSpecialChars.Length);

    public static void GenerateMapping(ulong seed)
    {
        _mapping.Clear();

        var r = new RandomNumberGenerator();
        r.Seed = seed;

        var duplicationChecker = new HashSet<Vector2I>(_lettersAndSpecialChars.Length);

        foreach (var i in _lettersAndSpecialChars)
        {
            Vector2I vector;
            do
            {
                vector = new Vector2I(r.RandiRange(0, _xMaxAtlas - 1), r.RandiRange(0, _yMaxAtlas - 1));
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
