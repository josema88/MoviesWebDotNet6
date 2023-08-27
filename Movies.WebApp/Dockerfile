FROM mcr.microsoft.com/dotnet/core/aspnet:6.0 AS base
WORKDIR /Movies.WebApp
EXPOSE 80


#Stage 2: Build and publish the code

FROM mcr.microsoft.com/dotnet/core/sdk:6.0 AS build
WORKDIR /Movies.WebApp
COPY Movies.WebApp.csproj .
RUN dotnet restore
COPY . .
RUN dotnet build -c Release

FROM build AS publish
RUN dotnet publish -c Release -o /publish


#Stage 3: Build and publish the code

FROM base AS final
WORKDIR /Movies.WebApp
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "Movies.WebbApp.dll"]