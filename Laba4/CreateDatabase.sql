-- Скрипт создания базы данных MarketingDB
-- Выполните этот скрипт в SQL Server Management Studio (SSMS)

USE master;
GO

-- Создание базы данных
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MarketingDB')
BEGIN
    CREATE DATABASE MarketingDB;
END
GO

USE MarketingDB;
GO

-- Создание таблицы Clients
IF OBJECT_ID('Clients', 'U') IS NULL
BEGIN
    CREATE TABLE Clients (
        Id_Клиента INT PRIMARY KEY IDENTITY(1,1),
        Фио NVARCHAR(255) NOT NULL,
        email NVARCHAR(255),
        Телефон NVARCHAR(20),
        адрес NVARCHAR(500)
    );
    PRINT 'Таблица Clients создана';
END
ELSE
    PRINT 'Таблица Clients уже существует';
GO

-- Создание таблицы Employees
IF OBJECT_ID('Employees', 'U') IS NULL
BEGIN
    CREATE TABLE Employees (
        ID_сотрудника INT PRIMARY KEY IDENTITY(1,1),
        ФИО NVARCHAR(255) NOT NULL,
        Должность NVARCHAR(100),
        email NVARCHAR(255),
        Ставка_в_час DECIMAL(10,2)
    );
    PRINT 'Таблица Employees создана';
END
ELSE
    PRINT 'Таблица Employees уже существует';
GO

-- Создание таблицы Campaigns
IF OBJECT_ID('Campaigns', 'U') IS NULL
BEGIN
    CREATE TABLE Campaigns (
        id_кампании INT PRIMARY KEY IDENTITY(1,1),
        название NVARCHAR(255) NOT NULL,
        id_клиента INT NOT NULL,
        бюджет DECIMAL(15,2),
        дата_начала DATE,
        дата_окончания DATE,
        статус NVARCHAR(50),
        CONSTRAINT FK_Campaigns_Clients FOREIGN KEY (id_клиента)
            REFERENCES Clients(Id_Клиента)
    );
    PRINT 'Таблица Campaigns создана';
END
ELSE
    PRINT 'Таблица Campaigns уже существует';
GO

-- Заполнение тестовыми данными
PRINT 'Заполнение тестовыми данными...';

-- Добавление клиентов
IF NOT EXISTS (SELECT 1 FROM Clients)
BEGIN
    INSERT INTO Clients (Фио, email, Телефон, адрес) VALUES
    ('ООО "Ромашка"', 'info@romashka.ru', '+7 (495) 123-45-67', 'г. Москва, ул. Ленина, д. 1'),
    ('ИП Иванов А.А.', 'ivanov@mail.ru', '+7 (812) 234-56-78', 'г. Санкт-Петербург, пр. Невский, д. 10'),
    ('ЗАО "ТехноСтар"', 'contact@technostar.ru', '+7 (383) 345-67-89', 'г. Новосибирск, ул. Кирова, д. 25'),
    ('ООО "Вектор"', 'vector@yandex.ru', '+7 (343) 456-78-90', 'г. Екатеринбург, ул. Малышева, д. 50'),
    ('ООО "Прогресс"', 'progress@gmail.com', '+7 (846) 567-89-01', 'г. Самара, ул. Молодогвардейская, д. 100');
    PRINT 'Добавлено 5 клиентов';
END

-- Добавление сотрудников
IF NOT EXISTS (SELECT 1 FROM Employees)
BEGIN
    INSERT INTO Employees (ФИО, Должность, email, Ставка_в_час) VALUES
    ('Петров Сергей Иванович', 'Менеджер проектов', 'petrov@company.ru', 500.00),
    ('Сидорова Анна Михайловна', 'Маркетолог', 'sidorova@company.ru', 450.00),
    ('Козлов Дмитрий Александрович', 'Дизайнер', 'kozlov@company.ru', 400.00),
    ('Новикова Елена Владимировна', 'Аналитик', 'novikova@company.ru', 480.00),
    ('Федоров Максим Олегович', 'Разработчик', 'fedorov@company.ru', 600.00);
    PRINT 'Добавлено 5 сотрудников';
END

-- Добавление кампаний
IF NOT EXISTS (SELECT 1 FROM Campaigns)
BEGIN
    INSERT INTO Campaigns (название, id_клиента, бюджет, дата_начала, дата_окончания, статус) VALUES
    ('Новогодняя реклама', 1, 150000.00, '2024-12-01', '2024-12-31', 'Активна'),
    ('Продвижение в соцсетях', 2, 80000.00, '2024-11-15', '2025-02-15', 'Активна'),
    ('Контекстная реклама', 3, 120000.00, '2024-10-01', '2024-12-31', 'Завершена'),
    ('Email рассылка', 4, 50000.00, '2025-01-10', '2025-03-10', 'Планируется'),
    ('SEO оптимизация', 5, 200000.00, '2024-09-01', '2025-08-31', 'Активна');
    PRINT 'Добавлено 5 кампаний';
END

PRINT 'База данных успешно настроена!';
GO

-- Проверка созданных таблиц
SELECT 'Clients' as TableName, COUNT(*) as RecordCount FROM Clients
UNION ALL
SELECT 'Employees', COUNT(*) FROM Employees
UNION ALL
SELECT 'Campaigns', COUNT(*) FROM Campaigns;
GO
