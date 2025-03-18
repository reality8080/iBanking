# iBanking
Các lớp tương tác với nhau trong ngân hàng
Customer - Thông tin khách hàng
Bank Account - Tài khoản ngân hàng
Bank Card - Thẻ ngân hàng
Loans - Khoản vay
Transaction History - Lịch sử giao dịch
UserAuth - Xác thực người dùng
Các folder cần có
Data: Thao tác với DbContext để thực thi các 
lệnh liên quan và ánh xạ lên database
Interface: định nghĩa các thao tác hành vi 
liên quan đến từng đối tượng
Migration: Giúp quản lý phiên bản cơ sở dữ 
liệu bằng các tạo, thay đổi và cập nhật các 
cấu trúc của database dựa trên model và 
DBcontext
Models: Xây dựng các class có liên quan đến 
nhau và giúp tạo Database
Repositories: Thực hiện các thao tác liên 
quan đến database được định nghĩa trước bởi 
interface(Chỉ thực hiện CRUD, Create, Read,
Update, Delete)
Services: Thực hiện thao tác liên quan đến
Business Logic(tính toán, chạy các thao tác 
lấy,...) và gọi Repository lấy dữ liệu và thực hiện 
tác vụ lưu dữ liệu, giúp UI có dữ liệu để hiển
thị và thực hiện tác vụ
Những thứ cần làm:
DTOs (Data Transfer Objects): Dùng AutoMapper
Utils (Helper Functions & Constants): Mã hóa dùng FireBase Authentication, JWT
Logging (Ghi log hệ thống):
Configuration (Cấu hình hệ thống):
Authentication
Authorization

/iBanking
│── Data/                  → DbContext, thao tác database  
│── Models/                → Định nghĩa các entity  
│── Migrations/            → Quản lý phiên bản DB (EF Core)  
│── Interfaces/            → Định nghĩa hợp đồng (contract) cho repository & service  
│── Repositories/          → Thực hiện CRUD database  
│── Services/              → Xử lý logic nghiệp vụ, gọi repository  
│── DTOs/                  → Định nghĩa các lớp trung gian giữa Model & View  
│── Utils/                 → Chứa helper, constants, mã hóa JWT, Firebase  
│── Logging/               → Quản lý ghi log  
│── Configuration/         → Cấu hình hệ thống (appsettings.json)  
│── Authentication/        → Xác thực (Firebase, JWT)  
│── Authorization/         → Phân quyền (Roles, Claims)  
│── UI (Windows Forms)/    → Giao diện người dùng  

# iBanking

## 🏦 Giới Thiệu
**iBanking** là một hệ thống ngân hàng điện tử giúp quản lý tài khoản, giao dịch, thẻ ngân hàng và khoản vay.  
Hệ thống sử dụng Windows Forms làm giao diện người dùng và tích hợp các công nghệ hiện đại như Firebase Authentication, JWT, Entity Framework Core.

## 📂 Cấu Trúc Dự Án

/iBanking │── Data/ → DbContext, thao tác database
│── Models/ → Định nghĩa các entity
│── Migrations/ → Quản lý phiên bản DB (EF Core)
│── Interfaces/ → Định nghĩa hợp đồng (contract) cho repository & service
│── Repositories/ → Thực hiện CRUD database
│── Services/ → Xử lý logic nghiệp vụ, gọi repository
│── DTOs/ → Định nghĩa các lớp trung gian giữa Model & View
│── Utils/ → Chứa helper, constants, mã hóa JWT, Firebase
│── Logging/ → Quản lý ghi log
│── Configuration/ → Cấu hình hệ thống (appsettings.json)
│── Authentication/ → Xác thực (Firebase, JWT)
│── Authorization/ → Phân quyền (Roles, Claims)
│── UI (Windows Forms)/ → Giao diện người dùng


## 🛠️ Các Thành Phần Chính
### 1️⃣ **Các Lớp Chức Năng**
- **Customer** - Quản lý thông tin khách hàng.
- **Bank Account** - Quản lý tài khoản ngân hàng.
- **Bank Card** - Quản lý thẻ ngân hàng.
- **Loans** - Quản lý khoản vay.
- **Transaction History** - Lịch sử giao dịch.
- **UserAuth** - Xác thực người dùng.

### 2️⃣ **Thư Mục Chức Năng**
- **Data** - Xử lý DbContext, ánh xạ và thực thi lệnh liên quan đến database.
- **Models** - Định nghĩa các entity, tạo database.
- **Migrations** - Quản lý phiên bản database với Entity Framework Core.
- **Interfaces** - Định nghĩa hợp đồng cho Repository và Service.
- **Repositories** - Thực hiện các thao tác CRUD trên database.
- **Services** - Xử lý nghiệp vụ, gọi Repository để lấy và lưu dữ liệu.
- **DTOs** - Định nghĩa các lớp trung gian giữa Model và View, sử dụng AutoMapper.
- **Utils** - Chứa các hàm tiện ích (Helper Functions, Constants), mã hóa JWT, Firebase.
- **Logging** - Quản lý ghi log hệ thống.
- **Configuration** - Cấu hình hệ thống (appsettings.json, environment variables).
- **Authentication** - Xác thực người dùng (Firebase Authentication, JWT).
- **Authorization** - Phân quyền dựa trên Roles và Claims.
- **UI (Windows Forms)** - Giao diện người dùng trên Windows Forms.

## 🚀 Công Nghệ Sử Dụng
- **C# (.NET, WinForms)** - Ngôn ngữ chính.
- **Entity Framework Core** - ORM quản lý database.
- **SQL Server** - Cơ sở dữ liệu.
- **Firebase Authentication** - Xác thực người dùng.
- **JWT (JSON Web Token)** - Quản lý phiên làm việc.
- **AutoMapper** - Hỗ trợ chuyển đổi dữ liệu giữa Model và DTO.

## 📥 Cài Đặt
