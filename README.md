Energy Game Test
Overview
This project is a technical test for the Senior Unity Developer position at Infinity Games. The Energy Game demonstrates various game development concepts including element rotation, neighbor detection, graph data structures, and UI management. The game is designed to be both visually appealing and interactive, utilizing particle effects, audio, and haptic feedback to enhance the user experience.

Features
Element Rotation
Square Elements: Rotate by 90 degrees.
Hexagon Elements: Rotate by 120 degrees.
Strategy Pattern: Implements different rotation types based on the game level.
Neighbor Element Detection
Detection Mechanism: Utilizes OnCollider2DTriggerEnter and OnCollider2DTriggerExit.
Rotation Management: Saves specific correct rotations for neighboring components.
Graph Data Structure: Ensures accurate wire illumination effects.
Graph Data Structure
Circuit State Management: Saves the state of the circuit.
Connection Detection: Uses Breadth-First Search (BFS) to detect changes in connections.
Hint System: Stores level solutions to provide hints to users.
Level Editor
Element Management: Saves positions and rotations of elements.
Level Generation: Facilitates runtime level generation.
Hint Storage: Stores correct rotations for hint provision.
Included Levels: Four levels are included in the test.
UI Manager
UI Control: Opens and closes UI elements based on function calls.
Animations: Uses DoTween for smooth transitions and animations.
Level Manager
Data Retrieval: Retrieves level data from ScriptableObject.
Transition Management: Manages level transitions efficiently.
Data Persistence: Saves and loads level data from the persistent data path.
Score Saving
Score Calculation: Configurable score calculator system.
UI Display: Score displayed on a dedicated UI panel.
Particle Effect, Audio, and Haptic
Visual Effects: Background particle effects.
Audio: Background music and sound effects, AI-generated audio.
Haptic Feedback: Responsive user input through haptic feedback.
Assets
Visuals: Created using Canva.
Audio: AI-generated sounds.
Getting Started
Prerequisites
Unity 2020.3 or higher
DoTween (available via Unity Package Manager)
Installation
Clone the repository to your local machine.
bash
Copy code
git clone https://github.com/yourusername/energy-game-test.git
Open the project in Unity.
Ensure all dependencies are installed via the Unity Package Manager.
Usage
Run the game in the Unity Editor to see the Energy Game in action.
Use the Level Editor to create and modify levels.
Use the UI Manager to control UI elements and transitions.
Contributing
Contributions are welcome! Please create a pull request with your changes.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any questions or inquiries, please contact Parth at parth@example.com.
