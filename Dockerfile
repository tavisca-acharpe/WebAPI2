FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY WebApplication2/Publish/. ./
EXPOSE 80
ENTRYPOINT ["dotnet", "WebApi.dll"]
