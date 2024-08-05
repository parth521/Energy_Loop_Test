
# **Energy Game Test**

## **Summary**

This project is a technical test for the Senior Unity Developer position at Infinity Games. It demonstrates various game development concepts, including element rotation, neighbor detection, graph data structures, and UI management. The game is designed to be interactive and visually appealing, utilizing particle effects, audio, and haptic feedback to enhance the user experience.

### **Element Rotation**

* **Square Elements**: Rotate by 90 degrees.  
* **Hexagon Elements**: Rotate by 120 degrees.  
* **Strategy Pattern**: Utilizes a strategy pattern for different rotation types based on the level.

### **Neighbor Element Detection**

* **Detection Mechanism**: Uses `OnCollider2DTriggerEnter` and `OnCollider2DTriggerExit`.  
* **Correct Rotations**: Saves specific correct rotations for neighboring components.  
* **Graph Data Structure**: Ensures accurate wire illumination effects.

### **Graph Data Structure**

* **Circuit State**: Saves the state of the circuit.  
* **Connection Detection**: Uses Breadth-First Search (BFS) to detect connection changes.  
* **Level Solutions**: Stores level solutions to provide hints to users.

### **Level Editor**

* **Element Management**: Saves positions and rotations of elements.  
* **Level Generation**: Facilitates runtime level generation.  
* **Hint Storage**: Stores correct rotations for hints.  
* **Levels**: Four levels included.

### **UI Manager**

* **UI Control**: Opens and closes UI elements based on function calls.  
* **Animations**: Uses DoTween for smooth transitions and animations.

### **Level Manager**

* **Data Retrieval**: Retrieves level data from `ScriptableObject`.  
* **Level Transitions**: Manages level transitions efficiently.  
* **Data Persistence**: Saves and loads level data from persistent data path.

### **Score Saving**

* **Score Calculator**: Configurable score calculator system.  
* **Score Display**: UI panel for score display.

### **Particle Effect, Audio, and Haptic**

* **Visual Effects**: Background particle effects.  
* **Audio**: Background music and sound effects.  
* **Haptic Feedback**: Responsive user input through haptic feedback.

### **Assets**

* **Visuals**: Created using Canva.  
* **Audio**: AI-generated audio.

## **Getting Started**

### **Prerequisites**

* Unity 2020.3 or higher  
* DoTween (available via Unity Package Manager)

### **Installation**

Clone the repository to your local machine.  
bash  
Copy code  
`git clone https://github.com/yourusername/energy-game-test.git`

1.   
2. Open the project in Unity.  
3. Ensure all dependencies are installed via the Unity Package Manager.

### **Usage**

* Run the game in the Unity Editor to see the Energy Game in action.  
* Use the Level Editor to create and modify levels.  
* Use the UI Manager to control UI elements and transitions.

## **Contact**

For any questions or inquiries, please contact Parth at dodiya.parth20@gmail.com

