# Open Player Controller - A Free and Open Source Character Controller alternative for Unity Engine

##What is Open Player Controller?
Open Player Controller (OPC for short) is an open source Character Controller that makes a use of RigidBodies to move player around the scene.
<br>Built from the ground up with C#, OPC is a flexible character system which can be inmplemented into any type of project (FPS only currently).
Its Modular system is one of the biggest perks. E.g, if you don't want your player to jump in your game/level, simply remove the script and OPC will do the rest.

##Why does this project exist?
While the new RigidBody based Character Controller developed by Unity is a neat script, scripts are too complex and there are sometimes features that developer doesn't need.
<br>Sure there are some good alternatives out there on the Asset Store, but they're costly and, to some extent, are complex too. <br><br>OPC is aimed to be used by beginner/professional indie developers who want to create a quick prototype for their games in Unity Engine.

##How can I help this project?
Open Player Controller is an open source project. 
Fork it as your own repository to make any modifications you want. Let's make OPC better together for everyone!
<br><br>
You're free to retain them and use for both commercial and non-commercial purposes (apart from directly selling scripts). 
<br><br>OPC is licensed under <a href="https://github.com/elmar1235/OpenPlayerController/blob/master/LICENSE.md" target+"_blank">MIT License</a>.

#Features
Open Player Controller is currently is in active development (as of August 2016) with current  subject to alteration and implementation of future ones.
<br>For most up-to-date features, take a look at a <a href="https://trello.com/b/GXjWg5oO" target+"_blank">Trello Board</a>.

##Current Features
* RigidBody based Player Locomotion
* Push other RigidBody objects with Player's mass
* Crouching - player can crouch underneath low objects by holding down Left Control button. Player's camera, and its collider, and movement speed, react to crouching
* Jumping (incomplete) - player can jump around

##Planned Features
* Player Prone
* Climbing Ladders
* Walking on Stairs without any need of an invisible ramp
* Swimming
* React to falling from high places (e.g fall damage)
* React to being crushed by a RigidBody Object taking its mass into consideration
* React to having a RigidBody Object thrown at taking its mass into consideration
