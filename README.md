# Pac-Man Particle Demo

## Overview
This is a single-level Pac-Man-style game built in **Godot 4.5 mono** using **C#**.  
The project primarily demonstrates **CPUParticle2D particle effects** triggered when the player collects coins.

## Game Structure
The project is structured across several main scripts:

- **Pickup.cs**: Handles coins (`Area2D`) and triggers the **SparkleParticles** CPUParticle2D effect when collected.  
- **Player.cs**: Controls the player character, including movement and collision detection with coins and enemies.  
- **Enemy.cs**: Controls enemy behavior, including movement via `NavigationAgent2D` to follow the player, demonstrating basic **pathfinding**.  
- **GameManager.cs**: Intended to track coins and handle win conditions. Currently, it is not fully implemented and could be expanded to manage scoring, multiple levels, or game-ending logic.

### Future Work
- Implement proper scoring and win/lose conditions in `GameManager.cs`.  
- Add additional particle effects (like GPUParticles2D) or multiple particle triggers.  
- Improve enemy AI, animations, and level design for more polish.  
- Expand UI elements to show coin count and game status.  

## User Interface
- Visual feedback is provided through **SparkleParticles** when coins are collected.  
- Minimal UI focuses on demonstrating the particle effect rather than full gameplay.

## Implementation Notes
- The game runs without errors and includes player movement, collisions, navigation, and particle effects.  
- Classes are structured in a clear, object-oriented manner.  
- Godot features such as `TileMap`, `NavigationAgent2D`, `AnimatedSprite2D`, `CollisionShape2D`, and `CharacterBody2D` are all employed appropriately.  
- The enemy following the player demonstrates **pathfinding** using Godot’s `NavigationAgent2D`.  
- Only **one particle effect** (CPUParticle2D SparkleParticles) was successfully implemented. Attempts to integrate **GPUParticles2D** using C# produced errors.  
- This project demonstrates the basics of Godot 2D gameplay and particle effects without full scoring or polish.

## Conclusion
This project provides a minimal playable game highlighting **interactive particle effects**, object-oriented C# implementation, and proper use of Godot 2D nodes.  
It is a foundation for future improvements, including multiple particle effects, level design, and enhanced game mechanics.
