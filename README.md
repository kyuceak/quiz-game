<h1>Multiplayer Quiz Game</h1>

<h2>Description</h2>
This repository contains a multiplayer quiz game implemented using C# and the .NET Framework. The game consists of a server module and a client module, allowing multiple players to connect and compete in a quiz game. The server manages the game, questions, and scores, while clients (players) connect to participate using TCP sockets.

<h2>Features</h2>
Server and client modules built using C# and the .NET Framework
Server manages questions, answers, and scoring using TCP sockets for communication
Multiple clients can connect and participate in quiz games concurrently
Unique player names for easy identification and preventing duplicates
Automatic game start when required conditions are met
Handles player disconnections gracefully, updating scores and game status accordingly
GUI for both server and client, displaying game activity and status updates

<h2>Installation</h2>
Clone this repository.
Open the solution file in Visual Studio.
Build the solution to generate the executables for the server and client modules.
Run the server module first, followed by the client module(s) to start the game.

<h2>How To Play</h2>
Start the server module and enter the desired port number, question file name, and number of questions to be asked during the game.
Click "Start" to make the server listen for incoming client connections.
Start the client module(s) and enter the server's IP address, port number, and a unique player name.
Click "Connect" to join the game.
Once the required number of players has connected and the server admin starts the game, answer the questions as they are presented.
The server will handle scoring and display the results after each question using the .NET Framework's built-in TCP communication capabilities.
The game ends when all questions have been asked or only one player remains connected. The final scores will be displayed.
