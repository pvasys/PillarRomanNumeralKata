# PillarRomanNumeralKata
Application Development

Solution for the Kata defined here:
http://agilekatas.co.uk/katas/romannumerals-kata

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

Considerations:
All changes made were performed on a system prior to initial production release.  Some changes such as renaming classes, rearranging code, and fixing small mistakes may not have been undertaken if the code was already in production.

While the solution is overkill for the scope of the problem, I took the opportunity to demonstrate steps toward an ideal and flexible solution.  My approach was focused on demonstrating depth of thought and knowledge instead of producing a minimally viable solution.


I decided to adhere to the specified rules in the kata documentation when creating roman numerals from arabic numerals - but I ignore them when converting from roman numerals to arabic numerals.  This decision was based on several factors:
- User-friendliness.  A best-attempt is better than failure.  If someone isn't familiar with all of the rules and wants to translate IC to a number, returning 99 is nicer than saying "invalid input".  Also, if the user types "vi" (the kata only describes uppercase letters), returning 6 is nicer than an error.
- Additional complexity.  If every rule violation is identified, each rule needs to have a distinct error message.  Also, extra logic will need to be added to detect every violation.
- While the kata specifies "There were certain rules that the numerals followed which should be observed", the given tests do not specify how to handle bad input.  The given use case actually only uses the output from the "to roman numeral" portion of the application, which shouldn't produce any output that violates the set rules.  Therefore, I interpret that statement as introducing the set of rules for generating roman numerals.


Next Steps:

Next steps could involve creating a desktop or web UI to leverage the functionality.  

Adding a CI solution that builds after every commit to master and runs tests would also be valuable.

If specified, add logic, messaging, and tests around enforcing the rules when converting roman numerals to arabic.