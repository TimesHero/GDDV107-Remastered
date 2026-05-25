# GDDV107 – Side Scroller REMAKE

Hey everybody, let's build a video game.

At this point in time, I am a second year Game Development student, trying his best to retain the core concepts I know I was taught, but feel like I struggled to learn. GDDV107 was the Game Development course in my first semester back in 2024. We had to build a calculator, a side-scroller/infinite runner, and a group project visual novel along side many other disiplines surrounding game development, and I find myself struggling to retain the core of what I am trying to learn, which is MAKING GAMES.  
  
This is a 3-week, 15-day crash-course through the absolute fundamentals of Unity and C\#. The core concepts from presented in GDDV107 at Centennial College in Toronto, and supporting them with “*[Learning C\# by Developing Games with Unity - 7th Edition](https://www.amazon.ca/Learning-Developing-Games-Unity-coding/dp/1837636877/133-3596361-5955102?pd_rd_w=Cjq9M&content-id=amzn1.sym.d3f44101-6e04-446e-916c-a6ec5616982b&pf_rd_p=d3f44101-6e04-446e-916c-a6ec5616982b&pf_rd_r=5M1K7NC1K4QWPMPQSP5G&pd_rd_wg=CFW5a&pd_rd_r=d19c6063-fdbf-4737-b891-53cc51f22880&pd_rd_i=1837636877&psc=1)”* and “*[Unity in Action – Third Edition](https://www.amazon.ca/Unity-Action-Third-Joseph-Hocking/dp/1617299332/133-3596361-5955102?pd_rd_w=lUvto&content-id=amzn1.sym.4296b8ba-ef9b-4a5b-8472-6a970437f86d&pf_rd_p=4296b8ba-ef9b-4a5b-8472-6a970437f86d&pf_rd_r=5Q7F7J4YK0X0QE1BTRGA&pd_rd_wg=5vgCu&pd_rd_r=7c21770c-70a9-4259-ba01-f3c17646d113&pd_rd_i=1617299332&psc=1)”*, and eventually coming out the other side with a remake/remaster of my original 2D side-scroller. (I’ll find that and link it here eventually, I swear!)


## The Mission Parameters

The purpose here is not to rush. The purpose is to rebuild the concepts in the exact order my college course introduced them, and then apply them into the one project. The requirements of the project closely align with arguably the most important assignment from class.

- **Week 1: The Foundation.** I will set up a clean Unity project and making sure our variables, arrays, and loops actually compile. 

- **Week 2: The Systems.** I will be putting a player on the screen and adding movement, hazards, score pickups, and a lose condition. By the end of this week, there will be a playable prototype. 

- **Week 3: Polish and Persistence.** I will take that prototype and make it real. That means adding audio, particle systems, high scores, and a clean flow between multiple scenes without the whole thing exploding. 

## Asset Attributions

### Art

### Audio
- Huge distant sub explosion by NomisBright -- https://freesound.org/s/854416/ -- License: Creative Commons 0
- Sci‑Fi Game Sound Effects by Magic Sound Effects (Unity Asset Store)

## Patch Notes
### Day One - Log Entry: May 4th, 2026

As I am 4 semesters into my Game Development program, familiarizing myself with the unity environment is something I've already accomplished. Its nice to have some refreshers regarding best practices I suppose.

- **Accomplishments**
    - Created core project
    - Created project repository on github
    - Troubleshot some Linux functionality issues
        - CachyOS - was stalling every time I alt+tab in or out of Unity. Forced to run in Vulkan instead of Wayland. Not entirely gone, but more managable. Will further troubleshoot later.
    - Created general scenes for the project
        - Main Menu
        - Game scene
        - Sand box (for other practice)
    - Created general folders in project
        - Art
        - Audio
        - UI
        - Scripts
        - Materials
        - Prefabs
    - Read and reviewed
        - "GDDV107's Course Content" - Module 1
        - "Unity In Action" - Chapter 1
        - "Learning C\#" - Chapter 1

