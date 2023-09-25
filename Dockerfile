FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["src/Application/Application.csproj", "Application/"]
COPY ["src/Client/Client.csproj", "Client/"]
COPY ["src/Core/Core.csproj", "Core/"]
COPY ["src/gRPC.Contracts/gRPC.Contracts.csproj", "gRPC.Contracts/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["src/Presentation/Presentation.csproj", "Presentation/"]
COPY ["src/Server/Server.csproj", "Server/"]
COPY ["src/Shared/Shared.csproj", "Shared/"]
COPY ["src/SharedKernel/SharedKernel.csproj", "SharedKernel/"]

RUN dotnet restore "Server/Server.csproj"
COPY src/. .

RUN dotnet build "Server/Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Server/Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]