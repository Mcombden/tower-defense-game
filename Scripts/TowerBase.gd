extends Node2D


func _physics_process(delta): # Default process 60 times per second
	turn()

func turn():
	var enemy_position = get_global_mouse_position()
	get_node("Cannon").look_at(enemy_position)
