# --- Alpine configuration stage ---
FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app

# Add a user, switch to it, give access to the app dir
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /sauce

COPY . ./

RUN ls -laR

FROM build AS publish
RUN dotnet publish "AdminPanel/AdminPanel.csproj"  -c Release -o /app/publish -r alpine-x64 --self-contained true -p:PublishSingleFile=true

# --- Serve stage ---
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./AdminPanel"]
