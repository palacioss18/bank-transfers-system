# bank-transfers-system

> Bank transfer management system developed with C# and SQL Server, applying OOP, transactions, validations, and relational design.

---

## 🎯 Objetivo del Proyecto

Diseñar e implementar un motor de transferencias bancarias seguro, atómico y escalable, garantizando la consistencia financiera mediante transacciones en SQL Server y reglas de negocio orientadas a objetos en C#.

---

## 📌 Características Principales

* **Procesamiento Atómico de Transferencias:** Garantía de integridad ACID en cada débito/crédito utilizando `SqlTransaction` y bloques de control en SQL Server.
* **Gestión de Cuentas y Clientes:** Administración del estado operacional de cuentas (Activa, Bloqueada, Inactiva) y saldos asociados.
* **Validaciones de Negocio Exhaustivas:** Control de saldo disponible, validación de estado activo en origen/destino y prevención de auto-transferencias.
* **Registro Histórico y Auditoría:** Trazabilidad completa de operaciones con estados de transacción (`Exitosa`, `Fallida`, `Rechazada`).

---

## 📐 Estructura del Repositorio

```text
bank-transfers-system/
├── 📁 database/   # Scripts T-SQL (Tablas, Stored Procedures, Triggers, Seeds)
├── 📁 docs/       # Diagramas Entidad-Relación (DER), arquitectura y especificaciones
├── 📁 src/        # Solución en C# / .NET (Modelos, Servicios, Repositorios)
├── 📄 .gitignore  # Archivos ignorados por Git
└── 📄 README.md   # Documentación principal del proyecto
