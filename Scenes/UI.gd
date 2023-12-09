extends CanvasLayer

var tower_range = 350

func set_tower_preview(tower_type, mouse_position):
	# Loading cannon scene as tower drag icon
	var drag_tower = load("res://Scenes/entities/CannonT1.tscn").instance() 
	drag_tower.set_name("DragTower")
	drag_tower.modulate = Color("c939ea61") # Green: c939ea61 Red: c1d01a1a
	
	# Adding tower range overlay
	var range_texture = Sprite.new()
	range_texture.position = Vector2(32,32) # Set offset to tower offset
	
	var scaling = tower_range / 600.0
	range_texture.scale = Vector2(scaling, scaling)
	
	var texture = load("res://Assets/Map/Tilesets/range_overlay.png")
	range_texture.texture = texture
	range_texture.modulate = Color("c939ea61") # Green
	
	var control = Control.new() # Creating control node
	control.add_child(drag_tower, true) # Adding new tower drag icon to control node
	control.add_child(range_texture, true) # Adding new tower drag icon to control node
	control.rect_position = mouse_position # Setting position of control node to mouse
	control.set_name("TowerPreview")
	
	add_child(control, true) # Adding child to parent Canvas Layer
	move_child(get_node("TowerPreview"), 0)

func update_tower_preview(new_position, color):
	get_node("TowerPreview").rect_position = new_position
	if get_node("TowerPreview/DragTower").modulate != Color(color):
		get_node("TowerPreview/DragTower").modulate = Color(color)
		get_node("TowerPreview/Sprite").modulate = Color(color)
