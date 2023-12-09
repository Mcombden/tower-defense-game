extends Node2D

var map_node # Stores name of current map node

var build_mode = false
var build_valid = false
var build_location
var build_type

var current_wave = 0
var enemies_in_wave

func _ready():
	map_node = get_node("Map")
	# Attaching all build buttons from build buttons group programatically
	for i in get_tree().get_nodes_in_group("build_buttons"):
		i.connect("pressed", self, "initiate_build_mode", [i.get_name()])
	start_next_wave()
	
func _process(delta):
	if build_mode:
		update_tower_preview()

# is called when input is not otherwise consumed by other ui function 
func _unhandled_input(event):
	if event.is_action_released("ui_cancel") and build_mode == true:
		cancel_build_mode()
	if event.is_action_released("ui_accept") and build_mode == true:
		verify_and_build()
		cancel_build_mode()
	
######### Wave Functions ########
func start_next_wave():
	var wave_data = retrieve_wave_data() 
	yield(get_tree().create_timer(0,2),"timeout") # Padding between waves
	spawn_enemies(wave_data)

func retrieve_wave_data():
	var wave_data = [["Ship", 1.7], ["Ship", 1.7], ["Ship", 2.9]]
	current_wave += 1
	enemies_in_wave = wave_data.size()
	return wave_data
	
func spawn_enemies(wave_data):
	for i in wave_data:
		var new_enemy = load("res://Assets/Enemies/Ship.tscn").instance()
		map_node.get_node("Path2D").add_child(new_enemy, true)
		yield(get_tree().create_timer(i[1]),"timeout")
		
	
######## Build Tower Functions #######
func initiate_build_mode(tower_type):
	build_type = tower_type + "T1"
	build_mode = true;
	get_node("UI").set_tower_preview(build_type, get_global_mouse_position())
	
func update_tower_preview():
	var mouse_position = get_global_mouse_position()
	var current_tile = map_node.get_node("TileMaps/TowerExclusion").world_to_map(mouse_position) # Get coordinate of current tile
	var tile_position = map_node.get_node("TileMaps/TowerExclusion").map_to_world(current_tile) # Snaps image to current tile
	
	if map_node.get_node("TileMaps/TowerExclusion").get_cellv(current_tile) == -1:
		get_node("UI").update_tower_preview(tile_position,"c939ea61") # Green: c939ea61  Red: c1d01a1a
		build_valid = true;
		
		build_location = tile_position
	else:
		get_node("UI").update_tower_preview(tile_position,"c1d01a1a")
		build_valid = false

func cancel_build_mode():
	build_mode = false
	build_valid = false
	get_node("UI/TowerPreview").queue_free()
	
func verify_and_build():
	if build_valid:
		# Test to verify player has enough money
		var new_tower = load("res://Scenes/entities/CannonT1.tscn").instance()
		new_tower.position = build_location
		map_node.get_node("Towers").add_child(new_tower, true)
		
		# Deduct cash
		# Update UI Label
		
		
