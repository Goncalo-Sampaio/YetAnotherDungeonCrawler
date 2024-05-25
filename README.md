# Yet Another Dungeon Crawler

### **Authors:**

| Name | Number |
| - | - |
| Eduardo Rocha | 22304641|
| Gonçalo Sampaio | 22306825 |
| João Nogueira | 22304016 |

**Eduardo Rocha:**
 - Model Classes
 - ReadMe
 - Mermaid flowchart

**Gonçalo Sampaio:**
 - Repository setup
 - Controller
 - Program
 - Readme

**João Nogueira:**
 - Classes View
---

**Git Repository:** [GitHub] (https://github.com/Goncalo-Sampaio/YetAnotherDungeonCrawler.git)

---
## **Solution Architecture:**

**Program.cs:**
- Instantiates a new view and a controller, starting the game;

**Controller.cs:**
- Start Method where most of the game's logic will run:
  - Starts by reading the Enemies file and creates them, adding them to a HashSet.
  - Also reads the Rooms file, creating them and adding them o a list.
  - Starts the main game loop:
    - Shows the player's and current room's states.
    - Shows a menu that changes the available options according to the room's state.
    - Manages player's choices, checking if they are possible or not.
    - If there's an enemy in the room, shows its state and allows the player to fight it.
    - Uses methods from the Model to progress with the battle.
    - Manages player's and enemy's health.
    - Removes the enemy from the room if it died.
    - If there's an item in the room, allows the player to pick it up, removing it from the room.
    - Only allows the player to move to another room if there's no enemy in the current room.
    - Manages the dungeon exit and the end of the game.
  - Ends the game if the player died or escaped the dungeon.
  - Shows a final message if the player quits the game, dies or escapes.

#### **Model Classes:**

- **Character.cs:**
  - Contains the components and logic that needs to be shared between *Player* and *Enemy*. Mainly *Name*, *Health* and *AttackPower*.
  - Has methods that:
    - Attack other Characters.
    - Handle incoming damage.

- **Player.cs:**
  - Derives from *Character*.
  - **"CurrentRoom"** - stores a reference of the *Room* the Player is currently occupying.
  - **"Inventory"** - stores *Items* and keeps track of their respective quantity.
  - Has methods that:
    - Allows player to change Rooms.
    - Pick up any item in the room.
    - Heal, but only if they have Healing Potions in their inventory.

- **Enemy.cs:**
  - Derives from *Character*.
  - **"Clone()"** - returns an instance of Enemy with the current's values copied over.

- **IItem.cs:**
  - Interface implemented by all "Items".
  - All classes that use this must then implement "Name" and a Use() method.
  
- **HealthPotion.cs:**
  - Implements *IItem*.
  - **"Use()"** - returns a health value for the Player to Heal.

- **Direction.cs:**
  - Enum that holds the 4 Compass directions.

- **Room.cs:**
  - Used to track Exits, Enemies and Items.
  - **"Id"** property used to identify Room instances more easily.
  - **"Exit"** - Array that stores room Ids. The index of the Id value determines that room's relative direction.
  - **"ItemPickup()"** - If called, removes the Item from that Room.

#### **View:**

- **IView.cs:**
  - Interface implemented by View.

- **View.cs:**
  - Implements IView.
  - Passes in data from *Controller* and prints text to Console.
---

### **Flowchart:**

```mermaid

```
---

### **References:**
---
