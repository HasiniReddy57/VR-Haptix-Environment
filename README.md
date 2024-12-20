# VR Haptix Environment

Welcome to the **VR Haptix Environment** project! This Unity-based project focuses on delivering immersive VR experiences with integrated haptic feedback. This README provides detailed steps to set up, clone, and run the project locally.

---

## Prerequisites

Before you begin, ensure you have the following installed on your system:

1. **Unity Editor**:  
   - Version: `2022.3.5f1` (LTS) or compatible.  
   - [Download Unity Hub and Unity Editor](https://unity.com/download).  

2. **Git**:  
   - [Download Git](https://git-scm.com/downloads).  

3. **VR Headset and Tools** (if applicable):  
   - Oculus Quest 2 or a similar VR headset.  
   - Oculus SDK/SteamVR SDK installed in Unity (optional, based on project requirements).  

---

## Setup Instructions

Follow these steps to set up the project locally:

### Step 1: Clone the Repository

1. Open a terminal/command prompt.
2. Navigate to the directory where you want to clone the project.
3. Run the following command:  
   ```bash
   git clone https://github.com/HasiniReddy57/VR-Haptix-Environment.git
   ```

### Step 2: Open the Project in Unity

1. Open **Unity Hub**.  
2. Click on the `Add` button and navigate to the directory where you cloned the repository.  
3. Select the `VR-Haptix-Environment` folder and click `Open`.  

### Step 3: Verify Project Settings

1. Go to `Edit > Project Settings` in Unity.  
2. Ensure the following settings are configured:  
   - **Scripting Backend**: `IL2CPP`  
   - **API Compatibility Level**: `.NET 4.x`  
   - **Platform**: `PC, Mac & Linux Standalone` or `Android` (for VR headsets).  

### Step 4: Install Dependencies

1. Open the `Package Manager` (`Window > Package Manager`).
2. Verify that all required packages are installed.  
   - Ensure compatibility with Oculus SDK or SteamVR SDK, depending on your VR headset.  
3. Resolve any missing dependencies by clicking `Fix All` if prompted.

### Step 5: Build and Run

1. Go to `File > Build Settings`.  
2. Select the appropriate platform:  
   - For VR Headsets: Select `Android` or `Windows` based on your headset.  
3. Click `Switch Platform` (if required).  
4. Click `Build and Run`.  
5. If using a VR headset, ensure the device is connected and set to developer mode.

---

## Additional Notes

- **Unity Version Compatibility**:  
   Using a different Unity version may cause errors. Ensure you're using `2022.3.5f1` or a compatible LTS version.  
   
- **Known Issues**:  
   - Missing dependencies or package errors can often be resolved in the Package Manager.  
   - If the VR integration does not work as expected, double-check the headset drivers and SDK installation.  

- **Support**:  
   For issues, please open an issue in the [GitHub Issues section](https://github.com/HasiniReddy57/VR-Haptix-Environment/issues).  

---

Thank you for exploring the VR Haptix Environment! 🚀  
