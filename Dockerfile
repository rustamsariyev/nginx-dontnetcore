FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

#Copy csproj and restore ass distint layers
COPY *.sln .
COPY Library/*.csproj ./Library/
RUN dotnet restore

# copy everything else and build app
COPY Library/. ./Library/
WORKDIR /app/Library/
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/Library/out ./
ENTRYPOINT ["dotnet", "Library.dll"]

