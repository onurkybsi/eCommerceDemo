FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY ecommerceDemo.sln .
COPY Infrastructure/*.csproj ./Infrastructure/
COPY ecommerceDemo.Data/*.csproj ./ecommerceDemo.Data/
COPY ecommerceDemo.Service/*.csproj ./ecommerceDemo.Service/
COPY ecommerceDemo.Host/*.csproj ./ecommerceDemo.Host/

RUN dotnet restore

COPY . ./

WORKDIR /app/ecommerceDemo.Host
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/ecommerceDemo.Host/out ./
ENTRYPOINT ["dotnet", "ecommerceDemo.Host.dll"]