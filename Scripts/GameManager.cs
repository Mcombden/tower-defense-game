using Godot;
using System;

public class GameManager : Node
{
	public static GameManager instance;

	private Label _coinsLabel;
	private Label _livesLabel;
	
	private int _coins = 40;
	private int _lives = 50;
	
	// Called when a node is added to the scene tree for the first time
	public override void _Ready()
	{
		instance = this;
		_coinsLabel = GetNode<Label>("CanvasLayer/UI/Stats/Coins/CoinsLabel");
		_livesLabel = GetNode<Label>("CanvasLayer/UI/Stats/Lives/LivesLabel");
		UpdateUI();
	}

	public void UpdateUI()
	{
		_coinsLabel.Text = "COINS: " + $"{_coins}";
		_livesLabel.Text = "LIVES: " + $"{_lives}";
	}

	public void OnShipPassed(ShipManager ship)
	{
		_lives -= ship.Damage;
		UpdateUI();
	}
	
	public void OnTowerPurchase()
	{
		
	}
}
