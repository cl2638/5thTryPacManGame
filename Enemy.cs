using Godot;

public partial class Enemy : CharacterBody2D
{
	[Export] public float Speed = 150f;
	[Export] public Node2D Player;
	[Export] public NavigationAgent2D NavigationAgent;

	private AnimatedSprite2D _anim;
	private float _killCooldown = 0f;
	private const float KillInterval = 1f;

	public override void _Ready()
	{
		_anim = GetNodeOrNull<AnimatedSprite2D>("AnimatedSprite2D");
		_anim?.Play("idle");

		if (Player == null)
			Player = GetTree().GetFirstNodeInGroup("player") as Node2D;

		if (NavigationAgent == null)
			NavigationAgent = GetNodeOrNull<NavigationAgent2D>("NavigationAgent2D");

		CallDeferred(nameof(SetMovementTarget));
	}

	private void SetMovementTarget()
	{
		if (Player != null)
			NavigationAgent.TargetPosition = Player.GlobalPosition;
	}

	public override void _PhysicsProcess(double delta)
	{
		_killCooldown -= (float)delta;

		if (Player == null || NavigationAgent == null)
			return;

		NavigationAgent.TargetPosition = Player.GlobalPosition;

		if (NavigationAgent.IsNavigationFinished())
		{
			Velocity = Vector2.Zero;
			MoveAndSlide();
			_anim?.Play("idle");
			return;
		}

		Vector2 dir = (NavigationAgent.GetNextPathPosition() - GlobalPosition).Normalized();
		float moveSpeed = Speed * 0.2f;
		Velocity = dir * moveSpeed;

		MoveAndSlide();

		if (Velocity.Length() > 0)
			_anim?.Play("walk");
		else
			_anim?.Play("idle");

		var collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null)
		{
			var colliderNode = collision.GetCollider() as Node;
			if (colliderNode != null && colliderNode.IsInGroup("player") && _killCooldown <= 0f)
			{
				GD.Print("Player hit by enemy!");
				_killCooldown = KillInterval;
			}
		}
	}
}
