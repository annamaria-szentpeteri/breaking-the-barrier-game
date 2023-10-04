using Godot;

public interface IAlphabetManager
{
    void GenerateMapping(ulong seed);
    AtlasVector GetCharacterVector(char c);
    void LearnRandomCharacter();
    void LearnCharacter(char character, AtlasVector atlasVector);
}