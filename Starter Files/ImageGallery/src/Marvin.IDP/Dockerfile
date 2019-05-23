FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SRC/Marvin.IDP/Marvin.IDP.csproj", "SRC/Marvin.IDP/"]
RUN dotnet restore "SRC/Marvin.IDP/Marvin.IDP.csproj"
COPY . .
WORKDIR "/src/SRC/Marvin.IDP"
RUN dotnet build "Marvin.IDP.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Marvin.IDP.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Marvin.IDP.dll"]