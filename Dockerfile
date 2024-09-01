# Etapa de Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo .csproj e restaure as dependências
COPY App/app.csproj ./App/
RUN dotnet restore App/app.csproj

# Copie o restante dos arquivos e compile a aplicação
COPY . .
WORKDIR /src/App
RUN dotnet build app.csproj -c Release -o /app/build

# Etapa de Publish
FROM build AS publish
RUN dotnet publish app.csproj -c Release -o /app/publish

# Etapa Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /App
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "app.dll"] 
