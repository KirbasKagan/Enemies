![Basic](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/9e8b7fab-2821-4680-9f3e-a0c8a8bc3b20)
![Basic Enemy](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/b5878dbd-b810-435c-a406-d53d2768e1e0)
<br/>
**EnemyAI** <br/>
Target = PlayerGameObject ; The object which AI follow <br/>
Chase Range = Sets the width of the circle ; If the player inside the circle, basic enemy will follow the target (Player) <br/>
Walk Range = must be at least 1000 ; Allows the enemy to walk continuously <br/>
Turn Speed = Is the rate at which the basic enemy turns to the player's face <br/>
Petrolling Speed = Is the speed at which the player navigates the environment without entering the circle or triggering it <br/>
Provoked Speed = Is the speed of the basic enemy when the player enters the circle or is triggered <br/>
<br/>
**Enemy Health** <br/>
Health = Enemy's health <br/>
Blood Stream = This is the blood effect (particle effect) when an enemy dies <br/>
Organ = This is a array which allows organs to eject when enemy dies <br/>
<br/>
**Enemy Attack** <br/>
Damage = Is the damage to player <br/>
<br/>
<br/>
![Blind](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/34c39af8-05a8-46fe-a7ca-33b22842cbcc)
![Blind Enemy](https://github.com/KirbasKagan/Odev2-Branching/assets/121103371/7154fe00-d4ad-4c0b-8141-0a39e8f4c6f2)
<br/>
**Blind Enemy AI**<br/>
Target = PlayerGameObject ; The object which AI follow <br/>
Hear Range = Sets the width of the blue circle ; If player make a noise (throw object, press shift (speed up) or shoot) in blue circle, blind enemy will changes its direction and moves a little in that direction <br/>
Walk Range = must be at least 1000 ; Allows the enemy to walk continuously <br/>
Trigger Range = Sets the width of the red circle ; If player make a noise (press shift (speed up) or shoot) in red circle, blind eney will follow the player until player die or until it dies <br/>
Turn Speed = Is the rate at which the basic enemy turns to the player's face <br/>
Petrolling Speed = Is the speed at which the player navigates the environment without entering the circle or triggering it <br/>
Chase Speed = Is the speed of going to the sound produced in the blue circle <br/>
Trigger Speed = Is the speed of going to the sound produced in the red circle <br/>
<br/>
**Enemy Health** <br/>
Health = Enemy's health <br/>
Blood Stream = This is the blood effect (particle effect) when an enemy dies <br/>
Organ = This is a array which allows organs to eject when enemy dies <br/>
<br/>
**Blind Enemy Attack** <br/>
Damage = Is the damage to player <br/>
<br/>
<br/>
