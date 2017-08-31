# Savage Robot Run
A Unity 5 runner demo, that has to do with a Robot and Savages running and doing other stuff. It works as a technical demo to show application of several architecture and programming techniques.

## Main design goals:

- Maximize re-usability of game components.
- Maximize code scalability.
- Produce easy to understand and self-documenting high level code components.
- Facilitate data relationships handling.
- Facilitate configuration data usage.

## Implementation summary:

Without going into further detail on specifics code implementation. code follows the following folders organization:
Note: **Folders** use bold, *source code files* uses italic and commentaries doesn't have an special format.

- **Helpers**: Independant and isolated, self-contained, non-mature components. Each file within contains an specific component. Depending on it's natural growth, can become systems.
- **SRR**: Specific, current game code, for **S**avage **R**obot **R**un.
  - **Adapted**: External scripts quickly adapted to work specifically for this game.
  - **Editor**: Game specific Unity editor configuration code.
  - *Game class*: Implementation of abstract class GameController. This class should always be needed. It works as the main game controller, handling specific main state.
  - *Config class*: Implementation of abstract class GameConfig. If you want a global configuration, you should implement this class.
  - ***Others***: Files and folders with game components that extend specific game logic.
- **Systems**: Main re-usable components hierarchy. It contains children systems folders, with particular components within.
  - **Game**: System that provides components for running a basic game.
    - *GameController class*: Provides basic game state control with pre-defined generic game states and UI placeholders.
  - **Movement**    
  - **Spawn**

## Specific architecture and design patterns application:

## Further improvement opportunities:

- Implement spawn generator through usage of object pooling design pattern (althought usage of this design pattern has more to do with eficiency, which is not a design goal).
- Better implementation of input handling methods, either trough better generalization of InputController or usage of Unity InputManager.

## Known issues:

- Game is unbalanced (it's very hard and unforgiving)
- Game lacks any sound (no sound implementation yet, except for music)

## Additional credits:

- Main character: Robot Boy, Unity Standard Assets 2D, https://www.assetstore.unity3d.com/en/#!/content/32351
- Firing enemy character: Goblin Archer Cartoon Character, Razvan 3.14, https://www.assetstore.unity3d.com/en/#!/content/17253
- Moving enemy character: Free Maya Indian Hero, Fabio Cujino, https://www.assetstore.unity3d.com/en/#!/content/46725
- Scenary sprites: 2D Jungle Side-Scrolling Platformer Pack, Super Brutal Assets, https://www.assetstore.unity3d.com/en/#!/content/78506
- Music: Tiki Drum Loop (Free), Luna Strata, https://www.assetstore.unity3d.com/en/#!/content/93904
- Main camera script (base, then modified): Smooth Follow, Unity Standard Assets Utility, https://www.assetstore.unity3d.com/en/#!/content/32351
- Collectable item sprite: maxbmuniz, https://pixabay.com/p-2481700
