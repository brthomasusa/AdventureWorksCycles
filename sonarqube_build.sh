#!/bin/bash

dotnet sonarscanner begin /k:"AdventureWorks" /d:sonar.host.url=http://dell-svr:9000 /d:sonar.login=squ_194d635ac46b5c944ab5d9ffe408546bdf515b49 
dotnet build
dotnet sonarscanner end /d:sonar.login=squ_194d635ac46b5c944ab5d9ffe408546bdf515b49
