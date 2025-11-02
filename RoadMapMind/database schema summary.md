```sql
-- Database: LibraryApp

CREATE TABLE Author (
    AuthorId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    About NVARCHAR(MAX),
    CreateAt DATETIME2 NOT NULL,
    Country NVARCHAR(100)
);

CREATE TABLE Book (
    BookId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    AuthorId INT NOT NULL,         -- may later be removed; BookAuthor will handle authorship
    CreatedAt DATETIME2 NOT NULL,
    Description NVARCHAR(MAX),
    PublishedYear INT
);

CREATE TABLE BookAuthor (
    BookId INT NOT NULL,
    AuthorId INT NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Book(BookId),
    FOREIGN KEY (AuthorId) REFERENCES Author(AuthorId),
    PRIMARY KEY (BookId, AuthorId)
);
```

---

### Small reflection:

* You’ve now modeled **Books**, **Authors**, and their **many-to-many relationship**.
* The next natural design step (conceptually) will be to connect these to **Users** — since you said each user has their own dashboard and saved books.

Would you like to think next about **how to represent a User’s personal library** (so each user can save or track their own books)?
