FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5165

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "IMT-Backend.WebUI/IMT-Backend.WebUI.csproj"

FROM build AS publish
RUN dotnet publish "IMT-Backend.WebUI/IMT-Backend.WebUI.csproj" -c Release -o /app/publish -v d

FROM base AS final
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IMT-Backend.WebUI.dll"]