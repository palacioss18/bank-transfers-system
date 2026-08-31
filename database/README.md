# 📁 Módulo de Base de Datos (`/database`)

Este directorio contiene la definición del esquema relacional, scripts de datos iniciales y objetos de base de datos para el proyecto **Bank Transfers System** en **SQL Server (T-SQL)**.

---

## 🚀 Orden de Ejecución de Scripts

Para levantar la base de datos desde cero en tu entorno local (vía SQL Server Management Studio, Azure Data Studio o `sqlcmd`), ejecutá los archivos en el siguiente orden estricto:

| Orden | Archivo | Descripción |
| :---: | :--- | :--- |
| **1** | `01_tables.sql` | Crea la base de datos `BankTransfersDB`, sus tablas (`Clientes`, `Cuentas`, `Transferencias`) y aplica claves primarias, foráneas y restricciones (`CHECK`, `UNIQUE`). |
| **2** | `02_seed.sql` | Limpia registros previos, resetea secuencias `IDENTITY` e inserta datos iniciales de prueba (clientes, cuentas activas y una cuenta bloqueada para tests). |
| **3** | `03_procedures.sql` *(Próximamente)* | Contendrá los Stored Procedures para procesar transferencias atómicas con manejo de transacciones (`BEGIN TRAN`, `COMMIT`, `ROLLBACK`). |

---

## 📊 Entidades Creadas

* **`Clientes`**: Almacena datos personales e identificación única de los usuarios del banco.
* **`Cuentas`**: Almacena el número de cuenta, cliente asociado, saldo disponible y estado operativo (`Activa`, `Bloqueada`, `Inactiva`). Incluye restricción `CHECK (Saldo >= 0)`.
* **`Transferencias`**: Registra el historial de movimientos financieros entre dos cuentas (monto, fecha, estado y observaciones). Impide transferencias a la misma cuenta de origen.

---

## 🛠️ Ejecución rápida por consola (opcional)

Si utilizás la herramienta `sqlcmd` de SQL Server:

```bash
sqlcmd -S localhost -i 01_tables.sql
sqlcmd -S localhost -i 02_seed.sql