I intend to get a head start on Day 2's readings and perhaps even complete its to-do list.


### Day Two - Log Entry - May 4th, 2026 && May 5th, 2026.

#### Part 1

I was able to begin this early as the previous day was a straight forward refresher.

- **Accomplishments**
    - Created DayTwoPractice.cs to gain some basic structure practice
    - Implemented some basic math stuff from "Learning C\#" text book and played with dynamic and hard-coded values
    - Organized with \[Header("")]s
    - Made use of 2 Methods, and a new   class within the same script, calling them in Start\()
        - ComputeAge - Simple int calculation
        - PostageParse - draws from the methods within the PostOffice class
    - Formatted some warning logs for easy reading the different code segments in the console
    - Began Reading "Unity In Action" Chapter 2
    - It turns out was my OS stalling issue was due to KDE Plasma Wayland, so I switched to Plasma X11 to resolve the issue.
    
Tomorrow, the real Day Two, I will complete the readings of chapter 2 and 3, and the first 3 sections of the course content.

#### Part 2 - May 5th, 2026

- **Accomplishments**
    - Finished Chapter 2.
    - Followed along with Chapter 3 of "Learning C#"
        - Stored int string, bool variables
        - got fancy with an if statement arounf the bool
        - passed references
        - returned values
    - Made 3 different enum lists

### Day Three - Log Entry - May 6th, 2026

#### Part 1 - May 6th, 2026
- **Accomplishments**
    - Read and followed along with "Learning C#" Chapter 4
        - if/else statement
            - I touched on this briefly yesterday, because I understand the fundamentals, but its a nice refresher of the formal texts.
            - example uses a bool to determine if you are in posession of a key or not.
            - The next example did a "if gold > \#", "else if gold \< \#", "else the sweetspot"
                - This makes sense for when you have a condition resulting in multiple different outcomes based on the watched variable.
                - Doesn't quite explain why you wouldn't just use multiple ifs and one else.
            - The '!' is the "not operator" as in if(!playerHasKey) meaning player has key is false, or player does NOT have the key.
            - I nested an if within an if. If you have a weapon, it checks what that weapon is. If its not equipped, it will encourage you to equip something
        - Switch/Case things
            - used it for generic character actions
            - simulated a "fall through" where the dice value was undefined, so it skipped it and went to the next available case
        - Arrays
            - can't be modified without wiping contents
            - contains elements stored to an index reference. Index starts at 0.
            - EXAMPLE: elementType[] name = new elementType[numberOfElements]; || int[] TopPlayerScores = new int[3];
                - This will hold the top 3 scores, with indexes of 0, 1, 2.
            - Multi-dimensional arrays work like rows and columns (but you can have up to 32 rows/colums for some reason? like rows and columns are 2 dimensions, so 32 dimensions? wild.)
                - int[,] Coordinates = new int[3,2]; <-- 3 rows and 2 columns
                    - { 
                        {5,4},
                        {1,7}, 
                        {9,3} 
                      };
        - Lists
            - Easier to Add, remove, or update
            - List<elementType> name = new List<elementType>() { value1, value2 };
            - Added a list of characters and played with adding and removing them.

- **Blockers**
    - This section of the text book was more complicated than anticipated. Most is refresher, and nice to practice. I'm up to dictionaries now. We'll see how this goes. Haven't even gotten to loops yet, but I already know how nicely that will tie into Lists. Glad I baked some flexibility into this plan.

