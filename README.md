# BitsOrchestra Test task

After cloning this project, add your connection string to User Secrets of BitsOrchestraTestTask project in following format:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YourServerName;Database=YourDatabaseName;Trusted_Connection=True;TrustServerCertificate=True"
  }
}

Then run choose DataAccessLyer as default project in Nu-Get Package console and run Update-Database command here.
After that, run the wohle solution.
