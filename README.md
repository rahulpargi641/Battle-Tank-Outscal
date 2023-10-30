# Battle-tank-game-Outscal

### Introduction
    Battle Tank is a 3D tank game where the player's tank infiltrates enemy territory and must eliminate 
    patrolling enemy tanks. This project prioritizes maintaining code quality and ensuring the game's 
    adaptability for future enhancements.

### Features    
    Core Gameplay:
    - Player tank actions include moving, rotating, and shooting shells.
    - Two types of attacks:
       - Short Range Attack (fire shells from close distance)
       - Ranged Attack (Hold down the left click and shoot shells from greater distance)

    Enemy AI:
    - Enemies patrol the area and chase you when detected, attacking until you are defeated.
    
    Dynamic Camera System:
    - A seamless camera system tracks the player tank's movements smoothly.
    - When enemies are detected, the camera focuses on them, returning to the normal view when 
      you are no longer detected.
    
    User Interface (UI):
    - Visually appealing Main Menu, Pause Menu, Game Over, and Level Complete screens.
    - The Pause screen offers convenient options for resuming the game or quitting.
    
### Screenshots

   (Insert screenshots)
  
### Code Structure and Game Design
#### Code Structure

    MVC-S (Model-View-Controller-Service):
        - The codebase is organized using the Model-View-Controller-Service (MVC-S) architectural pattern.
        - This approach maintains a clear separation of concerns:
           - The Model manages data.
           - The View is responsible for UI-related tasks and input handling.
           - The Controller is responsible for updating both the View and Model.
        - Classes for PlayerTank, EnemyTank, Camera, Shell, Level, GameUI, have been implemented
          following the MVC pattern.

    Singletons:
        - Centralized control is ensured through the implementation of Singleton patterns.
        - Essential services such as PlayerService, EnemyService, PickupsService(Healing Orb), 
          DamageOrbService(FireOrb), GameService, CameraService, ShellService, ParticleSystem Service, 
          AudioService, GameUIService, LevelService are designed as Singletons.
          
    State Pattern:
        - Utilized the state pattern to manage player and enemy states.
          - Player States : Idle, run, roll, attack, dash attack, hurt, and death.
          - Enemy States: Idle, run, patrol, pursue, hurt, and death.
    
    Observer Pattern:
        - Employed the observer pattern to decouple classes and facilitate event handling for events such as 
          player death, enemy hit, enemy death, and enemy group death.
        - This facilitates the activation of the game over screen and the opening of the gate when the enemy 
          group is defeated.

    Scriptable Objects:
         - Scriptable objects were utilized to configure player and enemy data, providing a flexible and 
           efficient approach for handling their attributes.
       
#### Performance Optimization:
    - To optimize performance, object pooling is implemented for enemies, damage orbs, pickups, and various 
      VFX, effectively managing memory and CPU usage.

#### Level Design:
    - Created using Unity's Battle Tank base artwork.
    - Strategically positioned enemy tanks to all the patrollig area so intruders can't infiltrate the area.

#### Enchanced Camera Tracking
    - Employed Cinemachine to smoothly follow the player. 

#### Animations:
    - The Player Animator handles character animations such as Idle, Run, Roll, attack, and Hurt.
    - The Enemy Animator, derived from the Player Animator, handles animations such as idle, run, and attacks.
    
### Focus
    - Code Quality and Organization.
    - Architecture Design for Flexibility and Scalability.
    - Visually appealing with high-quality 3D graphics and immersive sound effects.
    
### Gameplay Demonstration
    For a visual demonstration of the gameplay, watch video on YouTube.
    
### Play the Game
    To experience the game firsthand, play it directly by following this playable link.

### Credits
#### Assets
- Character Models and Game Map: [Instructor's Name](link-to-instructor-profile)
