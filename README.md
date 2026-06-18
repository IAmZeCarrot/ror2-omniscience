# RoR2 Omniscience Mod

A Risk of Rain 2 BepInEx mod that implements an offline "omniscience mode" overlay with target detection, aim-assist, and debug information display.

## Features

- **Entity Overlay** - Display all enemies, allies, and items on screen
- **Target Selection** - Automatically identify closest visible enemy
- **Aim-Assist** - Smooth aiming toward selected targets
- **Debug Info** - Real-time stats (FPS, entity count, etc.)
- **Toggle Menu** - In-game keyboard controls to enable/disable features

## Requirements

- Risk of Rain 2 (Steam)
- BepInEx 5.x
- Visual Studio 2019+ with C# support

## Installation

1. Download BepInEx from https://github.com/BepInEx/BepInEx/releases
2. Extract to your RoR2 game directory
3. Place the compiled DLL in `BepInEx/plugins/`
4. Launch the game

## Building

1. Open `RoR2Omniscience.sln` in Visual Studio
2. Build the solution (Release mode)
3. DLL will be generated in `bin/Release/`

## Development Journal

See [DEVJOURNAL.md](DEVJOURNAL.md) for weekly progress and learning notes.

## Technical Overview

### Architecture

- **OmniscienceManager** - Main mod controller
- **EntityDetector** - Finds and tracks game entities
- **OverlayRenderer** - Draws debug info on screen
- **TargetSelector** - Determines closest enemy
- **AimAssist** - Smooth aiming calculations
- **MenuSystem** - Toggle controls

### How It Works

1. Game loop hook detects all `CharacterBody` objects
2. Filters for enemies/allies based on team
3. Calculates screen position via raycasting
4. Renders overlay with entity info
5. Applies aim-assist smoothing to player aim

## Anti-Cheat Notes

This mod is **offline single-player only**. It does not:
- Connect to servers
- Affect multiplayer matches
- Modify game balance
- Bypass anti-cheat systems (intentionally)

See [ANTICHEAT.md](ANTICHEAT.md) for detection vulnerability analysis.

## License

MIT
