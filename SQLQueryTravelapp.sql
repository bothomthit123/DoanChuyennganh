CREATE DATABASE SmartTravelApp;
GO
USE SmartTravelApp;
GO

-- Bảng tài khoản (gồm cả người dùng và admin)
CREATE TABLE Accounts (
    account_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) UNIQUE NOT NULL,
    password NVARCHAR(255) NOT NULL,
    email NVARCHAR(100) UNIQUE NOT NULL,
    full_name NVARCHAR(100),
    is_admin BIT DEFAULT 0,  -- 0: Người dùng, 1: Quản trị viên
    created_at DATETIME DEFAULT GETDATE()
);

-- Bảng địa điểm du lịch
CREATE TABLE Places (
    place_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    address NVARCHAR(255),
    latitude FLOAT,
    longitude FLOAT,
    category NVARCHAR(50),  -- Ví dụ: Nhà hàng, Khách sạn, Danh lam thắng cảnh
    description NVARCHAR(MAX),
    rating FLOAT CHECK (rating BETWEEN 0 AND 5),
    created_at DATETIME DEFAULT GETDATE()
);

-- Bảng lưu địa điểm yêu thích
CREATE TABLE Favorites (
    favorite_id INT IDENTITY(1,1) PRIMARY KEY,
    account_id INT NOT NULL,
    place_id INT NOT NULL,
    saved_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE,
    FOREIGN KEY (place_id) REFERENCES Places(place_id) ON DELETE CASCADE
);

-- Bảng lưu lịch sử tìm kiếm
CREATE TABLE SearchHistory (
    search_id INT IDENTITY(1,1) PRIMARY KEY,
    account_id INT NOT NULL,
    search_query NVARCHAR(255),
    searched_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (account_id) REFERENCES Accounts(account_id) ON DELETE CASCADE
);