#### Part 2 - May 7th, 2026
- **Accomplishments**
    - Dictionaries
        - Its weird that what now functions as the index is now the key, which is a string.
    - For Loops
        - had to make the for loop go backwards and count through a second list of characters in waiting. Probably would have been easier had I just used a while loop, but I'm afraid of those sometimes lol.
    - foreach Loop
        - This would be good if the characters had a status message. Combined with some ifs, or switch cases, (and probably a scriptable object later on) i can probably make them shout out their current health value or have a little quip if its at a certain percentage of the maximum amount.
    - Looping through key values
        - Text book example is going back up to the dictionary from earlier. It looks like it would be good for populating an inventory with the item name and quantity held or perhaps price or other value.
    - While Loops
        - if the character is still alive for example, you can have it report back its status while health > 0 and such. but it can be easy to make it accidentally loop forever. can also happen in for loops but I've accidentally made it happen in the past.

### Day 4 - Log Entry - May 8, 2026
- **Accomplishments**
    - Reviewed the difference between Start() and Update()
        - Start() is where the script does its setup stuff once, like initializing values, printing opening debug logs, or grabbing references.
        - Update() is for things that need to be checked constantly, which is not everything apparently.
    - Reviewed some object-oriented programming basics
        - Classes are essentially the containers/blueprints.
        - Variables hold the data.
        - Methods do the work.
        - Unity scripts are classes that become components when attached to GameObjects.
    - Looked at how Unity references can be assigned through the Inspector
        - This feels cleaner than trying to magically find everything through code every time.
    - Continued using debug logs to confirm each section works before moving on
        - This still feels boring, but it is probably better than guessing why something broke later.

- **Notes**
    - A lot of this was refresher for things I've been doing since semester one. Mostly reading the texts.
    - I can better see how this connects to the actual side-scroller project. The player, hazards, score manager, UI manager, and pickups should probably not all be one script.
    - Start() and Update() are familiar, especially as they show up with every new Monobehaviour.

- **Blockers**
    - I still need more practice deciding when something should be its own script vs. when I am just overcomplicating it.
    - Script communication makes sense on a high level, but if I'm not paying attention, things could go off the rails.
    - I am still slightly behind schedule, but this cleanup day was probably necessary before moving into UI."

### Day 5 - Log Entry - May 9, 2026

- **Accomplishments**
    - Variables and methods feel fine.
    - Enums make sense, but I probably need to use them in a real gameplay context before they fully stick. Seems like a good way to track Paused/Play state, but I'm not entirely sure how to manage that in practice. I also imagine it working in the context of Pokemon for swapping between status effects like confused, burnt, poisoned, sleep, paralyzed, etc.
    - Arrays and loops: I still need repetition, especially when the logic gets more complicated than just counting through a list.

- **Blockers**
    - I still have a hard time deciding where or how to start. I think Day 6 might need some adjustment from the full plan. Maybe coming up with a simple GDD for what I want to make would be a good step?
    - Arrays, loops, and conditions make sense individually, but combining them still takes more thinking than I would like.

### Day 6 - Log Entry - May 10–11, 2026

I decided that before going any deeper into the actual side-scroller, I should set up the basic project flow properly. A game scene by itself is fine for testing, but the actual assignment structure eventually needs a main menu, scene transitions, and a cleaner project layout.

- **Accomplishments**
    - Created a new `MainMenuScene`
    - Added basic interactive UI elements for:
        - Starting the game
        - Viewing high scores
        - Accessing how-to-play instructions
        - Quitting the application
    - Created a `MainMenuManager` script to handle navigation between the main menu and the game scene
    - Renamed `Game Scene.unity` to `GameScene.unity` for cleaner scene naming
    - Added an `EventSystem` to both the `MainMenuScene` and `GameScene`
        - This should keep UI input handling more consistent with the Unity Input System
    - Restructured some related project/meta files to better match the updated scene organization

- **Notes**
    - This was not the most exciting day, but it was useful foundation work.
    - Scene naming and menu navigation are the kind of things that seem boring until they break later.
    - Since this remake is supposed to become a real playable loop, I want the project to have a menu/game structure early rather than stapling it on at the end.

- **Blockers**
    - I still had not moved into the actual gameplay loop yet.
    - This is where the plan started drifting from “review concepts first” into “I probably should have been building the game while reviewing the concepts.”

