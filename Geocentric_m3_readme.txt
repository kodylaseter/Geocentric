Team Geocentric README

i. NAMES
    Ben Seco, ben.seco@gatech.edu, ~Bseco3
    Monet Tomioka, mtomioka3@gatech.edu, ~Mtomioka3
    Cora Wilson, cwilson79@gatech.edu, ~cwilson79
    Collin Caldwell, ccaldwell@gatech.edu, ~Ccaldwell
    Kody Laseter, klaseter@gatech.edu, ~Klaseter

ii. REQUIREMENTS COMPLETED (Option 1)
    1) RAIN AI Navigation Mesh in Scenes 1 and 3
    2) 2 Navigation Targets in Scene 2
    3) Waypoint Network in Scene 3
    4) Waypoint Route in Scene 1, 2, and 3
    5) All AIs use Mechanim Motors to control motion
    6) All AIs use Mechanim Animators, but in Scene 1, the Dog uses an Animation State to control its idle state.
    7) Custom RAIN AI Element: the Dog in Scene 1 uses a position prediction method to intercept the player by extrapolating the player's next movements.
    8) 3 NPC AIs with unique behavior trees:
        Scene 1: Dog
        Scene 2: Hopper
        Scene 3: Tank
    9) NPCs support game feel by being responsive to player interaction and providing polish.
    KNOWN BUGS
    -The ragdoll function can still clip you through the floor.

iii. RESOURCES
    We made all materials we are using in the game, including all the character models, items, UI components, and audio. We used Adobe Photoshop, Paint Tool SAI, Blender, and Sekaiju.

iv. INSTALL INSTRUCTIONS
    There are no special install instructions for our game.

v. GRADING STEPS
    When you start the game, a menu will pop up, letting the user choose to either start the game or select a specific level to play. Starting the game will put you in Scene 1. From there, the user can interact with the AI and objects in Scene 1. Staying a far distance from the Dog will allow it to patrol its waypoint area. If the player gets closer, the Dog will detect the player and will walk towards you. It will try to intercept the player by using a custom RAIN AI component that predicts your future position off of your current velocity. When the Dog catches up to you, it will enter its idle state via its RAIN AI Mechanim Animation State. The user may press the number keys 1, 2 and 3 to switch to Scene 1, 2 or 3, respectively. In Scene 2, the Hoppers will patrol their Waypoint Routes. If the player gets close, they will run away to one of 2 Navigation Targets. They select the Navigation Point to run to randomly. In Scene 3, the Tank patrols his area. When the player is within his line of sight, the Tank will aggressively chase the player. If you manage to get away from him, he will search for the player in a Waypoint Network. After a short period of time of not finding the player, he will return to his Patrol Route.

vi. STARTING SCENE

    Start in StartMenu.unity.


vii. URL
    http://www.prism.gatech.edu/~ccaldwell9/m3ai.html