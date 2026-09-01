# Bank Transfers System

> A modular, multi-layer bank transfer management system developed with **C# (.NET 10)** and **SQL Server**, applying **Clean Architecture**, ACID-compliant transactions, and robust OOP business validations.

---

## 🇪🇸 Español

### 🎯 Objetivo del Proyecto
Diseñar e implementar un motor de transferencias bancarias seguro, atómico y escalable, garantizando la consistencia financiera mediante transacciones explícitas con ADO.NET (`SqlTransaction`) y encapsulamiento de reglas de negocio en la capa de Dominio.

### 📌 Características Principales
* **Clean Architecture en 3 Capas:** Separación clara entre Dominio (`BankTransfers.Domain`), Infraestructura (`BankTransfers.Infrastructure`) y Aplicación (`BankTransfers.App`).
* **Procesamiento Atómico (ACID):** Garantía de integridad en operaciones débito/crédito utilizando `SqlTransaction` con `Commit` y `Rollback` automático ante fallas.
* **Modelo de Dominio Rico:** Entidades encapsuladas (`Cuenta`, `Cliente`, `Transferencia`) que previenen estados inválidos y validan operaciones (monto positivo, saldo suficiente, cuenta activa).
* **Persistencia con ADO.NET:** Mapeo de datos manual eficiente mediante `Microsoft.Data.SqlClient` utilizando el patrón Repository.
* **Trazabilidad y Auditoría:** Histórico de transferencias registrado en base de datos con timestamps y observaciones de la operación.

### 📐 Estructura de la Solución
```text
bank-transfers-system/
├── 📁 src/
│   ├── 📁 BankTransfers.Domain/          # Entidades y lógica de negocio pura
│   │   └── 📁 entities/                  # Cliente, Cuenta, Transferencia
│   ├── 📁 BankTransfers.Infrastructure/  # Persistencia y acceso a datos
│   │   ├── 📁 Data/                      # Conexión a SQL Server
│   │   ├── 📁 Repositories/              # ADO.NET Repositories
│   │   └── 📁 Services/                  # TransferenciaService (Coordinación ACID)
│   └── 📁 BankTransfers.App/             # Consola interactiva CLI
├── 📁 database/                          # Scripts T-SQL (Creación de tablas e inserts)
├── 📄 .gitignore                         # Archivos ignorados por Git
└── 📄 README.md                          # Documentación del proyecto
