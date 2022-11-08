FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CreatePassword/CreatePassword.csproj", "CreatePassword/"]
RUN dotnet restore "CreatePassword/CreatePassword.csproj"
COPY . .
WORKDIR "/src/CreatePassword"
RUN dotnet build "CreatePassword.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CreatePassword.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CreatePassword.dll"]
