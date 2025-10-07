FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Presentation/PrintsControl.WebApi/PrintsControl.WebApi.csproj", "Presentation/PrintsControl.WebApi/"]
COPY ["Core/PrintsControl.Application/PrintsControl.Application.csproj", "Core/PrintsControl.Application/"]
COPY ["Core/PrintsControl.Domain/PrintsControl.Domain.csproj", "Core/PrintsControl.Domain/"]
COPY ["Infrastructure/PrintsControl.Persistence/PrintsControl.Persistence.csproj", "Infrastructure/PrintsControl.Persistence/"]

RUN dotnet restore "Presentation/PrintsControl.WebApi/PrintsControl.WebApi.csproj"

COPY . .

WORKDIR /src/Presentation/PrintsControl.WebApi
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/data

ENV ConnectionStrings__DefaultConnection="Data Source=/app/data/printscontrol.db"

EXPOSE 5118

ENTRYPOINT ["dotnet", "PrintsControl.WebApi.dll"]
