# 📚 LibraryApp Database Schema

This schema models a **book library system** with a many-to-many relationship between **Books** and **Authors**.
Each book can have multiple authors, and each author can write multiple books.

---

## 🧱 Tables

### **Author**

| Column      | Type                | Description                                     |
| ----------- | ------------------- | ----------------------------------------------- |
| `AuthorId`  | `INT IDENTITY(1,1)` | Primary key                                     |
| `Name`      | `NVARCHAR(100)`     | Author’s full name                              |
| `About`     | `NVARCHAR(MAX)`     | Optional biography or notes                     |
| `Country`   | `NVARCHAR(100)`     | Country of origin                               |
| `CreatedAt` | `DATETIME2`         | Record creation time (default: `SYSDATETIME()`) |

```sql
CREATE TABLE Author (
    AuthorId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    About NVARCHAR(MAX),
    Country NVARCHAR(100),
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
```

---

### **Book**

| Column          | Type                | Description                                     |
| --------------- | ------------------- | ----------------------------------------------- |
| `BookId`        | `INT IDENTITY(1,1)` | Primary key                                     |
| `Title`         | `NVARCHAR(100)`     | Title of the book                               |
| `Description`   | `NVARCHAR(MAX)`     | Summary or overview                             |
| `PublishedYear` | `INT`               | Year the book was published                     |
| `CreatedAt`     | `DATETIME2`         | Record creation time (default: `SYSDATETIME()`) |

```sql
CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    PublishedYear INT,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
```

---

### **BookAuthor**

| Column          | Type                   | Description                   |
| --------------- | ---------------------- | ----------------------------- |
| `BookId`        | `INT`                  | References `Book(BookId)`     |
| `AuthorId`      | `INT`                  | References `Author(AuthorId)` |
| **Primary Key** | (`BookId`, `AuthorId`) | Composite key linking both    |

```sql
CREATE TABLE BookAuthor (
    BookId INT NOT NULL,
    AuthorId INT NOT NULL,
    PRIMARY KEY (BookId, AuthorId),
    FOREIGN KEY (BookId) REFERENCES Book(BookId),
    FOREIGN KEY (AuthorId) REFERENCES Author(AuthorId)
);
```

---

## 🧪 Sample Data

### Insert Authors

```sql
INSERT INTO Author (Name, Country, CreatedAt)
VALUES
('James Clear', 'USA', SYSDATETIME()),
('Stephen R. Covey', 'USA', SYSDATETIME()),
('Robin Sharma', 'Canada', SYSDATETIME()),
('Carol S. Dweck', 'USA', SYSDATETIME()),
('Mark Manson', 'USA', SYSDATETIME());
```

### Insert Books

```sql
INSERT INTO Book (Title, Description, PublishedYear, CreatedAt)
VALUES
('Atomic Habits', 'A guide to building good habits and breaking bad ones.', 2018, SYSDATETIME()),
('The 7 Habits of Highly Effective People', 'A classic on personal and professional effectiveness.', 1989, SYSDATETIME()),
('The Monk Who Sold His Ferrari', 'A fable about fulfilling your dreams and reaching your destiny.', 1997, SYSDATETIME()),
('Mindset: The New Psychology of Success', 'Explores how mindset influences success and achievement.', 2006, SYSDATETIME()),
('The Subtle Art of Not Giving a F*ck', 'A counterintuitive approach to living a good life.', 2016, SYSDATETIME());
```

### Link Books ↔ Authors

```sql
INSERT INTO BookAuthor (BookId, AuthorId)
VALUES
(1, 1),  -- Atomic Habits → James Clear
(2, 2),  -- 7 Habits → Stephen Covey
(3, 3),  -- The Monk Who Sold His Ferrari → Robin Sharma
(4, 4),  -- Mindset → Carol Dweck
(5, 5);  -- The Subtle Art → Mark Manson
```


