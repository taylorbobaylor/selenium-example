FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Selenium/Selenium.csproj", "Selenium/"]
RUN dotnet restore "Selenium/Selenium.csproj"
COPY . .
WORKDIR "/src/Selenium"
RUN dotnet build "Selenium.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Selenium.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Selenium.dll"]
