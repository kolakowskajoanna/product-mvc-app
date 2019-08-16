# Product mvc app   
**Author:** Joanna Kołakowska   
### Requirements   
* postgresql   
* .net core   
### How to start development enviroment   
1. Create postgresql database.   
2. Run **sql_scripts/0001-create_tables.sql** on created database.   
3. Run **sql_scripts/0002-insert_categories.sql** on created database.   
4. Rename file **app_config.example.json** to **app_config.json**.   
5. Set correct database connection string in **app_config.json**.   
6. Run `dotnet restore`.   
7. Run `dotnet run`.   
