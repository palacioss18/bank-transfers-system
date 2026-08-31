USE BankTransfersDB;
GO

-- Limpiar datos previos si existen
DELETE FROM Transferencias;
DELETE FROM Cuentas;
DELETE FROM Clientes;

-- Resetear contadores Identity
DBCC CHECKIDENT ('Clientes', RESEED, 0);
DBCC CHECKIDENT ('Cuentas', RESEED, 0);
DBCC CHECKIDENT ('Transferencias', RESEED, 0);

-- Insertar Clientes
INSERT INTO Clientes (Nombre, Apellido, Documento, Email)
VALUES 
('Juan', 'Pérez', '30111222', 'juan.perez@email.com'),
('María', 'Gómez', '35333444', 'maria.gomez@email.com'),
('Carlos', 'López', '40555666', 'carlos.lopez@email.com');

-- Insertar Cuentas (Asociadas a los Clientes)
INSERT INTO Cuentas (NumeroCuenta, IdCliente, Saldo, Estado)
VALUES 
('CTA-1001-01', 1, 150000.00, 'Activa'),  -- Cuenta Juan
('CTA-1002-01', 2, 85000.50, 'Activa'),   -- Cuenta María
('CTA-1003-01', 3, 0.00, 'Bloqueada');    -- Cuenta Carlos (Para testear rechazo de transferencias)
GO