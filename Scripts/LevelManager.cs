using Godot;
using System;

public class LevelManager : Node2D
{
	[Export] private PackedScene _shipAsset;
	[Export] private PackedScene _towerAsset;
	private TowerToPlaceManager _towerToPlace;
	
	private Path2D _path;
	private bool _isBuilding;
	private bool _canPlaceTower;
	
	private TileMap _landTilemap;
	private float _cellRound;
	private Vector2 _cellOffset;
	private bool _towerHasValidPlacement;
	
	public override void _Ready()
	{
		_path = GetNode<Path2D>("Path2D");
		_towerToPlace = GetNode<TowerToPlaceManager>("/root/SceneHandler/Map/TowerToPlace");
		_landTilemap = GetNode<TileMap>("TileMaps/Land");
		
		// Maps tiles programmatically
		_cellRound = _landTilemap.CellSize.x;
		_cellOffset = 0.5f * new Vector2(_cellRound, _cellRound);
		
		//SetIsBuilding(false);
		
	}
	
	private void _OnEnemySpawn()
	{
		Node ship = _shipAsset.Instance();
		_path.AddChild(ship);
	}
	
	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == 1 && 
		!eventMouseButton.Pressed)
		{
			// Mouse Pressed
			
		}
		else if(@event is InputEventMouseMotion eventMouseMove)
		{
			// Mouse Movement 
			Vector2 mousePos = GetGlobalMousePosition();
			_towerToPlace.Position = mousePos;
			
		}
	}
	
}
