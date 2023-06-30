![Basic](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/9e8b7fab-2821-4680-9f3e-a0c8a8bc3b20)
![Basic Enemy](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/b5878dbd-b810-435c-a406-d53d2768e1e0)

EnemyAI
Target = PlayerGameObject ; The object which AI follow
Chase Range = Sets the width of the circle ; If the player inside the circle, basic enemy will follow the target (Player)
Walk Range = must be at least 1000 ; Allows the enemy to walk continuously
Turn Speed = Is the rate at which the basic enemy turns to the player's face
Petrolling Speed = Is the speed at which the player navigates the environment without entering the circle or triggering it
Provoked Speed = Is the speed of the basic enemy when the player enters the circle or is triggered

Enemy Health
Health = Enemy's health
Blood Stream = This is the blood effect (particle effect) when an enemy dies
Organ = This is a array which allows organs to eject when enemy dies

Enemy Attack
Damage = Is the damage to player
