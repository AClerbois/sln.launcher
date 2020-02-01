![Designed by Dooder](/icon.jpg)

# sln.launcher
If like me, you like to play as much as possible with the command lines and you want to launch Visual Studio with the file with the extension sln in the current directory. sln.launcher is the solution.

A dotnet tools allows you to launch Visual Studio with a .sln file in the current directory. In the case of several available files, the user is asked to select one.

## Build status 
[![Build Status](https://aclerbois.visualstudio.com/aclerbois.sln.launcher/_apis/build/status/AClerbois.sln.launcher?branchName=master)](https://aclerbois.visualstudio.com/aclerbois.sln.launcher/_build/latest?definitionId=15&branchName=master)

## Deployment status
[![Deployment Status](https://aclerbois.vsrm.visualstudio.com/_apis/public/Release/badge/a08f2184-e493-41ce-af0f-7ffbc4a8ed53/1/1)](https://aclerbois.visualstudio.com/aclerbois.sln.launcher/_release?definitionId=1)

## How to install
In order to use this tool, you must have the .NET Core SDK 2.1+.
You can install the tool by running the following line.

```shell
dotnet tool install --global sln.launcher --version 1.0.2
```

## How to use
You are in command prompt, you want to launch Visual Studio but you don't want to type the name of the complete file

sln is THE solution:
```shell
sln
```

Visual Studio will launch itself and open the solution of the current folder.

In case there is no file with the extension sln, an error will be presented to you.

In case you have more than one file with the extension sln in the folder, the program will ask you to choose which one you want to open.

## Requirements

In order to use this dotnet tools, you must have installed on your computer: 
- [Visual Studio](https://visualstudio.microsoft.com/fr/)
- [.NET Core SDK 2.1+](https://www.microsoft.com/net/download)

And finally, you must have the.sln extensions which have as default program Visual Studio. 

## Credit logo
![Designed by Dooder](/icon.jpg)
[Designed by Dooder](https://www.freepik.com/free-vector/businessman-over-a-rocket_1076127.htm)
