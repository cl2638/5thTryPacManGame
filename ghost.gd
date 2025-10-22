extends CharacterBody2D

@export var speed: float = 150.0
@onready var agent: NavigationAgent2D = $NavigationAgent2D
@onready var anim: AnimatedSprite2D = $AnimatedSprite2D
@onready var player: Node2D = null

func _ready():
	anim.play("idle")
	
	# Find the player in the "player" group
	player = get_tree().get_first_node_in_group("player")
	if player:
		agent.target_position = player.global_position

func _physics_process(_delta: float) -> void:
	if not player:
		return

	# Update the agent target
	agent.target_position = player.global_position

	# Get next position along path
	var next_pos = agent.get_next_path_position()
	if next_pos == Vector2.ZERO or agent.is_navigation_finished():
		velocity = Vector2.ZERO
		move_and_slide()
		anim.play("idle")
		return

	# Move toward next position
	var dir = (next_pos - global_position).normalized()
	velocity = dir * speed

	# Move with collisions
	move_and_slide()

	# Animation
	if velocity.length() > 0:
		anim.play("walk")
	else:
		anim.play("idle")

# --- Signal handler ---
# Make sure this is connected in the editor (DetectionArea → body_entered)
func _on_DetectionArea_body_entered(body: Node) -> void:
	if body.is_in_group("player"):
		print("Killed")
