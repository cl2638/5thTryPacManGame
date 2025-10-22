using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public float Speed { get; set; } = 200f;

	private AnimatedSprite2D _anim;

	public override void _Ready()
	{
		_anim = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");

		if (!IsInGroup("player"))
			AddToGroup("player");

		_anim?.Play("idle");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 inputVector = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
			inputVector.X += 1;
		if (Input.IsActionPressed("ui_left"))
			inputVector.X -= 1;
		if (Input.IsActionPressed("ui_up"))
			inputVector.Y -= 1;
		if (Input.IsActionPressed("ui_down"))
			inputVector.Y += 1;

		Velocity = inputVector.Normalized() * Speed;
		MoveAndSlide();

		_anim?.Play("idle");
	}
}
