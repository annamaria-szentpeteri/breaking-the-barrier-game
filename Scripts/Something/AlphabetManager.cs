using Godot;
using System.Collections.Generic;
using System.Transactions;

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
public class AlphabetManager : IAlphabetManager
{
    public const string LettersAndSpecialChars = "abcdefghijklmnopqrstuvwxyz.:;,?!-()";

    public const int AlienAtlasIndex = 0;
    public const int XMaxAlienAtlas = 20;
    public const int YMaxAlienAtlas = 20;
    
    public const int OriginalAtlasIndex = 99;
    public const int XMaxOriginalAtlas = 6;
    public const int YMaxOriginalAtlas = 6;

    private Dictionary<char, AtlasVector> _mapping = new Dictionary<char, AtlasVector>(LettersAndSpecialChars.Length);
    private Dictionary<char, AtlasVector> _learningProgress = new Dictionary<char, AtlasVector>(LettersAndSpecialChars.Length);

    public void GenerateMapping(ulong seed)
    {
        _mapping.Clear();
        _learningProgress.Clear();

        var r = new RandomNumberGenerator();
        r.Seed = seed;

        var duplicationChecker = new HashSet<Vector2I>(LettersAndSpecialChars.Length);

        foreach (var i in LettersAndSpecialChars)
        {
            Vector2I vector;
            do
            {
                vector = new Vector2I(r.RandiRange(0, XMaxAlienAtlas - 1), r.RandiRange(0, YMaxAlienAtlas - 1));
            }
            while (duplicationChecker.Contains(vector));

            duplicationChecker.Add(vector);
            _mapping.Add(i, new AtlasVector(AlienAtlasIndex, vector));
            _learningProgress.Add(i, _mapping[i]);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    /// <param name="atlasVector"></param>
    /// <returns>Returns null if character was not found.</returns>
    public AtlasVector Learn(char character, AtlasVector atlasVector)
    {
        if (_learningProgress.ContainsKey(character))
        {
            _learningProgress[character] = atlasVector;
            return _learningProgress[character];
        }

        GD.PrintErr($"Character {character} was not found in {nameof(_learningProgress)}.");
        return null;
    }

    public AtlasVector GetVector(char c)
    {
        var lowerChar = char.ToLowerInvariant(c);
        return _learningProgress.ContainsKey(lowerChar) ? _learningProgress[lowerChar] : null;
    }
}
