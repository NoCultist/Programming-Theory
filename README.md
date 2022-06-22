<p align="center">
  <img src="https://connect-prd-cdn.unity.com/20201002/learn/images/01ae15f1-d8c7-4059-8918-3065f796306b_04_Source_Control__Optimization__and_Publishing_Mission.png.200x0x1.webp"/>
</p>
<h1 align="center">Programming-Theory</h1>
<p align="center">Submission 2 for Jr Programmer Pathway</p>

## Project Design
  *I decided to use the design document I made earlier during learning. It's a destruction-derby-style car racing game.*

### Scene Flow
<p align="center">
  <img src="ReadmeData/Flow-1.jpg"/>
</p>

**Main Menu** scene consists of:
  - Leaderboard that displays 3~5 best times
  - Player name input field (with default value of "Player")
  - Car Selection
  - Start Race button
  - Quit button

**Race** scene consists of:
  - 3D model of players car
  - 3D models of enemy cars
  - Race Track
  - UI Timer
  - UI Speedometer
  - UI Player health


### Objects
Base class **Car** handles main functionalities of all cars that includes storing data such as:
  - speed
  - acceleration
  - health

<p align="center">
  <img src="ReadmeData/Inheritance-1.jpg"/>
</p>

Base class **Enemy** is responsible for enemy behaviour
<p align="center">
  <img src="ReadmeData/Inheritance-2.jpg"/>
</p>
