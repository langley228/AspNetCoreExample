# AspNetCoreExample

這是一個 ASP.NET Core 範例專案，展示基本的 Web API 架構與常見功能實作。

## 專案結構

- `Controllers/`：API 控制器
- `Models/`：資料模型與資料庫內容
- `Repositories/`：資料存取層
- `Services/`：商業邏輯層
- `Exceptions/`：自訂例外
- `Extensions/`：擴充方法
- `Migrations/`：Entity Framework Core 資料庫遷移

## 快速開始

1. 安裝 .NET 8 SDK
2. 還原套件
   ```sh
   dotnet restore
   ```
3. 執行資料庫遷移
   ```sh
   dotnet ef database update
   ```
4. 啟動專案
   ```sh
   dotnet run --project AspNetCoreExample/AspNetCoreExample.csproj
   ```

## API 測試

啟動後可透過 Swagger UI 或 Postman 測試 API 端點。

## 範例 API 端點

| 方法   | 路徑                | 說明         |
|--------|---------------------|--------------|
| GET    | /api/user           | 取得所有使用者 |
| GET    | /api/user/{id}      | 取得單一使用者 |
| POST   | /api/user           | 新增使用者     |
| PUT    | /api/user/{id}      | 更新使用者     |
| DELETE | /api/user/{id}      | 刪除使用者     |

> 實際端點請依 Controllers 內容為主，啟動後可於 Swagger UI 查看完整 API 文件。

## 設定檔

- `appsettings.json`：一般設定
- `appsettings.Development.json`：開發環境設定

## 參考資源

- [ASP.NET Core 官方文件](https://learn.microsoft.com/aspnet/core)
- [Entity Framework Core 文件](https://learn.microsoft.com/ef/core)
- [Swagger UI](https://swagger.io/tools/swagger-ui/)