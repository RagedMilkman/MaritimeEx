# MaritimeEx

To run the application, first build the Database.

To build the database you will probably need to create a login on your localhost sql server. The settings in the connection string are these:
"server=localhost;database=maritime;user=maritime;password=maritime;"

Feel free to change this in startup.cs line 35

Once the login is created; run "update-database" in the package manager console

The Angular test app can be run with ng serve
