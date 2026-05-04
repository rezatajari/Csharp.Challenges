FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src


COPY ["UI/UI.csproj", "UI/"]
RUN dotnet restore "UI/UI.csproj"


COPY . .
RUN dotnet publish "UI/UI.csproj" -c Release -o /app/publish


FROM docker.arvancloud.ir/nginx:alpine
WORKDIR /usr/share/nginx/html


COPY --from=build /app/publish/wwwroot .


COPY UI/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80