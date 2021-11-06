FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MfPulse.Api/MfPulse.Api.csproj", "MfPulse.Api/"]
RUN dotnet restore "MfPulse.Api/MfPulse.Api.csproj"
COPY . .
WORKDIR "/src/MfPulse.Api"
RUN dotnet build "MfPulse.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MfPulse.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MfPulse.Api.dll"]
