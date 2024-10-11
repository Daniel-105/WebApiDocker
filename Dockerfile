FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ./WebApiDocker/WebApiDocker.csproj .
COPY . .
RUN dotnet restore "WebApiDocker.csproj"
RUN dotnet publish "./WebApiDocker/WebApiDocker.csproj" -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /publish .

ENTRYPOINT ["dotnet", "WebApiDocker.dll"]
