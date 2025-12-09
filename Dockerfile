FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY PostalSearchApi.csproj ./
RUN dotnet restore PostalSearchApi.csproj

COPY . ./
RUN dotnet publish PostalSearchApi.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish ./

EXPOSE 80
ENTRYPOINT ["dotnet", "PostalSearchApi.dll"]
