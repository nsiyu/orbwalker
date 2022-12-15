# LoL Pixel Based Orbwalker

This project is a simple orbwalker that uses pixel-based movement, allowing it to navigate your champion and auto attack enemies with precise calculations that maximizes your DPS.

# Installation
To use this orbwalker, you will need to have .NET Framework installed on your computer. Once .NET Framework is installed, you can download the orbwalker by cloning this repository:

```
git clone https://github.com/username/pixel-based-orbwalker.git
```
once you clone the repository, you will need to update all the offsets for the current patch of LoL <br/>
you will also need to update the base attack speed of the current champion you are using in Orbwalker.cs

# Usage
To use the orbwalker, simply run Main.cs:

The orbwalker will start moving towards your mouse, and attacking anything in its way while you are holding spacebar. <br/>
If there are multiple targets (ie. champion and minion) it will prioritize the enemy champion

# Configuration
You can customize the orbwalker's behavior by modifying the following variables in the config.cs file: <br/>
CHAMPION: A variable representing the current champion base attack speed and wind up. <br/>
PIXEL_SEARCH_RADIUS: The number of pixels around the orbwalker to search for obstacles. <br/>
MOVEMENT_SPEED: The number of pixels the orbwalker will move per step.

# Contributing
If you would like to contribute to this project, please fork this repository and submit a pull request with your changes. Thank you for your support!
