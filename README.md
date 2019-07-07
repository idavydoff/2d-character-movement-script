## Unity 2D Movement C# Script

#### This script allows you to control your character using 3 keys:
1. [A] - move left.
2. [D] - move right. 
3. [Space] - jump.

#### How to use?
**Your ground objects and your character should have colliders and RigidBody2D component (RigidBody2d should have a body type "Dynamic").**

##### Step 1
Set the same layer to every ground object.  This is needed to let the script know when the charecter is on the floor so it can jump.
![](https://i.imgur.com/3lVkzur.jpg)

##### Step 2
Add a child object to your character object which will check if the character is on the ground.
![](https://i.imgur.com/ckeaurU.jpg)

And place it under your character.
![](https://i.imgur.com/SwmVsPs.png)

##### Step 3
Drag and drop your script to your character components.
![](https://i.imgur.com/uh6jfIm.jpg)

##### Step 4
Set the script variables to your values.  
P.S. Jump sprite is optional (Look code).
![](https://i.imgur.com/tVaBHPh.png)
