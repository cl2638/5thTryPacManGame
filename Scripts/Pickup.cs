using Godot;
using System.Threading.Tasks;

public partial class Pickup : Area2D
{
	[Export] public PackedScene ParticlesScene;
	private CollisionShape2D _collision;

	public override void _Ready()
	{
		_collision = GetNodeOrNull<CollisionShape2D>("CollisionShape2D");
		BodyEntered += OnBodyEntered;
	}

	private async void OnBodyEntered(Node body)
	{
		if (body.IsInGroup("player"))
		{
			if (ParticlesScene != null)
			{
				var particlesNode = ParticlesScene.Instantiate() as CpuParticles2D;
				if (particlesNode != null)
				{
					particlesNode.GlobalPosition = GlobalPosition;
					particlesNode.Emitting = true;
					GetParent().AddChild(particlesNode);

					await Task.Delay((int)(particlesNode.Lifetime * 1000));
					particlesNode.QueueFree();
				}
			}

			GD.Print("+1 Coin");

			// Tell GameManager
			var gm = GetTree().Root.GetNodeOrNull<GameManager>("GameManager");
			gm?.CoinCollected();

			QueueFree();
		}
	}
}
