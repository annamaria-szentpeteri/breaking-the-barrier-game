using Godot;
using System;

public partial class TextBox : CanvasLayer
{
	[Export]
	LanguageTileMap LanguageTileMap { get; set; }
	[Export]
	TextEdit TextToEncode { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		TextToEncode.TextChanged += TextChanged;
		TextChanged();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TextChanged()
	{
		LanguageTileMap.TextToEncode = TextToEncode.Text;
	}
}
