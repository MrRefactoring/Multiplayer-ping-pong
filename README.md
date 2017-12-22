# Ping pong
Ping pong. The project is written for lab work on programming applications in C # using windows wpf
<img src="https://mrrefactoring.github.io/content/pictures/PingPongFirstScreen.png" width="430"/>
<img src="https://mrrefactoring.github.io/content/pictures/PingPongSecondScreen.png" width="430"/>
# How run
##### The first way (using Visual Studio):
1) Clone the repository in the project folder
2) Open the `PingPong.sln` in Visual Studio 2017 (or later)
3) Choose `Build` , after `Build` or `Build Solution`
4) Run `PingPong.exe` in $PROJECTS_DIRECTORY/PingPong/PingPong/bin/`Debug` or `Release`/
5) Have a good game!
##### The second way (using CMD):
1) Clone the repository in the project folder
2) Open CMD, write: `msbuild.exe $PROJECRS_DIRECTORY/PingPong/PingPong.sln`
3) Run `PingPong.exe` in $PROJECTS_DIRECTORY/PingPong/PingPong/bin/`Debug` or `Release`/
4) Have a good game!
# How work
The game field is launched in the file `PlayGround.xaml.cs`. An instance of the `GameLoop.cs` class is created there. `GameLoop.cs` creates a new thread to execute the game logic until it is stopped by closing the application. In the loop, there is an appeal to `Logic.cs`, which is in the project `Lib`. `Logic.cs` performs all the logic of ping pong
