# Use the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file(s) and restore dependencies.
# Adjust the file pattern if your project is in a subfolder.
COPY *.csproj ./
RUN dotnet restore

# Copy all source code and publish the application.
COPY . ./
RUN dotnet publish -c Release -o /app

# Use the .NET runtime image for the final container
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage.
COPY --from=build /app .

# Set the entrypoint to run the console application.
ENTRYPOINT ["dotnet", "EbbingausCurveConsole.dll"]