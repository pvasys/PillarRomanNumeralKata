# PillarRomanNumeralKata
Application Development

The solution was built with the latest version of Visual Studio 2017

To build from command line:
- Open "Developer Command Prompt for VS 2017"
- Navigate to the location of the .sln file
- type: dotnet restore
- type: dotnet build -c release

To run the tests:
- Open "Developer Command Prompt for VS 2017"
- Navigate to the location of the .sln file
- Navigate to the subfolder VasysRomanNumeralsKataTest
- type: dotnet test

To run the application:
- Open "Developer Command Prompt for VS 2017"
- Navigate to the location of the .sln file
- Navigate to the subfolder VasysRomanNumeralsKata
- type: dotnet run <arabic number>


Next Steps:
While the solution is overkill for the scope of the problem, I took the opportunity to demonstrate steps toward an ideal and flexible solution.

Next steps might involve creating a desktop or web UI to leverage the functionality.  Adding a CI solution that builds after every commit to master and runs tests would also be valuable.