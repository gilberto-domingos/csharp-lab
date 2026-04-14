# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar csproj e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todo o código e publicar
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Criar pasta para SQLite persistente
RUN mkdir /app/data

# Definir variável de ambiente para o SQLite
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/database.db"

# Expõe a porta do app
EXPOSE 5000

# Comando para rodar
ENTRYPOINT ["dotnet", "Expenses.API.dll"]
