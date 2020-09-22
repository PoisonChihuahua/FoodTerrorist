# FoodTerrorist

# API
## 食事
http://localhost:5000/api/Food

## ユーザー
http://localhost:5000/api/User

# 環境変数の設定
env ASPNETCORE_ENVIRONMENT="Development" dotnet watch run

# DBマイグレーション
dotnet ef enable-migrations -v
dotnet ef migrations add InitialCreate
dotnet ef database update

# パッケージインストール
dotnet add package Microsoft.AspNetCore.SpaServices.Extensions
dotnet add package Nyami.AspNetCore.VueCliServices