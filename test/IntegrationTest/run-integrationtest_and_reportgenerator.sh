#!/bin/bash

dotnet build -m
dotnet test --no-restore --no-build --nologo -v q --filter AWC.IntegrationTest  /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:Include=\"[*Application*]*,[*Core*]*,[*Infrastructure*]*,[*Presentation*]*,[*Server*]*\"
reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:TestResults/core.html" -reporttypes:HTML;
firefox file:///home/bthomas/Projects/NetCore/AdventureWorksCycles/test/UnitTest/TestResults/core.html/index.html &
