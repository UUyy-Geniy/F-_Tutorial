# Используем официальный образ SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Копируем файлы проекта и устанавливаем зависимости
COPY *.fsproj ./
RUN dotnet restore

# Копируем остальные файлы и собираем проект
COPY . ./
RUN dotnet publish -c Release -o out

# Используем официальный образ Runtime для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Указываем команду для запуска приложения
ENTRYPOINT ["dotnet", "FirstIonideProject~.dll"]
