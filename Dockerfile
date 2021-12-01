# syntax=docker/dockerfile:1
FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./NetCoreJenkinsDocker.Api/NetCoreJenkinsDocker.Api/*  ./ 

RUN rm -rf Debug
RUN rm -rf Release
RUN rm -rf obj
RUN ls 

RUN dotnet restore
 
RUN dir 
RUN ls 
# Copy everything else and build
# COPY ./NetCoreJenkinsDocker.Api/NetCoreJenkinsDocker.Api/* ./
RUN dotnet publish -c Release -o outp

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/outp .
ENTRYPOINT ["dotnet", "NetCoreJenkinsDocker.Api.dll"]