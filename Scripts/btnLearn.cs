using Godot;
using System;

public partial class btnLearn : Button
{
    [Export]
    public TextBox TextBox { get; set; }

    private bool _isLearning = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        OnPressed();
    }

    public override void _Pressed()
    {
        OnPressed();
    }

    private void OnPressed()
    {
        if (_isLearning)
            return;

        try
        {
            _isLearning = true;

            // TODO MAKE THIS RANDOM
            char randomCharacter = 'a';
            // TODO MAKE THIS DYNAMIC
            AtlasVector atlasVector = new(AlphabetMapper.OriginalAtlasIndex, new Vector2I(0, 0));

            AlphabetMapper.Learn(randomCharacter, atlasVector);
            TextBox.TextChanged();
        }
        finally
        {
            _isLearning = false;
        }
    }
}
