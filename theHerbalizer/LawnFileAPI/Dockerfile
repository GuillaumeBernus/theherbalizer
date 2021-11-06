#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LawnFileAPI/LawnFileAPI.csproj", "LawnFileAPI/"]
RUN dotnet restore "LawnFileAPI/LawnFileAPI.csproj"
COPY . .
WORKDIR "/src/LawnFileAPI"
RUN dotnet build "LawnFileAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LawnFileAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LawnFileAPI.dll"]