# SQLiteFTS5EFCoreExample
Experiment with EF Core and SQLite FTS5

It was a little difficult to get a working example for an implementation of EF Core with an FTS5 SQLite database. In the end it's quite simple - you just need to pass in raw SQL queries.

This example contains a SQLite database from here: http://millionsongdataset.com/pages/getting-dataset/#subset 

I've added the FTS5 Virtual table myself, by running the following code:

```sql
CREATE VIRTUAL TABLE songs_fts5 USING fts5(track_id, title, release, artist_name);
INSERT INTO songs_fts5(track_id, title, release, artist_name) 
SELECT track_id, title, release, artist_name FROM songs;
```

I've used a 'vanilla' scaffolded project with Razor pages to demonstrate that this works. Note that scaffolding on basis of the SongsFts5 model will fail, as there is no Primary Key defined.

The most likely scenario for working with this is demonstrated in the SongsFts5ApiController, accessable via (for example) https://localhost:44353/api/SongsFts5Api/Search?query=Run*&limit=7 when running the project.

This was made in Visual Studio 2019, packages as included in the project config, using dotnet-ef 3.1.0.
