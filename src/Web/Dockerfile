#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#USER app
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["src/Web/Web.csproj", "src/Web/"]
#COPY ["src/Api/Api.csproj", "src/Api/"]
#COPY ["src/Domain/Domain.csproj", "src/Domain/"]
#COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
#RUN dotnet restore "./src/Web/./Web.csproj"
#COPY . .
#WORKDIR "/src/Web"
#
#RUN dotnet build "src/src/Web/Web.csproj" -c $BUILD_CONFIGURATION -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "src/src/Web/Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Web.dll"]
#


FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /app
EXPOSE 8000
EXPOSE 8001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
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
RUN dotnet restore "Infrastructure/Infrastructure.csproj"


COPY /src/ /src/
WORKDIR "/src/Web"
RUN dotnet build "Web.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Web.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /ap/publish .
ENTRYPOINT ["dotnet", "Web.dll"]