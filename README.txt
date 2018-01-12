----------------------------------------------------------------
To build and execute the project, please follow the steps below:
----------------------------------------------------------------

----------------------------------------------------------------
Running Frontend:
----------------------------------------------------------------
1 - Download and install Node.js 4.2.4 in your computer:
    - https://nodejs.org/en/download/
2 - Go to the project root directory in command prompt:
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAurora
3 - Execute the command below to install all the node modules necessary to run the project:
    - npm install
4 - When finish the node modules instalation, go to 'ts' directory in command prompt. This directory contains all typeScript files.
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAurora\ts
5 - Execute the command below to compile the typeScript files and generate the javascript files:
    - tsc
6 - Return to main directory.
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAurora or cd ..
7 - Execute the command below to install http-server globally
    - npm install http-server -g
8 - Execute the command below to run the application
    - http-server . -o

----------------------------------------------------------------
Running Backend:
----------------------------------------------------------------
1 - Download and install DotnetCore 2.1.2 in your computer:
    - https://www.microsoft.com/net/download/thank-you/dotnet-sdk-2.1.2-windows-x64-installer
2 - Go to the projectApi root directory in command prompt:
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAuroraApi
3 - Execute the command below to run the application
    - dotnet run

Obs.: If your project don't run on http://localhost:5000, please adjuste the url on file CategoriesViewModel.ts 
and repeat the steps to run frontend from step 4

----------------------------------------------------------------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
----------------------------------------------------------------

----------------------------------------------------------------
To execute the tests, please follow the steps below:
----------------------------------------------------------------

----------------------------------------------------------------
Running Frontend tests:
----------------------------------------------------------------
1 - Go to the project root directory in command prompt:
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAurora
3 - Execute the command below to run all tests:
    - karma start

----------------------------------------------------------------
Running Backend tests:
----------------------------------------------------------------
2 - Go to the project Api Tests root directory in command prompt:
    - Example to Windows: cd C:\Documents\GitHub\ProjetoAuroraApiTests
3 - Execute the command below to run all tests
    - dotnet test