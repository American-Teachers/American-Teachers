#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ["AtApi Solution.sln", ""] 
COPY ["AtApi/AtApi.csproj", "AtApi/"]
COPY ["AtApi.Model/AtApi.Model.csproj", "AtApi.Model/"]
COPY ["AtApi.Service/AtApi.Service.csproj", "AtApi.Service/"]
COPY ["AtApi.UnitTests/AtApi.UnitTests.csproj", "AtApi.UnitTests/"]

RUN dotnet restore "AtApi Solution.sln" 
#RUN dotnet test "AtApi Solution.sln" 
COPY . .
WORKDIR "/src/AtApi"
RUN dotnet build "AtApi.csproj" -c Release  --no-restore -o /app/build
 
FROM build AS publish
RUN dotnet publish "AtApi.csproj" -c Release  --no-restore -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AtApi.dll"]