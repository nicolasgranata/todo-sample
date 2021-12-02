#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TodoSample.WebApi/TodoSample.WebApi.csproj", "src/TodoSample.WebApi/"]
COPY ["src/TodoSample.Application/TodoSample.Application.csproj", "src/TodoSample.Application/"]
COPY ["src/TodoSample.Domain/TodoSample.Domain.csproj", "src/TodoSample.Domain/"]
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