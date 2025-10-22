using Godot;
using System;

public partial class Coin : Area2D
{
	private AnimatedSprite2D _anim;
	private CollisionShape2D _collision;

	public override void _Ready()
	{
		// Cache references
		_anim = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
		_collision = GetNodeOrNull<CollisionShape2D>("CollisionShape2D");

		// Play any default animation if needed
		_anim?.Play("default");

		// Connect the body_entered signal
		BodyEntered += OnBodyEntered;
	}

	private void OnBodyEntered(Node body)
	{
		// Only react if the colliding body is in the "player" group
		if (body.IsInGroup("player"))
		{
			GD.Print("+1 Coin");

			// Optional: stop animation
			_anim?.Stop();

			// Remove the coin from the scene
			QueueFree();
		}
	}
}
