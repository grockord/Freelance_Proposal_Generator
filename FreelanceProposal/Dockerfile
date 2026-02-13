# Imagen base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagen de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FreelanceProposal.csproj", "./"]
RUN dotnet restore "./FreelanceProposal.csproj"
COPY . .
RUN dotnet publish "FreelanceProposal.csproj" -c Release -o /app/publish

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FreelanceProposal.dll"]
