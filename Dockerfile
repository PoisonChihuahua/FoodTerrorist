# .NET Core 3.1 をベースイメージとする
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
# 作業ディレクリの指定
WORKDIR /app

COPY . .