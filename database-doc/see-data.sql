INSERT INTO Author (Name, Country, CreatedAt)
VALUES
('James Clear', 'USA', SYSDATETIME()),
('Stephen R. Covey', 'USA', SYSDATETIME()),
('Robin Sharma', 'Canada', SYSDATETIME()),
('Carol S. Dweck', 'USA', SYSDATETIME()),
('Mark Manson', 'USA', SYSDATETIME());

INSERT INTO Book (Title, Description, PublishedYear, CreatedAt)
VALUES
('Atomic Habits', 'A guide to building good habits and breaking bad ones.', 2018, SYSDATETIME()),
('The 7 Habits of Highly Effective People', 'A classic on personal and professional effectiveness.', 1989, SYSDATETIME()),
('The Monk Who Sold His Ferrari', 'A fable about fulfilling your dreams and reaching your destiny.', 1997, SYSDATETIME()),
('Mindset: The New Psychology of Success', 'Explores how mindset influences success and achievement.', 2006, SYSDATETIME()),
('The Subtle Art of Not Giving a F*ck', 'A counterintuitive approach to living a good life.', 2016, SYSDATETIME());


INSERT INTO BookAuthor (BookId, AuthorId)
VALUES
(1, 1),  -- Atomic Habits → James Clear
(2, 2),  -- 7 Habits → Stephen Covey
(3, 3),  -- The Monk Who Sold His Ferrari → Robin Sharma
(4, 4),  -- Mindset → Carol Dweck
(5, 5);  -- The Subtle Art → Mark Manson
