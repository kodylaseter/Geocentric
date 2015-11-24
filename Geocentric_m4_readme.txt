Team Geocentric Milestone 4 README

i. NAMES
    Ben Seco, ben.seco@gatech.edu, ~Bseco3
    Monet Tomioka, mtomioka3@gatech.edu, ~Mtomioka3
    Cora Wilson, cwilson79@gatech.edu, ~cwilson79
    Collin Caldwell, ccaldwell@gatech.edu, ~Ccaldwell
    Kody Laseter, klaseter@gatech.edu, ~Klaseter

ii. REQUIREMENTS COMPLETED
//FOR THE TEAM: we have 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 (ALL) completed//

UI Components
1. Introduction menu scene: title of game, team name, start button, credits
2. Background of menu must be visually appealing and animated
3. Menu items should be well positioned/styled (readable text, no weird overlapping), elements should be customized for your game (do not use default UI selections for font. Create custom button image for clickable elements of interface & document your reasoning for design)
	We chose a retro gaming font, that had lots of angles, because it looks like our worlds and main character.
4. Menu system should be navigable with controller/keyboard in addition to normal mouse clicking: highlighting, able to go up/down left/right, loop through list
	Use up/down on gamepad or w/s to move up and down. You can also use your mouse!
5. Credits of game: document all devs on team & their majors, document 3rd party content you used
6. Credits must be visually compelling
	(you have to click twice to exit the credits)

Particles - You can find them on our various levels!
7. At least 2 different particle effects, each needs to be 2 different particle systems. Choose appropriate shape for spawning them
	Snow Forest: Snow!
	Mystery Land: Star Meteors that break on the ground
	Cave Climbing: Lava effect: There’s smoke cone and fire! Level Goal: There’s two! 
8. In one particle effect, leverage changing SIZE of particles with one of the modules, particles must change size during the life of the particle, not just a curve of start size.
	Mystery Land: Secondary "splashes" on the floor produce particles that shrink over their lifespan
	Cave Climbing: Size, rotation, and color (opacity) change over time.
9. In one particle effect, leverage changing SPEED of particles
	Snow Forest: Snow changes size as it goes through its lifetime. its gets smaller as its velocity increases as lifetime goes on.
10. In one particle effect, leverage a 2D custom material
	Snow Forest: Snowflake particle.
	Mystery Land: "Meteor shower" uses custom star texture
	Cave Climbing: Lava emits a custom smoke texture
11. In one particle effect, leverage sub-emitters.
	Mystery Land: "Meteor shower" "splashes" on the floor, producing a burst from a secondary (sub) emitter  
12. Trigger one particle effect based on events in game.
	Snow Forest: Snow always falls
	Mystery Land: Player collides with "star" goal platforms and they emit a burst of particles.
	Cave Climbing: Smoke and lava are continuous.

iii. RESOURCES
    We made all materials we are using in the game, including all the character models, items, UI components, and audio. We used Adobe Photoshop, Paint Tool SAI, Blender, and Sekaiju.

iv. INSTALL INSTRUCTIONS
    There are no special install instructions for our game.

v. GRADING STEPS
	1. Start the game.
	2. Click “Level Select”
	3. Go “MYSTERY LAND” level
	3a. admire the stars falling from the sky. run to white platforms to right and step on them to reveal more fabulous stars. 
	4. Click escape, go to the main menu and select “SNOW FOREST” level
	4a. admire the snow! :)
	5. Click escape, go to main menu, and select the “CAVE CLIMBING” level
	5a. Run towards the SMOKE PARTICLES and admire the smoke. 
	5b. Look up and notice the green particles emerging from the golden collectible.
	6. Click escape!
	7. Go watch our credits from the main menu. 

vi. STARTING SCENE
    Start in Scenes>Alpha>StartMenu.unity

vii. URL
   http://www.prism.gatech.edu/~ccaldwell9/geocentric_m4.html