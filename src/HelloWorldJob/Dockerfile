# Image used when running the application
FROM mcr.microsoft.com/dotnet/runtime:5.0-alpine AS base
WORKDIR /app

# Image used for building application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# Copy csproj and nuget.config to enable NuGet restore
COPY ["src/HelloWorldJob/HelloWorldJob.csproj", "HelloWorldJob/"]
COPY nuget.config .
RUN dotnet restore "HelloWorldJob/HelloWorldJob.csproj"
# Copy the source code
COPY "src/HelloWorldJob" "src/HelloWorldJob"
WORKDIR "src/HelloWorldJob"

FROM build AS publish
# Version is passed during docker build with --build-arg VERSION="${VERSION}"
ARG VERSION="1.0.0"
# Publish runtime linux-x64
RUN dotnet publish "HelloWorldJob.csproj" -c Release /p:Version="${VERSION}" --runtime linux-musl-x64 --no-self-contained -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
# Copy published application into final image
COPY --from=publish /app/publish .
# Execute assembly when container is run
ENTRYPOINT ["./HelloWorldJob"]