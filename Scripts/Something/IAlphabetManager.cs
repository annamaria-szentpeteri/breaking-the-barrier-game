using Godot;

public interface IAlphabetManager
{
    void GenerateMapping(ulong seed);
    Vector2I? GetVector(char c);
}