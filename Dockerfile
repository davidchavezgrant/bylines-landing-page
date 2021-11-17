FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY Bylines.LandingPage.csproj .
RUN dotnet restore "Bylines.LandingPage.csproj"
COPY . .
RUN dotnet build "Bylines.LandingPage.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Bylines.LandingPage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bylines.LandingPage.dll"]
