using Godot;
using System;

public class ShipManager : PathFollow2D
{
	private PathFollow2D _pathFollow;
	
	// Ship Parameters
	private float _speed = 1f;
	public int HP = 1;
	public int Damage = 1;
	
	public override void _Ready()
	{
		_pathFollow = GetNode<PathFollow2D>(GetPath());
	}
	
	
	public override void _Process(float delta)
	{  
		_pathFollow.UnitOffset += delta	* _speed * 0.07f;
		
		if(_pathFollow.UnitOffset >= 1)
		{
			Pass();	
		}
	}
	
	private void Pass()
	{
		GameManager.instance.OnShipPassed(this);
		// Deleting object to free up resources
		QueueFree();
	}
}

