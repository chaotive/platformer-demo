# Savage Robot Run
A Unity 5 runner demo, that has to do with a Robot and Savages running and doing other stuff. It works as a technical demo to show application of several programming techniques.

## Main programming design goals:

- Maximize re-usability of game components.
- Maximize code scalability.
- Produce easy to understand and self-documenting high level code components.
- Facilitate data relationships handling, as a decouppled from code components element.
- Facilitate global configuration data usage.
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

- ECS: Entity-component-system architectural pattern. This is one of the most common game design patterns and one the main design pattern used used to design the game, although the system element of the pattern (as a full object) has not matured much on this particular game design. Right now, systems are working more as a organizational unit rather than a manager instance in the game. In any case, EC(S) approach allows for re-usability and decouppling of game objects and it's kind of the patterns that Unity naturally flows. A good read about this and other patterns applied to games can be found on [Techniques and Strategies for Data-driven design in Game Development](http://web.eecs.umich.edu/~soar/Classes/494/talks/Schumaker.pdf) by Scott Shumaker.
- Data-Driven Design: This is another of the most common game design patterns and one the other main design pattern used used to design the game. In this case, this mainly affect the global configuration component of the game and it's abbility to allow for  decouppled components to still interact with a global configuration, without depending on the specific data structure of the game. Unity already data-driven friendly design also helps a lot for using this design pattern. Same as with ECS, a good read about this and other patterns applied to games can be found on [Techniques and Strategies for Data-driven design in Game Development](http://web.eecs.umich.edu/~soar/Classes/494/talks/Schumaker.pdf) by Scott Shumaker.
- Singleton: This is one of the most common generally used design patterns. In the game it is used to access global game state and configuration. Unity facilites it's pseudo implementation, because of clear game process flow stages to instantiate, although on more complex designs also a helper lazy initialization to allow further decouppling can be recommended.
- Template: The way GameController and GameConfig clases provides for certain basic functionality and request for certain specifics methods to be implemented on an specific game basis.
- State: Global configuration options summarize it's posibilites by a set of differentes states than can be selected by the developer to apply from configuration. Main game states are based on a series of possible states that the game can pass at a given time.
- Framework: Although not a design pattern by itself, the general organization and implementation recommendations to use the code on a general scope tend to consider about the whole design approach for the game as a Framework.

## Further improvement opportunities:

- Use systems with a Manager, that follows a more controlled Factory pattern.
- Implement spawn generator through usage of Object pooling pattern (althought usage of this design pattern has more to do with eficiency, which is not a design goal).
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
