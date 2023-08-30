# Robo Memories (Friend Birthday Present Series)

## Introduction

<img align="left" src="https://github.com/anke-hao/Friend_Robo_BDayPresent/blob/main/Screenshots/In-game%20Screenshot%202.png" style="height: 300px;">

Welcome to [Robo Memories](https://ankehao.itch.io/robo-memories), the gamified interactive experience I made for my friend's birthday! In this experience, you play as a character in a 2D platformer who navigates the environment and finds "Robo Memories," yellow robots that contain capsules of memories my friend and I shared throughout our college experience. 

The Friend Birthday Present Series is a series of short games I built, each over the course of 3-4 days, as birthday gifts for friends who were living in separate locations from me at the time of their birthday.

## How To Play
### Basic Commands
- Navigate with WASD and press SPACE to jump. 
- Once at a Robo Memory, the dialogue from the robot will play automatically. Click to skip ahead in the dialogue or move to the next dialogue line.
### What to Expect
The content of the game has been edited for privacy reasons, but the structure has remained the same! It is comprised of a single level where you navigate a 2D platform and click through dialogue from the yellow robots on screen. Once you have gone through all of the Robo Memories, you'll meet in-game Anke, who will bring you on board her hovercraft and take you to the skies!

## Motivation
My friend's birthday was over the summer and we would be living in different locations at that time. I wanted to send a birthday gift that would both reach them on the day of their actual birthday (aka no giving them something way before or after the date!) and have quality that would be on par with a gift in person. 

### Level Design
<img align="right" src="https://github.com/anke-hao/Friend_Robo_BDayPresent/blob/main/Screenshots/In-game%20Screenshot%201.png" style="height: 250px;">

- As it was the summer before our last year of college, I wanted to preserve some of our most impactful memories and segments of time that we spent together before we had to go our separate ways. As such, the purpose of the gift was less focused on game mechanics like fighting or platforming, and more focused on using the environment and the memories kept by the robot for evoking a sense of nostalgia and connection.
- Some aspects of the level were designed to reflect certain moods, memories or preferences of my friend and I:
  - assets that catered to some of the interests of my friend (primarily Ghost in the Shell and cyborgs)
  - changes in the player's elevation, music, and environment to correspond with changes in mood and excitement:
    - a gradual increase in elevation as we met each other and formed a friend group in our first year of college
    - a sudden drop into a dark, undecorated area with no music to reflect the initial COVID outbreak and subsequent departure from campus
    - an elevator straight up once we returned to campus once more and became roommates

## Tech Stack

<img align="right" src="https://github.com/anke-hao/Friend_Robo_BDayPresent/blob/main/Screenshots/Workspace%20Screenshot.png" style="height: 375px;">

The game was built in Unity2D, with the use of C# scripts for the following:
- managing the playable sprite’s movements (PlayerController)
- handling dialogue, including detecting when the player is close to a Robo Memory and allowing for skipping ahead or moving to the next dialogue line
- managing various platforming aspects of the game, including detecting a section of the game where the music should be muted (MuteMusic) and handling floating platforms (PlatformFloater)
- handling the final ending scene, including "bringing" the player onto Anke's hovercraft and flying away (EndScene, FloatAnke and FlyAway)

## Visual and Audio Assets
- All the visual assets, including the playable character and all the environmental assets, were sourced from [ansimuz's](https://ansimuz.itch.io/) free [Warped City Pixel Art Assets Pack](https://ansimuz.itch.io/warped-city), which is licensed for personal and commercial use.
- The background music was sourced from [TallBeard Studios's](https://tallbeard.itch.io/) [Music Loop Bundle](https://tallbeard.itch.io/music-loop-bundle).
- The sound effects were sourced from [Nox_Sound's](https://assetstore.unity.com/publishers/52638)[Footsteps - Essentials](https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879#content).
  
## Future Additions/Bugfixes

<img align="right" src="https://github.com/anke-hao/Friend_Robo_BDayPresent/blob/main/Screenshots/In-game%20Screenshot%204.png" style="height: 250px;">

### Additions
- A proper start/ending screen with the option to begin or replay the experience.
### Bugfixes
- A bug with the dialogue that scrambles the letters:
  - if the player exits the trigger area before the dialogue ends and
  - reenters immediately.
 - The above seems to be the most reproducible method to encounter this bug. The current workaround is simply to click again as if to skip ahead in the dialogue, and the dialogue will immediately unscramble to become legible. It seems to be an issue with part of the template I am using to handle dialogue, as this same bug has appeared in another game I made using the same dialogue system.
