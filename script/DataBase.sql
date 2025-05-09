CREATE DATABASE "WalletDataBase";
\c "WalletDataBase"

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE persons (
    id UUID PRIMARY KEY, 
    name TEXT,
    document TEXT UNIQUE,
    birth_date DATE,
    email TEXT,
    password TEXT,
    activated BOOLEAN,
    role TEXT,
    registration_date TIMESTAMP,
    account_balance DECIMAL
);

INSERT INTO persons (id, name, document, birth_date, email, password, activated, role, registration_date, account_balance)
VALUES 
('9f1d9c10-1a2b-4e0b-80bb-0d3c8f1b9c01', 'Alice Fernandes', '11111111111', '1990-05-10', 'alice@example.com', 'senha123', true, 'admin', '2023-01-01 08:30:00', 1500.75),
('bb23af6d-2e3e-4b00-9123-4472a8df927a', 'Bruno Costa', '22222222222', '1985-03-22', 'bruno@example.com', '123bruno', true, 'user', '2023-03-15 12:00:00', 820.50),
('c8892f04-4c84-4d2f-a1dc-6c5fcfac0ef8', 'Carla Dias', '33333333333', '2000-09-17', 'carla@example.com', 'carla!pass', false, 'user', '2023-05-20 10:15:00', 0.00),
('e3d0d05e-d951-46ae-a644-5a9d56e2f3dc', 'Daniel Souza', '44444444444', '1995-12-01', 'daniel@example.com', 'daniel456', true, 'user', '2023-07-08 14:45:00', 230.10);

CREATE TABLE money_transfers (
    id UUID PRIMARY KEY,
    origin_person_id UUID NOT NULL REFERENCES persons(id),
    destination_person_id UUID NOT NULL REFERENCES persons(id),
    transfer_amount DECIMAL NOT NULL,
    transfer_date TIMESTAMP NOT NULL
);

INSERT INTO money_transfers (id, origin_person_id, destination_person_id, transfer_amount, transfer_date)
VALUES 
('1e5bb0c4-6bfa-4e49-bbc6-32e48eaf5e01', '9f1d9c10-1a2b-4e0b-80bb-0d3c8f1b9c01', 'bb23af6d-2e3e-4b00-9123-4472a8df927a', 250.00, '2025-05-01 10:00:00'),
('a9a27d31-f4cb-41d3-ae68-90b8261690e3', 'bb23af6d-2e3e-4b00-9123-4472a8df927a', 'c8892f04-4c84-4d2f-a1dc-6c5fcfac0ef8', 100.50, '2025-05-02 14:30:00'),
('b8ac65f3-028f-4906-981e-d4f9f9941252', '9f1d9c10-1a2b-4e0b-80bb-0d3c8f1b9c01', 'e3d0d05e-d951-46ae-a644-5a9d56e2f3dc', 75.00, '2025-05-03 09:15:00'),
('fda8a837-0fc2-4b01-8b7a-58e9fc1fc6f6', 'c8892f04-4c84-4d2f-a1dc-6c5fcfac0ef8', 'bb23af6d-2e3e-4b00-9123-4472a8df927a', 300.00, '2025-05-04 17:45:00');