# Stage base para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

# Stage de build para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY GestaoResiduos/GestaoResiduos.csproj GestaoResiduos/
RUN dotnet restore "./GestaoResiduos/GestaoResiduos.csproj"

# Copia todos os arquivos do projeto e faz o build
COPY . .
WORKDIR "/src/GestaoResiduos"
RUN dotnet build "./GestaoResiduos.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Stage de publicação do build
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GestaoResiduos.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Stage final para rodar a aplicação
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Definir a variável de ambiente para produção
ENV ASPNETCORE_ENVIRONMENT=Production

# Comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "GestaoResiduos.dll"]
