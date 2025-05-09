
# 💼 Wallet API

## 📚 Visão Geral

A **Wallet API** é uma aplicação em C# com PostgreSQL que permite:

- Gerenciar pessoas (cadastro, login, saldo).
- Realizar transferências entre contas.
- Consultar histórico de transferências com filtros.

## 🛠️ Tecnologias Utilizadas

- .NET 8 (recomendado)
- PostgreSQL
- Dapper
- UUID como chave primária

## 🧱 Banco de Dados

### 📌 Criação do Banco

```sql
CREATE DATABASE "WalletDataBase";
```

### 🔗 Conexão

- **Porta padrão**: `5432`
- **Connection string exemplo**:

```csharp
Host=localhost;Port=5432;Database=WalletDataBase;Username=postgres;Password=SuaSenha
```

## 📂 Estrutura das Entidades

### 👤 `PersonEntity`

| Campo               | Tipo        | Observação           |
|--------------------|-------------|----------------------|
| `Id`               | `Guid`      | PK                   |
| `Name`             | `string`    |                      |
| `Document`         | `string`    |                      |
| `BirthDate`        | `DateTime`  |                      |
| `Email`            | `string`    | usado para login     |
| `Password`         | `string`    | usado para login     |
| `Activated`        | `bool`      |                      |
| `Role`             | `string`    |                      |
| `RegistrationDate` | `DateTime`  |                      |
| `AccountBalance`   | `decimal`   | saldo da pessoa      |

### 💸 `MoneyTransferEntity`

| Campo                   | Tipo      | Observação                          |
|------------------------|-----------|-------------------------------------|
| `Id`                   | `Guid`    | PK                                  |
| `OriginPersonId`       | `Guid`    | FK para `PersonEntity.Id`           |
| `DestinationPersonId`  | `Guid`    | FK para `PersonEntity.Id`           |
| `TransferAmount`       | `decimal` | valor da transferência              |
| `TransferDate`         | `DateTime`|                                     |

## ✅ Funcionalidades Implementadas

### 👥 Pessoas

- Criar pessoa
- Login com email + senha
- Consultar saldo por ID
- Atualizar saldo

### 🔁 Transferências

- Criar transferência entre pessoas
- Consultar transferências por:
  - `OriginPersonId`
  - `OriginPersonId` + `TransferDate`
  - `OriginPersonId` entre datas (`startDate`, `endDate`)
