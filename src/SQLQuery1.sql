CREATE TABLE Cuentas (
    IdCuenta INT IDENTITY(1,1) PRIMARY KEY,
    NumeroCuenta VARCHAR(20) NOT NULL,
    IdCliente INT NOT NULL,
    Saldo DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activa',
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Transferencias (
    IdTransferencia INT IDENTITY(1,1) PRIMARY KEY,
    IdCuentaOrigen INT NOT NULL,
    IdCuentaDestino INT NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Estado VARCHAR(20) NOT NULL,
    Observaciones VARCHAR(255) NULL,
    FOREIGN KEY (IdCuentaOrigen) REFERENCES Cuentas(IdCuenta),
    FOREIGN KEY (IdCuentaDestino) REFERENCES Cuentas(IdCuenta)
);

INSERT INTO Cuentas (NumeroCuenta, IdCliente, Saldo, Estado) 
VALUES ('CTA-1001', 1, 15000.00, 'Activa'),
       ('CTA-1002', 1, 5000.00, 'Activa'),
       ('CTA-1003', 2, 20000.00, 'Activa');