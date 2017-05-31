# PillarRomanNumeralKata
Application Development

The solution was built with the latest version of Visual Studio 2017

To build from command line:
- Open "Developer Command Prompt for VS 2017"
- Navigate to the location of the .sln file
- type: msbuild /t:restore
- type: msbuild /p:configuration=release

To run the tests:
- Open "Developer Command Prompt for VS 2017"
- Navigate to the location of the .sln file
- Navigate to the subfolder VasysRomanNumeralsKataTest
- type: dotnet test