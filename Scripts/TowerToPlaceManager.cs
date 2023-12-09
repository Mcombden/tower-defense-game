using Godot;
using System;

public class TowerToPlaceManager : Node2D
{
	// Building placement colors
	private static Color _COLOR_VALID = new Color("#4ef544");
	private static Color _COLOR_INVALID = new Color("#f55544");
	
	private ShaderMaterial _spritesMaterial;
	
	// Tower Parameters
	public float radius = 400f; // in pixels
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

//
	}

	public void SetValid(bool isValid)
	{
		Color c = isValid ? _COLOR_VALID : _COLOR_INVALID;
		_spritesMaterial.SetShaderParam("tint", c); 
	}

}
