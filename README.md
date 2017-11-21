# CodeDiff
Code diff tool based on comparing the SyntaxTrees created by the Roslyn compiler

## Changes since forking
- Recreated solution and project files due to some issues with signing and tool versions
- Replaced Microsoft Visual Studio tests with standard NUnit ones
- Removed a lot of non-required package and assembly imports
- Upgraded the beta Roslyn API to the latest stable release (v1.3.2 July 1, 2016)

## Screenshots

![GitHub Logo](/doc/cat-1.png)

Example 1: Someone added a new property and reformatted your file

![GitHub Logo](/doc/cat-2.png)

Example 2: Someone renamed your property and just reformatted again :-(
