# Fragged Empire Generator

The goal of this repo is to generate markdown of themed NPCs and ships quickly and at a specific difficulty level.
Without referring to multiple tables in the rule book.

### Example

| Name | Hit | Def | Actions |
| ---- | --- | --- | ------- |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |
| Critter | 3d6 + 2 (3 Endure, 3 Crit, 3 Range) | 2 (12 Durability, 2 Armour) | 1 |

Hechmen Damage
: Each Attacking Body grants +1d6 Hit and +1 End Dmg

Hechmen Lack Initiative:
: Always acts last in combat

Hechmen Shared Endurance:
        Hechmen share endurance pool

Hechmen Shared Action:
        Hechmen share 1 action per turn
        
NPC Munitions (1):
        1 Munitions per turn per weapon.
        Modifiers (reload / disrupt) only apply to current or next turn.
        Reload +2M

### Challenges

Most entity types (NPC, Ship, Weapon, Outfit) are a combination of Base + Variation + Modification from seperate tables.
The columns will match but the rows will contain many conditional keywords, so that might make the first pass of this a bit messy.
