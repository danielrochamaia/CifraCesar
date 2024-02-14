
# Est�gio base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Est�gio de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o projeto e restaura as depend�ncias
COPY ["CifraCesar/CifraCesar.csproj", "CifraCesar/"]
RUN dotnet restore "CifraCesar/CifraCesar.csproj"

# Copia todo o c�digo fonte e constr�i o projeto
COPY . .
WORKDIR "/src/CifraCesar"
RUN dotnet build "./CifraCesar.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Est�gio de publica��o
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CifraCesar.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Est�gio final
FROM base AS final
WORKDIR /app

# Copia os arquivos publicados do est�gio de publica��o
COPY --from=publish /app/publish .

# Define o comando de inicializa��o da aplica��o
ENTRYPOINT ["dotnet", "CifraCesar.dll"]