### Day 7 to 12 - Log Entry - May 12–24, 2026

This is the part of the project where the schedule got ugly.

The week of May 12 included my wife's birthday, family obligations, helping a friend with a 3D printer setup, household chores, and other projects. That does not fully excuse the lost momentum, but it does explain where some of the time went. I also lost more focus than I should have, which is exactly the kind of problem this summer plan is supposed to expose and work around.

This is also why I built the plan with a 3-week window. The 4th week was always meant to be a bonus, and now it's officially being used.

- **Accomplishments**
    - Settled on a new theme direction for the remake
        - The game will move away from the old paper airplane theme
        - The new direction is a space side-scroller
        - The player will likely become a small spaceship
        - The background can use stars, planets, moons, and other space objects
    - Decided to keep using placeholder objects until the gameplay works
        - Art polish can come later
        - Gameplay has to become functional first
    - Reinitialized and configured Unity's Input System settings
    - Reinitialized the `GameScene` with core objects, including:
        - Player
        - Main Camera
        - EventSystem
    - Introduced the `PlayerMovement` script to handle player input and 2D movement
    - Updated Input Actions to support movement from:
        - Keyboard
        - Mouse
        - Touch
    - Added `UserSettings/` to `.gitignore`
        - This keeps user-specific editor configuration files out of version control
    - Used NotebookLM quizzes and generated study material to reinforce concepts from the course content and textbooks

- **Notes**
    - I originally tried building the movement using Unity's older input approach, then remembered that Unity 6 expects the newer Input System workflow.
    - The Input System took more time than expected because it is not just “read WASD and move.” It also involves actions, bindings, the Player Input component, and making sure the correct event is calling the correct function.
    - Asking for help became the last resort after spending too much time circling the same problem.
    - For the next project, especially the GDDV206 review, I think the plan needs to change.
        - Start with the game idea first.
        - Write a small GDD first.
        - Write pseudocode based on the concepts I am trying to learn.
        - Learn the programming concepts in the context of the game, rather than reviewing them in the abstract and trying to attach them afterward.

- **Blockers**
    - Focus and schedule management were worse than expected during this stretch.
    - I spent too long in review/planning mode and not enough time building the actual side-scroller.
    - The Input System became a blocker because movement was partially working, then stopped behaving the way I needed it to.
    - I am now behind the original ideal pace, but this is the exact reason the plan had an extra week built into it.
    
### Day 13 - Log Entry - May 25, 2026

Today became the “make the player work properly” day.

The current priority is no longer abstract review. The priority is to get the actual side-scroller functioning with placeholders. Make it work first. Make it pretty later.

- **Accomplishments**
    - Revisited the `PlayerMovement` script
    - Confirmed that the player object is using:
        - A parent `Player` object
        - A child `PlayerSprite` object
        - A `Rigidbody2D`
        - A `Player Input` component using the new Input System
    - Cleaned up the movement logic so the Rigidbody2D handles movement
        - This avoids mixing physics movement with direct `transform.position` movement
    - Reworked the rotation/tilt logic
        - The child sprite can now keep its Inspector rotation as the base sideways pose
        - The script adds vertical tilt on top of that base pose
        - This is important because this is a side-scroller, so the player should visually face sideways by default
    - Added casual explanatory comments to the movement script
        - Comments now explain why certain choices are being made instead of just repeating what the code says
    - Clarified the current production rule:
        - Functional gameplay first
        - Placeholder art is acceptable
        - Polish comes after the loop works

- **Notes**
    - The player movement script is the first real gameplay contribution to the side-scroller remake.
    - The new space theme gives the project a clearer direction, but the theme should not slow down the systems work.
    - A spaceship, stars, and a slow-moving planet in the lower part of the frame would fit the remake well, but those are polish targets. The project still needs hazards, pickups, scoring, lose conditions, and scene flow before the art pass matters.

