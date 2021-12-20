#HOW TO ADD STORED PROCEDURES IN MIGRATIONS

#Step 1.
Add procedure file inside SQL folder of Domain solution. 
Procedure should have .sql or .txt extension.
Go to properties of the added file, and set BuildAction to be of type EmbededResource, so we can locate it and
read it from the assembly in runtime.

# Step 2. 
Open Package Manager Console

# Step 3.
Select default project to be NultienShop.DataAccess.Domain

#Step 4.
Run next command : Add-Migration {add your migration name}

#Step 5.
Open generated migration file and add code to Up and Down methods of migration

Add next code to methods so it looks like:

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceNames =
                assembly.GetExecutingAssembly().GetManifestResourceNames()
                .Where(str => str.Contains("{ADD_FILE_NAME_HERE}.sql"));

            foreach (string resourceName in resourceNames)
            {
                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                using StreamReader reader = new(stream);
                string sql = reader.ReadToEnd();
                migrationBuilder.Sql(sql);
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE {ADD_PROCEDURE_NAME_HERE}");  
        }

    -Additional tips:  
    1. Keep procedure name and file name same.
    2. Can be more than one procedure at a time, just replace or change the condition,
       also multiple drops in down method are required in that case
                  

#Step 5.
Run Update-Database from package manager console
