using Godot;
using System;

public partial class LanguageCharacter : Sprite2D
{
	private RandomNumberGenerator _randomNumberGenerator = new();
	private int _maxCharacterNumber  = 0;

	public override void _Ready()
	{
		_randomNumberGenerator.Randomize();
		_maxCharacterNumber = this.Vframes * this.Hframes - 1;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(InputMapActions.Interact))
		{
			ChangeCharacter();
		}
	}

	private void ChangeCharacter()
	{
		var newFrame = _randomNumberGenerator.RandiRange(0, _maxCharacterNumber);
		this.Frame = newFrame;
	}
}
