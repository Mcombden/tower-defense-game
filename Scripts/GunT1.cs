using Godot;
using System;

public class GunT1 : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	  public override void _Process(float delta)
	{
		Turn();
	}
	
	public void Turn()
	{
//		int enemy_position = get_global_mouse_position();
//		get_node("Turret").look_at(enemy_position);
	}
}
