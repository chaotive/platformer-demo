# Savage Robot Run
A Unity 5 runner demo, that has to do with a Robot and Savages running and doing other stuff. It works as a technical demo to show application of several programming techniques.

## Main programming design goals:

- Maximize re-usability of game components.
- Maximize code scalability.
- Produce easy to understand and self-documenting high level code components.
- Facilitate data relationships handling.
- Facilitate configuration data usage.
- Not depending on external, already generic programming frameworks. Code design should favor natural growth.

## Implementation summary:

Without going into further detail on specifics code implementation. code follows the following folders organization:
Note: **Folders** use bold, *source code files* uses italic and commentaries doesn't have an special format.

- **Game**: System that provides components for running a basic game. This system and it's components are always assumed to be present by all other components.
  - *GameController class*: Abstract class that provides basic game state control with pre-defined generic game states and UI placeholders.
  - *GameConfig class*: Abstract class that provides a set of global configuration definitions, that extend to be used even on Unity Editor.
- **Helpers**: Independant and isolated, self-contained, non-mature components. Each file within contains an specific component. Depending on it's natural growth, can become systems.
- **SRR**: Specific, current game code, for **S**avage **R**obot **R**un.
  - **Adapted**: External scripts quickly adapted to work specifically for this game.
  - **Editor**: Game specific Unity editor configuration code.
  - *Game class*: Implementation of abstract class GameController. This class should always be needed. It works as the main game controller, handling specific global state.
  - *Config class*: Implementation of abstract class GameConfig. If you want a global configuration, you should implement this class, although it is currently always required.
  - ***Others***: Files and folders with game components that extend specific game logic.
- **Systems**: Main re-usable components hierarchy. It contains children systems folders, with particular components within. Each system should only strongly depend on Game system definitions or own system components, on a decoupled fashion.
  - **Movement**: Movement system components, currently supports walking and jumping. 
  - **Spawn**: Spawn objects system, currently supports dynamic and predictive like spawning components.

## Specific architecture and design patterns application:

- ECS: Entity-component-system architectural pattern. This is the main pattern used to design the game, although the system element of the pattern (as a full object) has not matured much on this particular game design. Right now, systems are working more as a organizational unit rather than a manager instance in the game. In any case, EC(S) approach allows for re-usability and decouppling of game objects and it's kind of the patterns that Unity naturally flows. A good read about this and other patterns applied to games can be found on [Techniques and Strategies for Data-driven design in Game Development](http://web.eecs.umich.edu/~soar/Classes/494/talks/Schumaker.pdf) by Scott Shumaker.
- Data Driven: 
- Singleton:
- Framework: Although not specifically 
- OOP
- StateMachine

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
