*   From "1 Creating console application"
*   Create Book entity with Id, Name
*   Create Books property in Author entity
*   Add to Main list of books in an author
*   Change Context to set the sqlserver for db
*   Add migrations
    *   dotnet ef migrations add Initial -o "Migrations"
*   Generate DB
    *   dotnet ef database update
*   See result in db
*   Modify Author FirstOrDefault with include
*   Add Authors and AuthorId property to Book entity
*   Add OnConfiguring in context with relations




