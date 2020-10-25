# FoodTerrorist

# API
## 食事
http://localhost:5000/api/Food

## ユーザー
http://localhost:5000/api/UserRegist

# 環境変数の設定
env ASPNETCORE_ENVIRONMENT="Development" dotnet watch run

# DBマイグレーション
dotnet ef enable-migrations -v
dotnet ef migrations add InitialCreate
dotnet ef database update

# パッケージインストール
dotnet add package Microsoft.AspNetCore.SpaServices.Extensions
dotnet add package Nyami.AspNetCore.VueCliServices
dotnet add package Xunit

# フロントエンド実行
npm run watch

# 単体テスト実行
dotnet test -l "console;verbosity=detailed"