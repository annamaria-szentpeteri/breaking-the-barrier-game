using Godot;
using System;
using System.Collections.Generic;

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
            Vector2I vector = GetRandomUnique(
                () => new Vector2I(rand.RandiRange(0, AlienAtlasDimension - 1), 
                rand.RandiRange(0, AlienAtlasDimension - 1)), (v) => duplicationChecker.Contains(v));

            duplicationChecker.Add(vector);
            _alienMapping.Add(i, new AtlasVector(AlienAtlasIndex, vector));
        }
    }

    public void LearnRandomCharacter()
    {
        if (_learningProgress.Count == LettersAndSpecialChars.Length)
        {
            GD.Print($"No more characters to learn. Exiting {nameof(LearnRandomCharacter)} method.");
            return;
        }

        var rand = new RandomNumberGenerator();

        var index = GetRandomUnique(
            () => rand.RandiRange(0, LettersAndSpecialChars.Length - 1), 
            (i) => _learningProgress.ContainsKey(LettersAndSpecialChars[i]));

        var character = LettersAndSpecialChars[index];
        var atlasVector = new AtlasVector(OriginalAtlasIndex, new Vector2I(index % OriginalAtlasDimension, index / OriginalAtlasDimension));

        LearnCharacter(character, atlasVector);

        GD.Print($"Random: {index} - {character}");
        GD.Print($"{atlasVector.Id}->({atlasVector.Vector.X},{atlasVector.Vector.Y})");
    }

    public void LearnCharacter(char character, AtlasVector atlasVector)
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

    public AtlasVector GetCharacterVector(char c)
    {
        var lowerChar = char.ToLowerInvariant(c);

        if (_learningProgress.ContainsKey(lowerChar))
            return _learningProgress[lowerChar];

        if (_alienMapping.ContainsKey(lowerChar))
            return _alienMapping[lowerChar];
        
        return null;
    }

    private T GetRandomUnique<T>(Func<T> createInstance, Func<T, bool> condition)
    {
        T instance;
        do
        {
            instance = createInstance();
        }
        while (condition(instance));
        return instance;
    }
}
