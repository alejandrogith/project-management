FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS builder

WORKDIR /src

COPY ./src ./

WORKDIR /src/ProjectManagement.WebApi
RUN dotnet publish "ProjectManagement.WebApi.csproj"  -c Release -o /publish \
    --runtime alpine-x64 \
    --self-contained true \
    /p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as final

WORKDIR /app
COPY --from=builder /publish .

RUN apk add --no-cache icu-libs

EXPOSE 80
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
CMD ["./ProjectManagement.WebApi"]


