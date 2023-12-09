using Godot;
using System;

public class ui : CanvasLayer
{
	Label health_label;
	Label coins_label;

	public override void _Ready()
	{
		//health_label = GetNode<Label>("Control/Health");
		//coins_label = GetNode<Label>("Control/Coins");
	}

	public void _update_health_label(int health)
	{
		if(health_label == null)
		{
			//health_label = GetNode<Label>($"Control/MarginContainer/VBoxContainer/HBoxContainer/Health");			
		}
		else
		{
			health_label.Text = health.ToString();
		}
	}
	
	public void _update_coins_label(int coins)
	{
		coins_label.Text = coins.ToString();
	}
}
