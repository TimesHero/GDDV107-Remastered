# GDDV107 – Side Scroller REMAKE

Hey everybody, let's build a video game.

At this point in time, I am a second year Game Development student, trying his best to retain the core concepts I know I was taught, but feel like I struggled to learn. GDDV107 was the Game Development course in my first semester back in 2024. We had to build a calculator, a side-scroller/infinite runner, and a group project visual novel along side many other disiplines surrounding game development, and I find myself struggling to retain the core of what I am trying to learn, which is MAKING GAMES.  
  
This is a 3-week, 15-day crash-course through the absolute fundamentals of Unity and C\#. The core concepts from presented in GDDV107 at Centennial College in Toronto, and supporting them with “*[Learning C\# by Developing Games with Unity - 7th Edition](https://www.amazon.ca/Learning-Developing-Games-Unity-coding/dp/1837636877/133-3596361-5955102?pd_rd_w=Cjq9M&content-id=amzn1.sym.d3f44101-6e04-446e-916c-a6ec5616982b&pf_rd_p=d3f44101-6e04-446e-916c-a6ec5616982b&pf_rd_r=5M1K7NC1K4QWPMPQSP5G&pd_rd_wg=CFW5a&pd_rd_r=d19c6063-fdbf-4737-b891-53cc51f22880&pd_rd_i=1837636877&psc=1)”* and “*[Unity in Action – Third Edition](https://www.amazon.ca/Unity-Action-Third-Joseph-Hocking/dp/1617299332/133-3596361-5955102?pd_rd_w=lUvto&content-id=amzn1.sym.4296b8ba-ef9b-4a5b-8472-6a970437f86d&pf_rd_p=4296b8ba-ef9b-4a5b-8472-6a970437f86d&pf_rd_r=5Q7F7J4YK0X0QE1BTRGA&pd_rd_wg=5vgCu&pd_rd_r=7c21770c-70a9-4259-ba01-f3c17646d113&pd_rd_i=1617299332&psc=1)”*, and eventually coming out the other side with a remake/remaster of my original 2D side-scroller. (I’ll find that and link it here eventually, I swear!)


## The Mission Parameters

The purpose here is not to rush. The purpose is to rebuild the concepts in the exact order my college course introduced them, and then apply them into the one project. The requirements of the project closely align with arguably the most important assignment from class.

- **Week 1: The Foundation.** I will set up a clean Unity project and making sure our variables, arrays, and loops actually compile. 

- **Week 2: The Systems.** I will be putting a player on the screen and adding movement, hazards, score pickups, and a lose condition. By the end of this week, there will be a playable prototype. 

- **Week 3: Polish and Persistence.** I will take that prototype and make it real. That means adding audio, particle systems, high scores, and a clean flow between multiple scenes without the whole thing exploding. 

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
- Comins Soon!
