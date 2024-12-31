# AI Comparison Project: GOAP vs FSM
This project demonstrates and compares two artificial intelligence techniques: **Goal-Oriented Action Planning (GOAP)** and **Finite State Machine (FSM)**. The NPC uses these techniques to interact with the environment, make decisions, and achieve goals. The primary aim is to evaluate how each technique performs under varying conditions.
This project is created in Unity game engine

## Features

- **GOAP Implementation**:
  - Dynamically prioritizes goals like gathering resources, crafting arrows, eating food, and handling enemies.
  - Adaptive decision-making based on environmental conditions and NPC state.

- **FSM Implementation**:
  - Executes predefined states sequentially.
  - Simpler but less flexible compared to GOAP.

- **Comparison Metrics**:
  - Measure NPC performance using metrics like:
    - **Time Survived**
    - **Enemies Killed**
    - **Resources Gathered**

- **Game Elements**:
  - **Resources**: Wood, Stone, and Food spawn randomly.
  - **Enemies**: Spawn randomly and interact with the NPC.
  - **Actions**: NPC gathers resources, crafts arrows, eats food, and attacks or avoids enemies.

- **End State**:
  - Displays a "Game Over" popup when the NPC’s health reaches zero.
  - Allows restarting via a button that returns to the start menu.

## Project Structure

### Scripts

- **GOAP System**:
  - `GOAPPlanner`: Manages goals and actions, dynamically prioritizing tasks.
  - `GOAPGoal`: Defines specific goals for the NPC.
  - `GOAPAction`: Base class for actions (e.g., `GatherWoodAction`, `GatherStoneAction`, `AttackEnemyAction`).

- **FSM System**:
  - `FSMController`: Manages states and transitions for NPC behavior.
  - State scripts include `IdleState`, `GatherWoodState`, `AttackEnemyState`, etc.

- **Shared Systems**:
  - `NPC`: Manages health, hunger, and statistics like time survived and enemies killed.
  - `ResourceManager`: Tracks resources (wood, stone, arrows) and handles crafting.
  - `Spawner`: Spawns resources and enemies dynamically.

### Scenes

- **StartMenu**: Allows the player to choose between GOAP and FSM for the NPC.
- **GameScene**: The main gameplay environment with the NPC and other game elements.

