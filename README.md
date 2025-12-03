John Lemon Haunted House project by Gregory Garren, Triston Passmore, & Fredrick Clay

What are the modifications you made to the game?
MINOR MOD: You add a speed boost to the game. While the player is holding down a button, the character moves faster. 

A Sprint feature has been implemented that multiplies player movement by 1.5x when holding the Left Shift key.

MAJOR MOD: You create a shield power-up. If John Lemon picks it up, he can collide with a Ghost and destroy it. The shield should have a visual indicator.

Using a shield model from Unity's Asset Store, we implemented 2 scripts, 1 for the player that allows them to interact with the shield pickup 
on the ground via triggers and 1 for the Shield item itself that allows itself to be picked up. 
We also altered the original "Observer" script to allow for enemies to ignore the player whenever the player has a shield equipped, which then removes
the shield if "spotted." The Shield pickup has particle effects around it when on the ground as well as a 3D bubble around the player once equipped.

ADDITIONAL: 
- Changes to Time of Day Lighting
- Heavy Post-Processing changes including alterned vignette, color grading, shadow depth, and anti-aliasing
- Background Music

GITHUB REPOSITORY LINK: https://github.com/Greg00811/3D-Stealth-Haunted-House-Game

GAMEPLAY VIDEO LINK: https://youtu.be/eXJDM95jDLg?si=3XlcUD3RDrAw4BeG
