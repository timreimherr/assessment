FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 63307
EXPOSE 44374

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Assessment/Assessment.csproj", "Assessment/"]
RUN dotnet restore "Assessment/Assessment.csproj"
COPY . .
WORKDIR "/src/Assessment"
RUN dotnet build "Assessment.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Assessment.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Assessment.dll"]