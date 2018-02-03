## Coding game
 
This problem requires some kind of input. Feel free to implement any mechanism for feeding input. You can for example use hard coded data within a unit test. You should provide sufficient evidence that your solution is complete. Also, your solution should benefit from a high test coverage.
You can use any open source library you believe relevant for this problem.
The code you write should be of production quality, and most importantly, it should be code you are proud of.

The U.S. army has planned to use scout drones on a battlefield.
 
This battlefield is rectangular. Drones must inspect the field to ease the job of minesweepers.
 
A drone’s position and location are represented by:
- x coordinates
- y coordinates 
- a letter indicating a cardinal compass point. Possible letters are N, E, S and W.  
 
In order to control a drone, a soldier sends a simple string of symbols. The possible symbols are ‘<’, ‘>’ and ‘*’. ‘<’ and ‘>’ makes the drone spin 90 degrees left or right respectively, without moving from its current location. ‘*’ means move forward one unit, keeping the same heading. A drone cannot move out from the battlefield. A '*' command that would get a drone off the field has no effect on the drone.
 
(0,0) are the lower-left coordinates. Assume that the coordinates directly East from (x, y) is (x+1, y).
 
INPUT:
 
On the first line is the upper-right coordinates of the battlefield. 
 
The rest of the input is information pertaining to the drones that have been deployed. Each drone has two lines of input. The first line gives the drone’s position, and the second line is a series of instructions telling the drone how to explore the battlefield.
 
The position is made up of the x and y co-ordinates and the drone’s orientation. For example "0 0 E" means the drone is in the bottom left corner and facing East.
 
Each drone will be finished sequentially, which means that the second drone won’t start to move until the first one has finished moving.
 
OUTPUT

The output for each drone should be its final co-ordinates and heading.

INPUT AND OUTPUT

Test Input:

5 5
1 1 N
>********<**********
1 2 N
<*<*<*<**
3 3 E
**>**>*>>*

## Usage

- The library can currently only be run from NUnit tests, so ReSharper, NCrunch, TestDriven.net or any other test runner is required.

## Assumptions/Decisions

- The top right corner of the board refers to conventional axis representation (https://www.greatescapepublishing.com/wp-content/uploads/thephotographerslife/wp-content/media//2014/06/xy-axes-300x295.jpg), not https://www.haiku-os.org/legacy-docs/bebook/images/TheInterfaceKit/coords2.png .
- A board with a top-right position of {0,0} is permitted.
- Extra spaces are permitted on both board and drone configuration lines, as the user intent is still clear.
- A drone can be configured with either negative x or y, but will fail from being placed on the board.
- Two drones can overlap at the same point on the battlefield.
- Extra spaces are not permitted on drone movement lines, as each character should represent a known drone movement.
- Movement line can be omitted if last line of content.
- Output format is undefined in requirements, so output is: "{X position} {Y position} {Orientation}"  
- Output is simply written to Console.
- No Logger is used, as all errors bubble up as exceptions.

## Known limitations

- 

## Extensibility

-