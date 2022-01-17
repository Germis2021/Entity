#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Entity/Entity.csproj", "Entity/"]
RUN dotnet restore "Entity/Entity.csproj"
COPY . .
WORKDIR "/src/Entity"
RUN dotnet build "Entity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Entity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Entity.dll"]