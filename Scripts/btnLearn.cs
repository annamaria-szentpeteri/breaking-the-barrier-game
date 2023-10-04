using Godot;

public partial class btnLearn : Button
{
    [Export]
    public TextBox TextBox { get; set; }

    private bool _isLearning = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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
            AlphabetMapper.LearnRandomCharacter();
            TextBox.TextChanged();
        }
        finally
        {
            _isLearning = false;
        }
    }
}
