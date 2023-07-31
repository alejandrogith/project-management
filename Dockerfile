FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS builder

WORKDIR /src

COPY ./src ./

WORKDIR /src/ProjectManagement.WebApi
RUN dotnet publish "ProjectManagement.WebApi.csproj"  -c Release -o /publish \
    --runtime alpine-x64 \
    --self-contained true \
    /p:PublishTrimmed=true \
    /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as final

WORKDIR /app
COPY --from=builder /publish .
EXPOSE 80

CMD ["./ProjectManagement.WebApi"]