- **Blockers**
    - I need to verify movement in the editor after each script adjustment.
    - The player controls have to be stable before I build hazards or pickups around them.
    - I have used up the schedule buffer, so the rest of the week needs to be implementation-focused.

## Current Project Status - May 25, 2026

At this point, the project is behind the ideal version of the schedule, but it is not dead. The menu structure has been started, the game scene exists, the Input System has been set up, and the player movement script is being corrected.

The next step is to stop widening the scope and finish the playable loop with placeholders.

#### Current State

- **Working / Started**
    - Main menu scene
    - Game scene
    - Scene naming cleanup
    - EventSystem setup
    - Unity Input System setup
    - Player object
    - Player movement script
    - Player sideways-facing/tilt logic
    - Placeholder-first production approach
    - Space theme direction

- **Needs Verification**
    - WASD movement in the editor
    - Player tilt while moving up/down
    - Player returning to sideways-facing pose when no vertical input is pressed
    - Main menu button flow into the game scene

- **Not Started / Still Needs Implementation**
    - Hazard collision
    - Hazard spawning
    - Score pickups
    - Power-up pickup
    - Score manager
    - HUD score display
    - Game over state
    - Restart flow
    - High score saving
    - Parallax background
    - Audio feedback
    - Particle feedback
    - Final art pass

## Bonus Week Recovery Plan

The goal for the rest of this week is to finish a playable version of the side-scroller remake. The game does not need final art yet. It needs to function.

### Priority 1 - Make the Player Reliable

- [✓] Confirm WASD movement works in Play Mode
- [✓] Confirm the player remains sideways by default
- [✓] Confirm the player tilts up when moving up
- [✓] Confirm the player tilts down when moving down
- [✓] Confirm the Rigidbody2D parent stays clean while the child sprite handles visual rotation
- [ ] Add player death detection using `OnTriggerEnter2D` or `OnCollisionEnter2D`
- [ ] Add pickup detection using `GetComponent<>()` and null checks

### Priority 2 - Build the Core Gameplay Loop

- [ ] Create at least one basic hazard prefab
- [ ] Make hazards move across the screen
- [ ] Destroy hazards when they leave the screen
- [ ] Create a basic hazard spawner
- [ ] Add game over when the player hits a hazard
- [ ] Create a basic score pickup
- [ ] Increase score when the player collects the pickup
- [ ] Destroy pickups after collection

### Priority 3 - Close the UI Loop

- [ ] Add a TextMeshPro HUD score display
- [ ] Add a Game Over panel
- [ ] Show final score on Game Over
- [ ] Add a Restart button
- [ ] Add a Quit/Menu button
- [ ] Confirm Main Menu loads GameScene
- [ ] Confirm Restart reloads GameScene

### Priority 4 - Add Required Assignment Features

- [ ] Create three distinct hazard types
- [ ] Add randomized spawning
- [ ] Create a power-up pickup
- [ ] Make the power-up temporarily affect player state
- [ ] Save high score using `PlayerPrefs.SetInt()`
- [ ] Load high score using `PlayerPrefs.GetInt()`
- [ ] Display high score on the menu

### Priority 5 - Make It Look and Feel Like a Game

- [ ] Replace placeholder player with spaceship art
- [ ] Add star background
- [ ] Add at least two parallax layers
- [ ] Add a large planet or moon that slowly moves through the lower portion of the frame
- [ ] Add hazard art
- [ ] Add pickup art
- [ ] Add menu art
- [ ] Add background music or ambient space audio
- [ ] Add pickup sound
- [ ] Add collision sound
- [ ] Add death particles
- [ ] Add pickup particles

### Practical Rule

Do not polish a system that does not work yet.

The order is:

1. Movement
2. Hazards
3. Pickups
4. Score
5. Game Over
6. Restart
7. High Score
8. Parallax
9. Audio
10. Particles
11. Final Art
