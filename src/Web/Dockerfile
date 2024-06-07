

FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
WORKDIR /ap
EXPOSE 5000
EXPOSE 5001

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
RUN dotnet build "Web.csproj" -c ${BUILD_CONFIGURATION} -o /ap/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Web.csproj" -c ${BUILD_CONFIGURATION} -o /ap/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /ap
COPY --from=publish /ap/publish .
ENTRYPOINT ["dotnet", "Web.dll"]