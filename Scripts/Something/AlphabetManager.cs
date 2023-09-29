using Godot;
using System;
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
public class AlphabetManager : IAlphabetManager
{
    public const string LettersAndSpecialChars = "abcdefghijklmnopqrstuvwxyz.:;,?!-()";

    public const int AlienAtlasIndex = 0;
    public const int AlienAtlasDimension = 20;
    
    public const int OriginalAtlasIndex = 99;
    public const int OriginalAtlasDimension = 6;

    private readonly Dictionary<char, AtlasVector> _alienMapping = new(LettersAndSpecialChars.Length);
    private readonly Dictionary<char, AtlasVector> _learningProgress = new(LettersAndSpecialChars.Length);

    public void GenerateMapping(ulong seed)
    {
        _alienMapping.Clear();
        _learningProgress.Clear();

        var rand = new RandomNumberGenerator
        {
            Seed = seed
        };

        var duplicationChecker = new HashSet<Vector2I>(LettersAndSpecialChars.Length);

        foreach (var i in LettersAndSpecialChars)
        {
            Vector2I vector = GetRandomUnique((v) => duplicationChecker.Contains(v), () => new Vector2I(rand.RandiRange(0, AlienAtlasDimension - 1), rand.RandiRange(0, AlienAtlasDimension - 1)));

            duplicationChecker.Add(vector);
            _alienMapping.Add(i, new AtlasVector(AlienAtlasIndex, vector));
        }
    }

    public static void LearnRandomCharacter()
    {
        // BUG: If everything has been learnt, infinite loop occours
        var rand = new RandomNumberGenerator();
        var index = GetRandomUnique((i) => _learningProgress.ContainsKey(LettersAndSpecialChars[i]), () => rand.RandiRange(0, LettersAndSpecialChars.Length - 1));
        var character = LettersAndSpecialChars[index];
        var atlasVector = new AtlasVector(OriginalAtlasIndex, new Vector2I(index % OriginalAtlasDimension, index / OriginalAtlasDimension));

        Learn(character, atlasVector);

        GD.Print($"Random: {index} - {character}");
        GD.Print($"{atlasVector.Id}->({atlasVector.Vector.X},{atlasVector.Vector.Y})");
    }

    private void Learn(char character, AtlasVector atlasVector)
    {
        if (atlasVector == null)
        {
            _learningProgress.Remove(character);
            return;
        }

        if (_learningProgress.ContainsKey(character))
        {
            _learningProgress[character] = atlasVector;
        }
        else
        {
            _learningProgress.Add(character, atlasVector);
        }
    }

    public static AtlasVector GetCharacterVector(char c)
    {
        var lowerChar = char.ToLowerInvariant(c);

        if (_learningProgress.ContainsKey(lowerChar))
            return _learningProgress[lowerChar];

        if (_alienMapping.ContainsKey(lowerChar))
            return _alienMapping[lowerChar];
        
        return null;
    }

    private T GetRandomUnique<T>(Func<T, bool> condition, Func<T> func)
    {
        T thing;
        do
        {
            thing = func();
        }
        while (condition(thing));
        return thing;
    }
}
