# 🪑 AR Furniture Placement

An Augmented Reality furniture placement application built with **Unity, AR Foundation, and XR Simulation**. The project allows users to detect surfaces, select furniture items, place them in the environment, and interact with placed objects.

> **Note:** This project uses **XR Simulation** for development and testing without requiring a physical ARCore-supported Android device.

## 🎮 Features

- 🔍 **Plane Detection** — Detects horizontal surfaces in the environment.
- 🪑 **Furniture Selection** — Select furniture models through the UI.
- 📍 **Furniture Placement** — Place selected furniture on detected surfaces.
- ✋ **Furniture Movement** — Move placed furniture by dragging.
- 🔄 **Furniture Rotation** — Rotate furniture using user input.
- 🗑️ **Furniture Removal** — Remove previously placed furniture.
- 🟨 **Plane Visualization** — Displays detected surfaces during AR simulation.
- 🎮 **XR Simulation Support** — Test AR interactions directly inside the Unity Editor.
- 🖱️ **Input System** — Uses Unity's New Input System for interaction controls.

## 🛠️ Technologies Used

- **Unity 2022.3 LTS**
- **C#**
- **AR Foundation**
- **XR Simulation**
- **Unity Input System**
- **Unity UI**
- **3D Models & Prefabs**

## 🏗️ Project Structure

```text
Assets/
├── My Assets/
│   ├── Scripts/
│   │   ├── UI System/
│   │   └── ...
│   ├── Prefabs/
│   ├── Scenes/
│   └── ...
├── ...
Packages/
ProjectSettings/
```

## 🎯 How It Works

The application follows a simple AR furniture placement workflow:

```text
Start AR Simulation
       ↓
Detect Surface
       ↓
Select Furniture
       ↓
Place Furniture
       ↓
Move / Rotate Furniture
       ↓
Remove Furniture
```

### 1. Surface Detection

AR Foundation's plane detection system identifies available surfaces. In XR Simulation, these surfaces are simulated inside the Unity Editor.

### 2. Furniture Selection

The user selects a furniture item from the UI. The corresponding furniture prefab is then prepared for placement.

### 3. Furniture Placement

The user selects a detected surface and places the furniture object at the selected position.

### 4. Furniture Interaction

After placement, the furniture can be:

- Moved
- Rotated
- Removed

This provides the basic interaction flow of an AR interior/furniture visualization application.

## 🧪 XR Simulation

Because physical AR devices are not required for this project, **XR Simulation** is used to test the AR experience inside Unity.

This makes it possible to develop and test:

- Plane detection
- Object placement
- Object movement
- Object rotation
- User interactions

without requiring a physical ARCore-supported device during development.

## 🚀 Getting Started

### Requirements

- Unity **2022.3 LTS**
- AR Foundation package
- XR Simulation support
- Input System package

### Installation

1. Clone the repository:

```bash
git clone https://github.com/YOUR_USERNAME/AR-Furniture-Placement.git
```

2. Open the project using **Unity 2022.3 LTS**.

3. Open the main AR furniture placement scene.

4. Enable/use **XR Simulation**.

5. Enter Play Mode and interact with the simulated AR environment.

## 🎮 Controls

| Action | Input |
|---|---|
| Move / Navigate | Mouse / Input System |
| Select | Left Mouse Button |
| Rotate | Right Mouse Button / configured input |
| Additional interaction | Configured Input Actions |

> Controls may vary depending on the current Input System configuration.

## 📸 Screenshots

Add screenshots or GIFs of the project here.

Example:

```text
[Add AR simulation screenshot here]
```

## 📚 What I Learned

Through this project, I worked with:

- Unity AR Foundation
- XR Simulation
- AR plane detection
- AR object placement
- Prefab-based furniture systems
- Object manipulation
- Unity's New Input System
- UI-based object selection
- AR interaction workflows

## 🔮 Future Improvements

Possible improvements include:

- Furniture scaling
- Improved rotation controls
- Surface validation
- Furniture snapping
- Multiple furniture categories
- Save/load furniture layouts
- Screenshot functionality
- Real-device ARCore testing
- Improved placement and interaction feedback
- Furniture collision and surface validation

## 👨‍💻 Author

**Anis Sayyad**

Unity / AR Developer

### 📌 Project

**AR Furniture Placement**

Built with Unity and AR Foundation as a learning and portfolio project focused on AR development and interactive object placement.
