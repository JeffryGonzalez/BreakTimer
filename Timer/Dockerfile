FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Timer/Timer.csproj", "Timer/"]
RUN dotnet restore "Timer/Timer.csproj"
COPY . .
WORKDIR "/src/Timer"
RUN dotnet build "Timer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Timer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Timer.dll"]
