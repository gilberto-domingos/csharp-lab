# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar csproj e restaurar dependências
COPY ["Presentation/PrintsControl.WebApi/PrintsControl.WebApi.csproj", "Presentation/PrintsControl.WebApi/"]
COPY ["Core/PrintsControl.Application/PrintsControl.Application.csproj", "Core/PrintsControl.Application/"]
COPY ["Core/PrintsControl.Domain/PrintsControl.Domain.csproj", "Core/PrintsControl.Domain/"]
COPY ["Core/PrintsControl.Infrastructure/PrintsControl.Infrastructure.csproj", "Core/PrintsControl.Infrastructure/"]
RUN dotnet restore "Presentation/PrintsControl.WebApi/PrintsControl.WebApi.csproj"

# Copiar todo o código e publicar
COPY . .
WORKDIR /src/Presentation/PrintsControl.WebApi
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Criar pasta para SQLite persistente
RUN mkdir -p /app/data

# Definir variável de ambiente para o SQLite
ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/printscontrol.db"

# Expor a porta do app
EXPOSE 5118

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "PrintsControl.WebApi.dll"]
