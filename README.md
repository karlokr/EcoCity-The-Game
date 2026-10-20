# EcoCity: The Game

An environmentally minded city-building game made with Unity.

Build homes to house citizens, collect taxes to upgrade your buildings and industry, and grow your population without letting carbon emissions get out of hand. The goal is the greenest city you can build.

## Gameplay

- **Build** residential, commercial, and industrial buildings on plots. Each one costs money and wood.
- **Grow** your population and income. Every in-game month pays out money and wood, and your buildings produce their resources.
- **Upgrade** buildings with upgrade materials to make them better and cleaner.
- **Expand** by buying new land. Forest tiles give you wood and upgrade materials, and rock tiles can be cleared too.
- **Watch your emissions.** The emissions bar fills as your city pollutes, and the world visibly warms up as it does.

### Win and lose conditions

| Outcome | Condition |
| --- | --- |
| Win | Reach the population target while staying under the emission limit |
| Lose | Emissions reach the limit |
| Lose | Time runs out before you reach the population target |

### Game modes

- **Campaign**: easy, medium, and hard levels with set population and emission targets.
- **Endless**: easy, medium, and hard sandbox maps.

There's also a hidden easter egg on the skull island.

## Tech stack

- **Engine:** Unity 2019.1.0f2
- **Language:** C#
- **Packages:** TextMesh Pro, Post Processing, Timeline, Unity Ads, Unity Analytics, Unity IAP
- **Third-party assets:** Modern UI Pack, Low Poly Water, SimpleSky, SimpleTown, FX Kandol Pack, EZ Camera Shake
- **Target platforms:** Android and desktop (mouse and keyboard)

## Getting started

### Requirements

- [Unity Hub](https://unity.com/download)
- Unity **2019.1.0f2**. Install it from the [Unity download archive](https://unity.com/releases/editor/archive). Newer versions may work after an upgrade, but they haven't been tested.
- Android Build Support, if you want to build for Android

### Running the project

1. Clone the repo:
   ```bash
   git clone https://github.com/karlokr/EcoCity-The-Game.git
   ```
2. Open Unity Hub, choose **Add**, and select the cloned folder.
3. Open the project with Unity 2019.1.0f2.
4. Open `Assets/Scenes/Karlo Scenes/Menus/LandingPage.unity` and press **Play**.

To jump straight into a level, open one of the scenes under `Assets/Scenes/Karlo Scenes/GameTypes/`.

### Building

Go to **File → Build Settings**, check that the scenes are listed in order with `LandingPage` first, choose your platform, and click **Build**.

> **Note:** Accounts, guest login, save games, and the leaderboard all used a PHP/MySQL backend on `ecocitythegame.ca`, which is now offline. Those features won't work unless you point the URLs in `Assets/Scripts/Karlo Scripts/` at your own backend. You can still play by opening a level scene directly in the editor.

## Project structure

```
Assets/
├── Art/            # 2D/3D art, materials, animations, post-processing profiles
├── Audio/          # Music and sound effects
├── Fonts/
├── Prefabs/        # Buildings, tiles, UI, and other reusable objects
├── Resources/
├── Scenes/         # Menus, campaign and endless levels, test scenes
└── Scripts/        # Game code, grouped by team member
Packages/           # Unity package manifest
ProjectSettings/    # Unity project settings
```

## Team

EcoCity was built in spring 2019 by Team 31 for COMP 2930, under the studio name Pillar Men Inc.

- [Karlo Krakan](https://github.com/karlokr): menus, authentication, save system
- Richard Le: core game logic, buildings, camera and controls, UI
- Kristian Postnikoff: building types, tiles, win conditions
- Erik Golke: tile management, land purchasing, the nuke
- Alex Park: cars, day/night cycle, sound

## Related

- [EcoCity Website](https://github.com/karlokr/EcoCity-Website): source for the game's former website
