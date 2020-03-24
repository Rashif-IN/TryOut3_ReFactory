FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-payment
WORKDIR /app


COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet

WORKDIR /app
COPY --from=build-payment /app/out .
ENTRYPOINT ["dotnet", "payment_handler.dll"]
