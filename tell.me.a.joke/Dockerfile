#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["tell.me.a.joke/tell.me.a.joke.csproj", "tell.me.a.joke/"]
RUN dotnet restore "tell.me.a.joke/tell.me.a.joke.csproj"
COPY . .
WORKDIR "/src/tell.me.a.joke"
RUN dotnet build "tell.me.a.joke.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tell.me.a.joke.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tell.me.a.joke.dll"]