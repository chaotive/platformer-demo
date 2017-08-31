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

- **Helpers** *Independant and isolated, self-contained components. Depending on it's natural growth, can become systems.*
  - Bleh
- **SRR** *Specific, current game code.*
  - **Editor** *Game specific Unity editor configuration code*
  - Game Class
  - Config Class
  - Other files
- **Systems** *Main re-usable components hierarchy. It contains children systems folder, with particular components.*

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
