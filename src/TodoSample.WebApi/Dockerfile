#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TodoSample.WebApi/TodoSample.WebApi.csproj", "src/TodoSample.WebApi/"]
COPY ["src/TodoSample.ApplicationCore/TodoSample.ApplicationCore.csproj", "src/TodoSample.ApplicationCore/"]
COPY ["src/TodoSample.DIContainer/TodoSample.DIContainer.csproj", "src/TodoSample.DIContainer/"]
COPY ["src/TodoSample.Infrastructure/TodoSample.Infrastructure.csproj", "src/TodoSample.Infrastructure/"]
RUN dotnet restore "src/TodoSample.WebApi/TodoSample.WebApi.csproj"
COPY . .
WORKDIR "/src/src/TodoSample.WebApi"
RUN dotnet build "TodoSample.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoSample.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoSample.WebApi.dll"]