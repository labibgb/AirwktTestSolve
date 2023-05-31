FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TextAnalytics.Api/TextAnalytics.Api.csproj", "TextAnalytics.Api/"]
RUN dotnet restore "TextAnalytics.Api/TextAnalytics.Api.csproj"
COPY . .
WORKDIR "/src/TextAnalytics.Api"
RUN dotnet build "TextAnalytics.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TextAnalytics.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TextAnalytics.Api.dll"]
