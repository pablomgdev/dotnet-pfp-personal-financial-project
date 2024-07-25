FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Commented for now.
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY PfpPersonalFinanceProject.sln ./
COPY src/Api/Api.csproj src/Api/
COPY src/Contracts/Contracts.csproj src/Contracts/
COPY src/Application/Application.csproj src/Application/
COPY src/Domain/Domain.csproj src/Domain/
COPY src/Infrastructure/Infrastructure.csproj src/Infrastructure/
COPY src/Test/Test.csproj src/Test/
RUN dotnet restore
COPY src/ .
RUN dotnet build "Api/Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# `/p:UseAppHost=false` avoid generating an .exe file. As the file is not manually executed (an in linux we cannot
#   neither), it is removed. it also increase the size of the image if it is created.
RUN dotnet publish "Api/Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
