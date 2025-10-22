using Godot;
using System;

public partial class GameManager : Node2D
{
	[Export] public int CoinsToWin { get; set; } = 3;
	private int _coinsCollected = 0;

	// Reference to Label node in the scene to display messages
	[Export] public Label WinLabel;

	public void CoinCollected()
	{
		_coinsCollected++;

		if (_coinsCollected >= CoinsToWin)
		{
			WinGame();
		}
	}

	private void WinGame()
	{
		// Stop the entire game ( can disable player input)
		foreach (Node node in GetTree().GetNodesInGroup("player"))
		{
			if (node is Player player)
				player.Speed = 0;
		}

		// Display win message
		if (WinLabel != null)
		{
			WinLabel.Text = "You Win!";
			WinLabel.Visible = true;
		}

		GD.Print("You Win!");
	}
}
