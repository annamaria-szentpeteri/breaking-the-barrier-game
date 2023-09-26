using Godot;
using System;

public partial class GenerateMappingButton : Button
{
    [Export]
    public TextBox TextBox { get; set; }

    private bool _isGenerating = false;

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
        if (_isGenerating)
            return;

        /* 
         * ToDo:
         * Seed will be provided by user.
         *   
         */
        ulong seed = new RandomNumberGenerator().Randi();

        try
        {
            _isGenerating = true;
            AlphabetMapper.GenerateMapping(seed);
            TextBox.TextChanged();
        }
        finally
        {
            _isGenerating = false;
        }
    }
}
