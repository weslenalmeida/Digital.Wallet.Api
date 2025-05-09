FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:80"
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["*.sln", "./"]
COPY ["Api/Api.csproj", "Api/"]
COPY ["CrossCutting.Configuration/CrossCutting.Configuration.csproj", "CrossCutting.Configuration/"]
COPY ["CrossCutting.Exceptions/CrossCutting.Exceptions.csproj", "CrossCutting.Exceptions/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure.Data/Infrastructure.Data.csproj", "Infrastructure.Data/"]
COPY ["Tests.Shared/Tests.Shared.csproj", "Tests.Shared/"]
COPY ["Tests.Unity/Tests.Unity.csproj", "Tests.Unity/"]

RUN dotnet restore "Api/.Api.csproj"
COPY . . 
WORKDIR "/src/Api"

RUN mv appsettings.Docker.json appsettings.json
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN sed -i 's/MinProtocol = TLSv1.2/MinProtocol = TLSv1/g' /etc/ssl/openssl.cnf
RUN sed -i 's/CipherString = DEFAULT@SECLEVEL=2/CipherString = DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf
ENTRYPOINT ["dotnet", "Digital.Wallet.Api.dll"]