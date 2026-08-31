-- Crear base de datos (opcional si ya la creaste en SSMS)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BankTransfersDB')
BEGIN
    CREATE DATABASE BankTransfersDB;
END
GO

USE BankTransfersDB;
GO

-- 1. Tabla Clientes
CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Documento VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(100) NOT NULL UNIQUE,
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- 2. Tabla Cuentas
CREATE TABLE Cuentas (
    IdCuenta INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCuenta VARCHAR(20) NOT NULL UNIQUE,
    IdCliente INT NOT NULL,
    Saldo DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activa', -- 'Activa', 'Bloqueada', 'Inactiva'
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Cuentas_Clientes FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    CONSTRAINT CHK_Saldo_Positivo CHECK (Saldo >= 0)
);

-- 3. Tabla Transferencias
CREATE TABLE Transferencias (
    IdTransferencia INT IDENTITY(1,1) PRIMARY KEY,
    IdCuentaOrigen INT NOT NULL,
    IdCuentaDestino INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Estado VARCHAR(20) NOT NULL DEFAULT 'Completada', -- 'Completada', 'Fallida', 'Rechazada'
    Observaciones VARCHAR(255) NULL,
    CONSTRAINT FK_Transferencias_Origen FOREIGN KEY (IdCuentaOrigen) REFERENCES Cuentas(IdCuenta),
    CONSTRAINT FK_Transferencias_Destino FOREIGN KEY (IdCuentaDestino) REFERENCES Cuentas(IdCuenta),
    CONSTRAINT CHK_Monto_Positivo CHECK (Monto > 0),
    CONSTRAINT CHK_Cuentas_Diferentes CHECK (IdCuentaOrigen <> IdCuentaDestino)
);