# Setp 1 : Getting the SDK Image
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-dev
WORKDIR /app

# Setp 2 : Copy the CS Proj and Restore Command
# COPY . ./
# RUN dotnet restore

# Step 3 : Copy Everything Else and Build 
COPY . ./
RUN dotnet publish "Footboll.Team.WebApi" -c Release -o out

# Step 4 : Build the Runtime Image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 as build-prod
WORKDIR /app
COPY --from=build-dev /app/"Footboll.Team.WebApi"/out .
ENTRYPOINT [ "dotnet","Footboll.Team.WebApi.dll" ]