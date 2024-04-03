#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Web/Web.csproj", "Web/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["src/Api/Api.csproj", "Api/"]
COPY ["src/Domain/Domain.csproj", "Domain/"]

#COPY ["src/Web/Web.csproj", "Web/"]
RUN dotnet restore "Web/Web.csproj"
RUN dotnet restore "Api/Api.csproj"
RUN dotnet restore "Domain/Domain.csproj"
RUN dotnet restore "infrastructure/infrastructure.csproj"


COPY /src/ /src/
WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Web.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "My-Place-Backend.dll"]