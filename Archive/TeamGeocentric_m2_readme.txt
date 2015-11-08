i. NAMES
    Ben Seco, ben.seco@gatech.edu, ~Bseco3
    Monet Tomioka, mtomioka3@gatech.edu, ~Mtomioka3
    Cora Wilson, cwilson79@gatech.edu, ~cwilson79
    Collin Caldwell, ccaldwell@gatech.edu, ~Ccaldwell
    Kody Laseter, klaseter@gatech.edu, ~Klaseter

ii. REQUIREMENTS COMPLETED
    Basic Physics Interaction: main character has a rigid body along with many other objects in the game, causing collision along with other events depending on the colliding object.
    Collider Animation: main character has a collider that changes shape when he jumps. (Not easy to see, try selecting the Rex object and watch the collider change shape while you play.)
    Ragdoll Simulation: pressing the backspace key makes our main character ragdoll, although there are some known bugs with this (sometimes falls through the floor).
    Game Feel: our game controls are responsive and characters have a personality. Rex is a carefree adventurer that travels to unknown lands in search of the missing things.

Known bug: Rex can play footstep sounds if he starts his walk animation while falling.

iii. RESOURCES
    We made most of our assets using Blender, Adobe Photoshop, and music synthesizing software (Sekaiju and Audacity). All textures within Assets/Textures/: are hand-made. Within Assets/Music/SoundEffects: all sound files except those in collinGrass/ and collinStone/ were hand-made.

Sound effects for Collin’s scene are from The Legend of Zelda: Wind Waker. They were found here: http://www.sounds-resource.com/gamecube/legendofzeldathewindwaker/

iv. No Specific install instructions.


v. DETAILED STEPS
    Keys 1 through 5 are bound with all group members' gardens. The key bindings are as follows:
    1: Ben Seco
    2: Collin Caldwell
    3: Cora Wilson
    4: Kody Laseter
    5: Monet Tomioka

Controls:
WASD : Move
IJKL : Camera
Shift : Spin
QE : Cycle Items
R : Place Item

Specific Scene Instructions:
Ben Seco’s Starry Nightmare:
5 Unique actors: 
(1) The Ball Pit: inside, you’ll find marbles to roll around in.
(2) The Rug: A shallow closet covered by a cloth. The cloth waves as Rex moves through it.
(3) The Balance: A set of two hinged platform that play different footstep sounds when you walk over them. 
(4) The Quadsaw: A set of four hinged platforms acting like trampolines.
(5) The Egg (it rolls).

2 Compound objects: The Balance and the Quadsaw are both hinged/compound.

Variable height terrain: There are several platforms across the garden that the player can jump up to.

Material sound: I have footstep sounds for the snow terrain, the stairs, and the trampoline. I also have a death sound that plays once upon hitting the ground floor.
	
Game feel: Everything in the level is physics-interactive except some stationary platforms. As an additional level of polish, I implemented custom textures, normal maps for some of the textures, and a custom skybox--to give the nightmare a characteristic trapped feeling.

Collin Caldwell’s Forest Garden:
	Guide to Level: Use Rex’s spin with SHIFT to smack objects around the level. You can spawn either a ragdoll or a bomb (bombs blow up after 2 seconds) by pressing R, switch between the two with Q and E. Travel around the level and smack the swing, flowers, spheres, and cubes. Place a lot a ragdolls and blow them up with a bomb! It’s fun!
	Actors: 
		- Flowers (can smack the petals off with shift)
		- Swing to the right of spawn (contains joint) 
(spin into it!)
		- Spheres at top of tower
		- Bomb in inventory (contains character joint in fuze)
		- Ragdolls in inventory (contains character joints)
		- Blocks at the top of the tower (BOMB THEM!)
		- “Best Level” sign on my tower that shows that my level is the best level. You can push it to display it proudly. (its got a hinge joint too)
	Material Sounds:
		Grass and Stone sounds from Wind Waker. Can be found on main island and tower.
	Game Feel:
			You can smack stuff and it reacts! WOWEE!

Cora Wilson’s Lava/Fire:
	Guide: Rex finds himself on the top of a spire, looking out over an arena with lava and cracked earth. Here he can climb great heights and use his new plank block to avoid the dangerous lava, allowing him to build and explore to his heart’s content!
	
	First use WASD to push the bridge down to see a hinged object. Then run across to the central platform. Jump down to one of the sections that has a faint circle in it. Stepping on the circle will demonstrate a new sound. Use E to select the plank object and use R to spawn them. Jump on these planks to cross the lava stripes safely. Traverse to one of the sections that has a seesaw. Create cube objects to weigh a side down, allowing you to jump on top of the spires again. Run to the red curtains (carefully, avoiding lava). Run through the curtains to see them wave. Last, run into the lava to hear a death sound, a fire particle effect, and to see Rex become a ragdoll.
	
