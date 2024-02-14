
# Estágio base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o projeto e restaura as dependências
COPY ["CifraCesar/CifraCesar.csproj", "CifraCesar/"]
RUN dotnet restore "CifraCesar/CifraCesar.csproj"

# Copia todo o código fonte e constrói o projeto
COPY . .
WORKDIR "/src/CifraCesar"
RUN dotnet build "./CifraCesar.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Estágio de publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CifraCesar.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Estágio final
FROM base AS final
WORKDIR /app

# Copia os arquivos publicados do estágio de publicação
COPY --from=publish /app/publish .

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "CifraCesar.dll"]
