# Estágio de construção
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia o projeto e restaura as dependências
COPY ["CifraCesar/CifraCesar.csproj", "CifraCesar/"]
RUN dotnet restore "CifraCesar/CifraCesar.csproj"

# Copia todo o código fonte e constrói o projeto
COPY . .
WORKDIR "/src/CifraCesar"
RUN dotnet build "CifraCesar.csproj" -c Release -o /app/build

# Estágio de publicação
FROM build AS publish
RUN dotnet publish "CifraCesar.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copia os arquivos publicados do estágio de publicação
COPY --from=publish /app/publish .

# Define o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "CifraCesar.dll"]
