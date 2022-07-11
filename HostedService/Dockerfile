#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HostedService/HostedService.csproj", "HostedService/"]
COPY ["Phidelis.Entities/Phidelis.Entities.csproj", "Phidelis.Entities/"]
COPY ["Phidelis/Phidelis.csproj", "Phidelis/"]
COPY ["Phidelis.Repository/Phidelis.Repository.csproj", "Phidelis.Repository/"]
COPY ["Phidelis.Service/Phidelis.Service.csproj", "Phidelis.Service/"]
RUN dotnet restore "HostedService/HostedService.csproj"
COPY . .
WORKDIR "/src/HostedService"
RUN dotnet build "HostedService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HostedService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostedService.dll"]