Actors:
On the platform Rex first spawns is a bridge that can be pushed down to connect the spire with the central platform.
There are several red cloth banners hanging from the central platform of the level. Rex can run into these and they will flow about him. Careful not to run into the lava closeby, however.
Rex can spawn two types of objects: A cube and a plank. Once spawned, these are physics objects that can be run into and moved through collision.
There are several seesaws throughout the level to allow the player to get across lava rivers or to get to the top of spires.
The lava will set you on fire, turn you into a ragdoll, and send you flying up.

		Compound Objects With Joints:
There are multiple seesaws on the ground that have a joint that they rotate about.
On the spire Rex spawns on, there is a bridge that can be pushed down. It rotates about a joint on the spire.
	
		Variable Height Terrain:
The seesaws provide Rex with opportunities to walk up and down ramps. You could also create stairs with the blocks and planks to jump on if you wanted.

		Material Sounds:
The blackened ground plays a low bell sound.
The grey seesaws, bridge, and spawned planks play a piano footstep.
Stepping on lava emits a scary game over sound.
The cracked earth circles emit an echoing sound.
	
		Game Feel Polish:
Fire flares up around the spot where Rex dies in lava. The red banners can be pushed about. Rex can use and create platforms to get over lava rivers	to fully explore the area!

Kody Laseter’s Scary Cave:
	Guide: Explore the level! Walk toward the ramps and lava. Watch out for the boulder! Jump over the lava. Continue forward and jump up the platforms. Dodge the swinging block to reach the second to last platform. Knock over the hinged block to reach the final platform. 
	5 Unique Actors: The ball that flies at you can knock you around. The swinging block can also knock you down. The hinged platform at the end of the platforms must be pushed over in order to reach the final platform. The dumbbell and jack that you can spawn can also be moved around (use R to spawn objects, E to switch between them)
	2 Compound Objects: The swinging block and the hinged platform
	Variable Height Terrain: Pretty apparent all throughout the level, lots of platforms and hills and ramps.
	Material Sounds: Walking on the regular terrain and platforms has one distinct piano-like sound. Walking on the ramps over the lava has a deeper sound. Touching the lava causes a death tone (beware sometimes you fly through the ground as we have not perfected ragdolls).
	Game Feel: The lighting and surroundings give the feel of a creepy cave. The lava is scary and has fancy lighting and particle effects to accompany it.

Monet Tomioka’s Snowy Birch Wonderland:
	5 Unique actors: The platform you start off on is covered in snow. When you walk in snow, your speed is cut in half (1). When you walk up the platforms you will reach the trampoline (2); it has a physics material attached to it that makes the surface bounce. On top of the trampoline resides 2 objects, a bouncing ball and a dog (3); these objects can be pushed as it has rigid bodies and colliders on them. You can also spawn cubes by pressing the R key on your keyboard (4); these can be pushed around, stacked, etc. Finally when you fall off either of the main platforms you will hit the ground floor which will cause a death animation, sound, trigger the character to ragdoll, and will reset the level (5).
	2 Compound objects: At the start area there will be a pole with a checkered flag on it. This flag is hinged onto the pole, so it can be pushed and it will swing around it (1). Another hinged object is the seesaw next to the stairs (2). The rectangle is hinged to the circle below it.
	Variable height terrain: I made stairs that need to be climbed so a player can reach the trampoline as well as the ground floor below that causes death.
	Material sound: I have footstep sounds for the snow terrain, the stairs, and the trampoline. I also have a death sound that plays once upon hitting the ground floor.
		Game feel: Rex is exploring a mysterious, floating island full of snow and wonders. He meets a new friend, Dog, having a great time on a trampoline. Little did he know what troubles he would face trying to get down to solid ground... The bright lights and colors produce a lighthearted atmosphere, until you fall to the ground. The gap between the cutesy game and the punishing, dark death animation gives off an uneasy, almost creepy feeling to the stage. The scene is reactive in that it produces different sounds on different terrain and some objects are pushable.


vi. FIRST SCENE TO LOAD
    When you first build the game, you will start in LevelSelect.scene.

vii. GAME URL
    http://www.prism.gatech.edu/~ccaldwell9/gamegarden.html
