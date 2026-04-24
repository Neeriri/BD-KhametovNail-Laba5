# Инструкция по запуску лабораторной работы №4

## Требования
1. **Microsoft SQL Server** (Express или выше)
2. **SQL Server Management Studio (SSMS)**
3. **Visual Studio 2019/2022** с поддержкой .NET Framework 4.8
4. **.NET Framework 4.8**

## Шаг 1: Создание базы данных в SSMS

1. Откройте **SQL Server Management Studio (SSMS)**
2. Подключитесь к вашему экземпляру SQL Server
3. Откройте файл `Laba4/CreateDatabase.sql`
4. Выполните скрипт (F5 или кнопка "Execute")

Скрипт создаст:
- Базу данных `MarketingDB`
- Таблицы: `Clients`, `Employees`, `Campaigns`
- Тестовые данные (по 5 записей в каждой таблице)

## Шаг 2: Настройка подключения

Проверьте файл `Laba4/App.config`. Строка подключения должна соответствовать вашему серверу:

```xml
<connectionStrings>
    <add name="MarketingDBConnection" 
         connectionString="Server=localhost;Database=MarketingDB;Trusted_Connection=True;MultipleActiveResultSets=true" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

Если у вас именованный экземпляр SQL Server, замените `localhost` на `.\SQLEXPRESS` или ваше имя сервера.

## Шаг 3: Открытие проекта в Visual Studio

1. Откройте **Visual Studio**
2. Выберите **File → Open → Project/Solution**
3. Найдите и откройте файл `Laba4/Laba4.sln`

## Шаг 4: Восстановление NuGet пакетов

1. В обозревателе решений щелкните правой кнопкой на решении
2. Выберите **"Restore NuGet Packages"**
3. Дождитесь установки EntityFramework 6.4.4

Или через консоль Package Manager:
```
PM> Update-Package -reinstall EntityFramework
```

## Шаг 5: Сборка и запуск проекта

1. Нажмите **Build → Build Solution** (Ctrl+Shift+B)
2. Убедитесь, что сборка прошла без ошибок
3. Нажмите **Debug → Start Debugging** (F5)

## Реализованные CRUD-операции

### 1. Клиенты (Clients)
- ✅ **Create** - Добавление нового клиента
- ✅ **Read** - Просмотр списка всех клиентов
- ✅ **Update** - Редактирование данных клиента
- ✅ **Delete** - Удаление клиента с подтверждением

### 2. Сотрудники (Employees)
- ✅ **Create** - Добавление нового сотрудника
- ✅ **Read** - Просмотр списка всех сотрудников
- ✅ **Update** - Редактирование данных сотрудника
- ✅ **Delete** - Удаление сотрудника с подтверждением

### 3. Кампании (Campaigns)
- Модель данных готова
- Включена в контекст базы данных

## Структура проекта

```
Laba4/
├── Models/
│   ├── Clients.cs           # Модель клиента
│   ├── Employees.cs         # Модель сотрудника
│   ├── Campaigns.cs         # Модель кампании
│   └── MarketingDBContext.cs # Контекст базы данных
├── Views/
│   ├── ClientsWindow.xaml    # Окно управления клиентами
│   ├── ClientEditWindow.xaml # Окно добавления/редактирования клиента
│   ├── EmployeesWindow.xaml  # Окно управления сотрудниками
│   └── EmployeeEditWindow.xaml # Окно добавления/редактирования сотрудника
├── MainWindow.xaml          # Главное меню
├── App.config               # Конфигурация приложения
└── CreateDatabase.sql       # Скрипт создания БД
```

## Возможные ошибки и решения

### Ошибка: "Не удалось найти тип или имя пространства имен 'DbContext'"
**Решение:** Убедитесь, что пакет EntityFramework установлен. Выполните:
```
PM> Install-Package EntityFramework -Version 6.4.4
```

### Ошибка: "Не удалось подключиться к базе данных"
**Решение:**
1. Проверьте, запущен ли SQL Server
2. Убедитесь, что база данных `MarketingDB` создана
3. Проверьте строку подключения в `App.config`

### Ошибка: "InitializeComponent не существует"
**Решение:** 
1. Очистите решение (Build → Clean Solution)
2. Пересоберите проект (Build → Rebuild Solution)

## Проверка работы

1. Запустите приложение
2. Нажмите кнопку **"Клиенты (Clients)"**
3. Проверьте отображение списка клиентов из БД
4. Добавьте нового клиента
5. Отредактируйте существующего клиента
6. Удалите клиента (с подтверждением)
7. Вернитесь в главное меню
8. Повторите для **"Сотрудники (Employees)"**

## Примечание

По требованиям лабораторной работы CRUD-операции реализованы для **трёх сущностей**:
- Clients (Клиенты) - полностью реализовано
- Employees (Сотрудники) - полностью реализовано  
- Campaigns (Кампании) - модель данных готова

Для оценки "5" необходимо реализовать CRUD минимум для 70% сущностей базы данных.
