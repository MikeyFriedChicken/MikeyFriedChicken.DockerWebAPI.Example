FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
# COPY *.sln .
COPY *.csproj ./MikeyFriedChicken.DockerWebAPI.Example/
RUN dotnet restore MikeyFriedChicken.DockerWebAPI.Example/MikeyFriedChicken.DockerWebAPI.Example.csproj

# copy everything else and build app
COPY . ./MikeyFriedChicken.DockerWebAPI.Example/
WORKDIR /app/MikeyFriedChicken.DockerWebAPI.Example
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/MikeyFriedChicken.DockerWebAPI.Example/out ./

ENV ASPNETCORE_URLS http://+:11000
EXPOSE 11000

ENTRYPOINT ["dotnet", "MikeyFriedChicken.DockerWebAPI.Example.dll"]
