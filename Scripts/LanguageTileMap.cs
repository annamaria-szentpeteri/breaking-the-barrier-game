using Godot;
using System;

/*
 * ToDo:
 * Word wrap
 * 
 * ToDo:
 * Line break at linebreak character
 */
public partial class LanguageTileMap : TileMap
{
    [Export]
    public int CharacterPerLine = 20;

	private string _textToCode;
	[Export]
	public string TextToEncode { 
		get 
		{
			return _textToCode; 
		}

		set
        {
            TextChanged(_textToCode, value);
            _textToCode = value; 
		}
    }

    private readonly IAlphabetManager _alphabetMapper = DIContainer.GetService<IAlphabetManager>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		TextChanged(null, _textToCode);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void TextChanged(string oldText, string newText)
    {
        if (!IsNodeReady())
            return;

        CleanText(oldText);
        CreateText(newText);
    }

    private void CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;

        for (int i = 0; i < text.Length; i++)
        {
            CleanCell(i);
        }
    }

    private void CreateText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return;

        for (int i = 0; i < text.Length; i++)
        {
            var atlasVector = _alphabetMapper.GetVector(text[i]);

            if (atlasVector == null)
            {
                CleanCell(i);
            }
            else
            {
                this.SetCell(0, GetCellVector(i), atlasVector.Id, atlasVector.Vector);
            }
        }
    }

    private void CleanCell(int index)
    {
        this.SetCell(0, GetCellVector(index), -1);
    }

    private Vector2I GetCellVector(int index) 
    {
        return new Vector2I(index % CharacterPerLine, index / CharacterPerLine);
    }
}
