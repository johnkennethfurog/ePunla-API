#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ePunla.Query.API/ePunla.Query.API.csproj", "ePunla.Query.API/"]
COPY ["ePunla.Query.Business/ePunla.Query.Business.csproj", "ePunla.Query.Business/"]
COPY ["ePunla.Query.DAL/ePunla.Query.DAL.csproj", "ePunla.Query.DAL/"]
COPY ["ePunla.Query.Domain/ePunla.Query.Domain.csproj", "ePunla.Query.Domain/"]
COPY ["ePunla.Common.Utilitites/ePunla.Common.Utilitites.csproj", "ePunla.Common.Utilitites/"]
RUN dotnet restore "ePunla.Query.API/ePunla.Query.API.csproj"
COPY . .
WORKDIR "/src/ePunla.Query.API"
RUN dotnet build "ePunla.Query.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ePunla.Query.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ePunla.Query.API.dll"]
