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

## 範例 API 端點與 API 規格

| 方法   | 路徑                | 說明         |
|--------|---------------------|--------------|
| GET    | /api/user           | 取得所有使用者（支援分頁、排序） |
| GET    | /api/user/{id}      | 取得單一使用者 |
| POST   | /api/user           | 新增使用者     |
| PUT    | /api/user/{id}      | 更新使用者     |
| DELETE | /api/user/{id}      | 刪除使用者     |

### 取得分頁使用者清單
- **GET** `/api/user`
- **查詢參數**：
  - `page`：頁碼（預設 1）
  - `pageSize`：每頁筆數（預設 10）
  - `sortBy`：排序欄位（如 Name、Email）
  - `desc`：是否倒序（true/false）
- **回應**：`PagedResult<UserViewModel>`

### 取得單一使用者
- **GET** `/api/user/{id}`
- **路徑參數**：
  - `id`：使用者 Id
- **回應**：`UserViewModel`，找不到時回傳 404

### 新增使用者
- **POST** `/api/user`
- **Body**：
  ```json
  {
    "name": "string",
    "email": "string"
  }
  ```
- **回應**：`UserViewModel`（含 Id），201 Created

### 更新使用者
- **PUT** `/api/user/{id}`
- **路徑參數**：
  - `id`：使用者 Id
- **Body**：
  ```json
  {
    "id": 1,
    "name": "string",
    "email": "string"
  }
  ```
- **回應**：200 OK，找不到時回傳 404

### 刪除使用者
- **DELETE** `/api/user/{id}`
- **路徑參數**：
  - `id`：使用者 Id
- **回應**：200 OK，找不到時回傳 404

> 詳細欄位與回應格式請參考 Swagger UI。

## 設定檔

- `appsettings.json`：一般設定
- `appsettings.Development.json`：開發環境設定

## 參考資源

- [ASP.NET Core 官方文件](https://learn.microsoft.com/aspnet/core)
- [Entity Framework Core 文件](https://learn.microsoft.com/ef/core)
- [Swagger UI](https://swagger.io/tools/swagger-ui/)