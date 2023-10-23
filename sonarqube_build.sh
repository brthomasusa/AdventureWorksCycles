#!/bin/bash

dotnet sonarscanner begin /k:"AdventureWorks" \
    /d:sonar.login=squ_194d635ac46b5c944ab5d9ffe408546bdf515b49 \
    /d:sonar.cs.opencover.reportsPaths=coverage.xml
dotnet build --no-incremental
coverlet /home/bthomas/Projects/NetCore/AdventureWorksCycles/test/UnitTest/bin/Debug/net7.0/UnitTest.dll \
    --target "dotnet" \
    --targetargs "test --no-restore --no-build --nologo -v q --filter AWC.UnitTest" \
    -f=opencover \
    -o="coverage.xml" 
dotnet sonarscanner end /d:sonar.login=squ_194d635ac46b5c944ab5d9ffe408546bdf515b49
